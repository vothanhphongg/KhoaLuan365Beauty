import React, { useEffect, useState } from 'react';
import { Layout, Spin, Form, message } from 'antd';
import { useParams } from 'react-router-dom';
import { BeautySalonServiceNoPriceTable, BeautySalonServiceWithPriceTable } from '../../components/tables/beautySalons/BeautySalonServiceTable';
import { CreatePriceServiceForm, UpdatePriceServiceForm } from '../../components/forms/beautySalons/BeautySalonServiceForm';
import { createPrice, updatePrice } from '../../apis/beautySalons/beautySalonPrice';
import { useBeautySalonServiceWithPriceAndBookingBySalonIdData } from '../../hooks/beautySalons/beautySalonServiceData';

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
    const [dataWithPrice, setDataWithPrice] = useState([]);
    const [reload, setReload] = useState(false);

    // Sử dụng hook để lấy dữ liệu
    const data = useBeautySalonServiceWithPriceAndBookingBySalonIdData(id, reload);
    const fetchData = async () => {
        if (data) {
            const noPrice = data.filter(item => item.finalPrice === null);
            const withPrice = data.filter(item => item.finalPrice !== null);
            setDataNoPrice(noPrice);
            setDataWithPrice(withPrice);
        }
        setLoading(false);  // Đặt bên ngoài if để thoát loading dù có data hay không
    };

    // Gọi fetchData bên trong useEffect
    useEffect(() => {
        fetchData();
    }, [data]);

    const onCreateFinish = async (values) => {
        const payload = {
            salonServiceId: createRecord.id,
            basePrice: values.basePrice,
            finalPrice: values.finalPrice,
            bookingCount: values.bookingCount,
            bookingTimes: values.TimeIds
        };
        try {
            await createPrice(payload);
            message.success('Thêm mới thành công!');
            cancelModal();
            setReload(!reload);
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại!');
        }
    };

    const onUpdateFinish = async (values) => {
        const payload = {
            salonServiceId: updateRecord.id,
            basePrice: values.basePrice,
            finalPrice: values.finalPrice,
            bookingCount: values.bookingCount,
            bookingTimes: values.TimeIds // Thêm TimeIds vào payload
        };
        try {
            await updatePrice(payload);
            message.success('Cập nhật thành công!');
            cancelModal();
            setLoading(true);
            setReload(!reload);
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại!');
        }
    };

    const showCreateModal = (record) => {
        setCreateRecord(record);
        setIsModalVisible(true);

    };

    const showUpdateModal = (record) => {
        console.log(record)
        setUpdateRecord(record);
        setIsModalVisible(true);
    };

    const cancelModal = () => {
        form.resetFields();
        setIsModalVisible(false);
        setCreateRecord(null);
        setUpdateRecord(null);
    };
    return (
        <Layout>
            <Content style={{ padding: '0px 10px' }}>
                {loading ? (
                    <Spin size="large" />
                ) : (
                    <div style={{ display: 'flex', justifyContent: 'center' }}>
                        {/* Bảng dịch vụ không có giá */}
                        {dataNoPrice.length != 0 && (
                            <BeautySalonServiceNoPriceTable
                                data={dataNoPrice}
                                currentPage={currentPage}
                                pageSize={pageSize}
                                setCurrentPage={setCurrentPage}
                                handleCreate={showCreateModal}
                            />
                        )}
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
                    open={isModalVisible && createRecord && !updateRecord}
                    onCancel={cancelModal}
                    onFinish={onCreateFinish}
                    form={form}
                />
                <UpdatePriceServiceForm
                    open={isModalVisible && updateRecord}
                    onCancel={cancelModal}
                    onFinish={onUpdateFinish}
                    form={form}
                    catalogData={updateRecord}
                />
            </Content>
        </Layout>
    );
};

export default BeautySalonPricePage;
