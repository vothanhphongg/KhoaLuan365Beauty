import React, { useState } from 'react';
import { Layout, Button, Spin, Form, Modal, message } from 'antd';
import { PlusOutlined, ReloadOutlined } from '@ant-design/icons';
import { createOccupationCatalog, deleteOccupationCatalog, updateOccupationCatalog } from '../../apis/staffs/occupationCatalog';
import { CreateOccupationCatalogForm, UpdateOccupationCatalogForm } from '../../components/forms/staffs/OccupationCatalogForm';
import OccupationCatalogTable from '../../components/tables/staffs/OccupationCatalogTable';
import OccupationCatalogData from '../../hooks/staffs/OccupationCatalogData';

const { Content } = Layout;

const OccupationCatalogPage = () => {
    const [form] = Form.useForm();
    const [error, setErrors] = useState({});
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize] = useState(10);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [updateRecord, setUpdateRecord] = useState(null);

    const { data, loading, fetchData } = OccupationCatalogData();

    const onCreateFinish = async (values) => {
        const payload = { name: values.Name };
        try {
            await createOccupationCatalog(payload);
            message.success('Thêm mới thành công!');
            fetchData();
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
        };
        try {
            await updateOccupationCatalog(payload);
            message.success('Cập nhật thành công!');
            fetchData();
            cancelModal();
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại.');
        }
    };

    const delteFinish = async (id) => {
        try {
            await deleteOccupationCatalog(id);
            message.success('Đã xóa thành công!');
            fetchData();
        } catch (error) {
            console.error('Lỗi khi xóa:', error);
            message.error('Đã xảy ra lỗi. Vui lòng thử lại.');
        }
    };

    const confirmdelete = (id) => {
        Modal.confirm({
            title: 'Bạn có chắc chắn muốn xóa bản ghi này không?',
            content: 'Thao tác này không thể hoàn tác.',
            okText: 'Xóa',
            okType: 'danger',
            cancelText: 'Hủy',
            onOk: () => delteFinish(id),
        });
    };

    const showCreateModal = () => {
        cancelModal();
        setIsModalVisible(true);
        setUpdateRecord(null);
    };

    const showUpdateModal = (record) => {
        setUpdateRecord(record);
        form.setFieldsValue(record);
        setIsModalVisible(true);
    };

    const cancelModal = () => {
        form.resetFields();
        setIsModalVisible(false);
    };

    const handleReload = () => {
        fetchData();
    };
    return (
        <Layout>
            <Content style={{ padding: '0px 10px' }}>
                <div style={{ marginBottom: '20px', display: 'flex', justifyContent: 'right', alignItems: 'center' }}>
                    <Button icon={<PlusOutlined />} onClick={showCreateModal} style={{ marginRight: 10, padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}>Thêm mới</Button>
                    <Button icon={<ReloadOutlined />} onClick={handleReload} style={{ marginRight: 10, padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}>Tải lại</Button>
                </div>
                {loading ? (<Spin size="large" />) : (<OccupationCatalogTable data={data} currentPage={currentPage} pageSize={pageSize} handleUpdate={showUpdateModal} setCurrentPage={setCurrentPage} handleDelete={confirmdelete} />)}
            </Content>
            <CreateOccupationCatalogForm open={isModalVisible && !updateRecord} onCancel={cancelModal} onFinish={onCreateFinish} form={form} error={error} />
            <UpdateOccupationCatalogForm open={isModalVisible && updateRecord} onCancel={cancelModal} onFinish={onUpdateFinish} form={form} error={error} catalogData={updateRecord} />
        </Layout>
    );
};

export default OccupationCatalogPage;