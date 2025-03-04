import React, { useEffect, useState } from 'react';
import { Layout, Button, Spin, Form, Modal, message } from 'antd';
import { getAllBeautySalonServiceBySalonId } from '../../apis/beautySalons/beautySalonService';
import { useParams } from 'react-router-dom';
import { BeautySalonServiceNoPriceTable, BeautySalonServiceWithPriceTable } from '../../components/tables/beautySalons/BeautySalonServiceTable';
import { CreatePriceServiceForm } from '../../components/forms/beautySalons/BeautySalonServiceForm';
import { createPrice, updatePrice } from '../../apis/beautySalons/beautySalonPrice';

const { Content } = Layout;

const BeautySalonPricePage = () => {
    const [form] = Form.useForm();
    const { id } = useParams();  // Lấy ID từ URL
    const [loading, setLoading] = useState(true);
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize] = useState(10);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [createRecord, setCreateRecord] = useState(null);
    const [updateRecord, setUpdateRecord] = useState(null);

    // Thêm state để lưu dữ liệu phân loại
    const [dataNoPrice, setDataNoPrice] = useState([]);     // Dịch vụ không có giá
    const [dataWithPrice, setDataWithPrice] = useState([]);  // Dịch vụ có giá

    // Lấy dữ liệu và phân loại
    const fetchData = async (id) => {
        setLoading(true);
        try {
            const response = await getAllBeautySalonServiceBySalonId({ salonId: id, isActived: 1 });
            const result = response.data;

            // Phân loại dữ liệu
            const noPrice = result.filter(item => item.price === null);
            const withPrice = result.filter(item => item.price !== null);

            setDataNoPrice(noPrice);
            setDataWithPrice(withPrice);
            console.log(withPrice);
        } catch (error) {
            console.error('Lỗi khi lấy dữ liệu:', error);
        } finally {
            setLoading(false);
        }
    };

    // Gọi API khi ID thay đổi
    useEffect(() => {
        fetchData(id);
    }, [id]);

    const onCreateFinish = async (values) => {
        const payload = {
            salonServiceId: createRecord.id,
            basePrice: values.basePrice,
            finalPrice: values.finalPrice
        };
        try {
            await createPrice(payload);
            message.success('Thêm mới thành công!');
            cancelModal();
            fetchData(id, 1);
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại!');
        }
    };

    const onUpdateFinish = async (values) => {
        const payload = {
            salonServiceId: updateRecord.id,
            basePrice: values.basePrice,
            finalPrice: values.finalPrice
        };
        try {
            await updatePrice(payload);
            message.success('Thêm mới thành công!');
            cancelModal();
            fetchData(id, 1);
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại!');
        }
    };

    const showCreateModal = (record) => {
        setCreateRecord(record);
        setIsModalVisible(true);
    };

    const showUpdateModal = (record) => {
        setUpdateRecord(record);
        setIsModalVisible(true);
    };

    const cancelModal = () => {
        form.resetFields();
        setIsModalVisible(false);
    };
    return (
        <Layout>
            <Content style={{ padding: '0px 10px' }}>
                {loading ? (
                    <Spin size="large" />
                ) : (
                    <div style={{ display: 'flex' }}>
                        {/* Bảng dịch vụ không có giá */}
                        <BeautySalonServiceNoPriceTable
                            data={dataNoPrice}
                            currentPage={currentPage}
                            pageSize={pageSize}
                            setCurrentPage={setCurrentPage}
                            handleCreate={showCreateModal}
                        />
                        {/* Bảng dịch vụ có giá */}
                        <BeautySalonServiceWithPriceTable
                            data={dataWithPrice}
                            currentPage={currentPage}
                            pageSize={pageSize}
                            setCurrentPage={setCurrentPage}
                            handleUpdate={showUpdateModal}
                        />
                    </div>
                )}
                <CreatePriceServiceForm
                    open={isModalVisible && createRecord}
                    onCancel={cancelModal}
                    onFinish={onCreateFinish}
                    form={form}
                />
                <CreatePriceServiceForm
                    open={isModalVisible && updateRecord}
                    onCancel={cancelModal}
                    onFinish={onUpdateFinish}
                    form={form}
                />
            </Content>
        </Layout>
    );
};

export default BeautySalonPricePage;
