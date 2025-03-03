import React, { useState } from 'react';
import { Layout, Button, Spin, Form, Modal, message } from 'antd';
import { PlusOutlined, ReloadOutlined, LockOutlined, UnlockOutlined } from '@ant-design/icons';
import { createServiceCatalog, lockOrUnLockServiceCatalog, updateServiceCatalog } from '../../apis/services/serviceCatalog';
import ServiceCatalogTable from '../../components/tables/services/ServiceCatalogTable';
import { CreateServiceCatalogForm, UpdateServiceCatalogForm } from '../../components/forms/services/ServiceCatalogForm';
import { useServiceCatalogData } from '../../hooks/services/ServiceCatalogData';

const { Content } = Layout;

const ServiceCatalogPage = () => {
    const [form] = Form.useForm();
    const [error] = useState({});
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize] = useState(10);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [imageUrl, setImageUrl] = useState(null);
    const [imageName, setImageName] = useState(null);
    const [updateRecord, setUpdateRecord] = useState(null);

    const { data, isActived, loading, toggleIsActived, fetchData } = useServiceCatalogData();
    const userInfo = JSON.parse(localStorage.getItem('userInfo'));

    const handleImageUpload = (file) => {
        const imageUrl = URL.createObjectURL(file);
        setImageUrl(imageUrl);
        const fileName = file.name;
        setImageName(fileName);
        return false;
    };

    const onCreateFinish = async (values) => {
        console.log(values);
        const payload = {
            name: values.Name,
            icon: imageName,
            userIdCreated: userInfo.Id,
        };
        try {
            await createServiceCatalog(payload);
            message.success('Thêm mới thành công!');
            fetchData(1);
            cancelModal();
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại.');
        }
    };

    const onUpdateFinish = async (values) => {
        console.log(values);
        const payload = {
            Id: updateRecord.id,
            name: values.Name,
            icon: imageName,
        };
        try {
            await updateServiceCatalog(payload);
            message.success('Cập nhật thành công!');
            fetchData(1);
            cancelModal();
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại.');
        }
    };

    const onLockOrUnLockFinish = async (id) => {
        try {
            await lockOrUnLockServiceCatalog(id);
            message.success(isActived === 1 ? 'Đã khóa thành công!' : 'Đã mở khóa thành công!');
            fetchData(isActived);
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

    const showCreateModal = () => {
        cancelModal();
        setIsModalVisible(true);
        setUpdateRecord(null);
    };

    const showUpdateModal = (record) => {
        setUpdateRecord(record);
        console.log(record);
        form.setFieldsValue(record);
        setIsModalVisible(true);
    };

    const cancelModal = () => {
        form.resetFields();
        setImageUrl(null);
        setImageName(null);
        setIsModalVisible(false);
    };

    const handleReload = () => {
        fetchData(isActived);
    };
    return (
        <Layout>
            <Content style={{ padding: '0px 10px' }}>
                <div style={{ marginBottom: '20px', display: 'flex', justifyContent: 'right', alignItems: 'center' }}>
                    <Button icon={<PlusOutlined />} onClick={showCreateModal} style={{ marginRight: 10, padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}>Thêm mới</Button>
                    <Button icon={<ReloadOutlined />} onClick={handleReload} style={{ marginRight: 10, padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}>Tải lại</Button>
                    <Button icon={isActived === 1 ? <LockOutlined /> : <UnlockOutlined />} onClick={toggleIsActived} style={{ padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }} >{isActived === 1 ? 'Danh sách khóa' : 'Danh sách kích hoạt'}</Button>
                </div>
                {loading ? (<Spin size="large" />) : (<ServiceCatalogTable data={data} currentPage={currentPage} pageSize={pageSize} handleUpdate={showUpdateModal} isActived={isActived} setCurrentPage={setCurrentPage} handleLockAndUnLock={confirmLockOrUnLock} />)}
            </Content>
            <CreateServiceCatalogForm open={isModalVisible && !updateRecord} onCancel={cancelModal} onFinish={onCreateFinish} form={form} imageUrl={imageUrl} handleImageUpload={handleImageUpload} error={error} />
            <UpdateServiceCatalogForm open={isModalVisible && updateRecord} onCancel={cancelModal} onFinish={onUpdateFinish} form={form} imageUrl={imageUrl} handleImageUpload={handleImageUpload} error={error} catalogData={updateRecord} />
        </Layout>
    );
};

export default ServiceCatalogPage;
