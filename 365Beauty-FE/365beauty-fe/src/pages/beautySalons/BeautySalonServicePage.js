import React, { useEffect, useState } from 'react';
import { Layout, Button, Spin, Form, Modal, message } from 'antd';
import { PlusOutlined, ReloadOutlined, LockOutlined, UnlockOutlined } from '@ant-design/icons';
import { createBeautySalonService, getAllBeautySalonServiceBySalonId, lockOrUnLockBeautySalonService, updateBeautySalonService } from '../../apis/beautySalons/beautySalonService';
import { useParams } from 'react-router-dom';
import BeautySalonServiceTable from '../../components/tables/beautySalons/BeautySalonServiceTable';
import { CreateBeautySalonServiceForm, UpdateBeautySalonServiceForm } from '../../components/forms/beautySalons/BeautySalonServiceForm';

const { Content } = Layout;

const BeautySalonServiceDetailPage = () => {
    const [form] = Form.useForm();
    const [error, setErrors] = useState({});
    const { id } = useParams(); // Lấy ID từ URL
    const [loading, setLoading] = useState(true);
    const [searchText, setSearchText] = useState('');
    const [currentPage, setCurrentPage] = useState(1);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [updateRecord, setUpdateRecord] = useState(null);
    const [pageSize] = useState(10);
    const [data, setData] = useState([]);
    const [imageUrl, setImageUrl] = useState(null);
    const [imageName, setImageName] = useState(null);
    const [isActived, setIsActived] = useState(1);

    const handleImageUpload = (file) => {
        const imageUrl = URL.createObjectURL(file);
        setImageUrl(imageUrl);
        const fileName = file.name;
        setImageName(fileName);
        return false;
    };

    const fetchData = async (id, isActived) => {
        setLoading(true);
        try {
            const response = await getAllBeautySalonServiceBySalonId({ salonId: id, isActived: isActived });
            const result = response.data;
            setData(result);
        } catch (error) {
            console.error('Lỗi khi lấy dữ liệu:', error);
        } finally {
            setLoading(false);
        }
    };
    const onCreateFinish = async (values) => {
        console.log(values);
        const payload = {
            salonId: id,
            beautySalonServices: values.beautySalonServices.map((salonService) => ({
                serviceId: salonService.serviceId,
                name: salonService.name,
                description: salonService.description,
                image: salonService.imageName,
            })),
        };
        try {
            await createBeautySalonService(payload);
            message.success('Thêm mới thành công!');
            cancelModal();
            fetchData(id, 1);
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại!');
        }
    };

    const onUpdateFinish = async (values) => {
        console.log(values);
        const payload = {
            salonId: id,
            Id: updateRecord.id,
            Name: values.Name,
            Description: values.Description,
            ServiceId: values.ServiceId,
            image: imageName,
        };
        try {
            await updateBeautySalonService(payload);
            message.success('Cập nhật thành công!');
            cancelModal();
            fetchData(id, 1);
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại!');
        }
    };

    const onLockOrUnLockFinish = async (serviceId) => {
        try {
            await lockOrUnLockBeautySalonService(serviceId);
            message.success(isActived === 1 ? 'Đã khóa thành công!' : 'Đã mở khóa thành công!');
            fetchData(id, isActived);
        } catch (error) {
            console.error('Lỗi khi xóa:', error);
            message.error('Đã xảy ra lỗi. Vui lòng thử lại.');
        }
    };

    const confirmLockOrUnLock = (id) => {
        Modal.confirm({
            title: 'Bạn có chắc chắn muốn khóa bản ghi này không?',
            content: 'Thao tác này không thể hoàn tác.',
            okText: 'Khóa',
            okType: 'danger',
            cancelText: 'Hủy',
            onOk: () => onLockOrUnLockFinish(id),
        });
    };

    const handleLock = () => {
        const newIsActived = isActived === 1 ? 0 : 1;
        setIsActived(newIsActived);
        fetchData(id, newIsActived);
    };

    useEffect(() => {
        fetchData(id, isActived);
    }, [id]);

    const showCreateModal = () => {
        cancelModal();
        setIsModalVisible(true);
        setUpdateRecord(null);
    };

    const showUpdateModal = (record) => {
        console.log(record);
        setUpdateRecord(record);
        form.setFieldsValue(record);
        setIsModalVisible(true);
    };

    const handleReload = () => {
        setSearchText('');
        fetchData(id, isActived);
    };

    const cancelModal = () => {
        form.resetFields();
        setIsModalVisible(false);
    };
    return (
        <Layout>
            <Content style={{ padding: '0px 10px' }}>
                <div style={{ marginBottom: '20px', display: 'flex', justifyContent: 'right', alignItems: 'center' }}>
                    <Button icon={<PlusOutlined />} onClick={showCreateModal} style={{ marginRight: 10, padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}>Thêm mới</Button>
                    <Button icon={<ReloadOutlined />} onClick={handleReload} style={{ marginRight: 10, padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}>Tải lại</Button>
                    <Button icon={isActived === 1 ? <LockOutlined /> : <UnlockOutlined />} onClick={handleLock} style={{ padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}>
                        {isActived === 1 ? 'Danh sách khóa' : 'Danh sách kích hoạt'}
                    </Button></div>
                {loading ? (
                    <Spin size="large" />
                ) : (
                    <BeautySalonServiceTable
                        data={data}
                        currentPage={currentPage}
                        pageSize={pageSize}
                        setCurrentPage={setCurrentPage}
                        handleUpdate={showUpdateModal}
                        handleLockAndUnLock={confirmLockOrUnLock}
                    />
                )}
                <CreateBeautySalonServiceForm
                    open={isModalVisible && !updateRecord}
                    onCancel={cancelModal}
                    onFinish={onCreateFinish}
                    form={form}
                    error={error}
                />
                <UpdateBeautySalonServiceForm
                    open={isModalVisible && updateRecord}
                    onCancel={cancelModal}
                    onFinish={onUpdateFinish}
                    form={form}
                    imageUrl={imageUrl}
                    handleImageUpload={handleImageUpload}
                    error={error}
                    catalogData={updateRecord}
                />
            </Content>
        </Layout>
    );
};

export default BeautySalonServiceDetailPage;