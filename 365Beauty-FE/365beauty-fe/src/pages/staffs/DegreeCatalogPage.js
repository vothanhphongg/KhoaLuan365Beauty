import React, { useState } from 'react';
import { Layout, Button, Spin, Form, Modal, message } from 'antd';
import { PlusOutlined, ReloadOutlined } from '@ant-design/icons';
import DegreeCatalogData from '../../hooks/staffs/DegreeCatalogData';
import DegreeCatalogTable from '../../components/tables/staffs/DegreeCatalogTable';
import { createDegreeCatalog, deleteDegreeCatalog, updateDegreeCatalog } from '../../apis/staffs/degreeCatalog';
import { CreateDegreeCatalogForm, UpdateDegreeCatalogForm } from '../../components/forms/staffs/DegreeCatalogForm';

const { Content } = Layout;

const DegreeCatalogPage = () => {
    const [form] = Form.useForm();
    const [error, setErrors] = useState({});
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize] = useState(10);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [updateRecord, setUpdateRecord] = useState(null);

    const { data, loading, fetchData } = DegreeCatalogData();

    const onCreateFinish = async (values) => {
        const payload = { name: values.Name };
        try {
            await createDegreeCatalog(payload);
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
            await updateDegreeCatalog(payload);
            message.success('Cập nhật thành công!');
            fetchData();
            cancelModal();
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại.');
        }
    };

    const delteFinish = async (id) => {
        try {
            await deleteDegreeCatalog(id);
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
                {loading ? (<Spin size="large" />) : (<DegreeCatalogTable data={data} currentPage={currentPage} pageSize={pageSize} handleUpdate={showUpdateModal} setCurrentPage={setCurrentPage} handleDelete={confirmdelete} />)}
            </Content>
            <CreateDegreeCatalogForm open={isModalVisible && !updateRecord} onCancel={cancelModal} onFinish={onCreateFinish} form={form} error={error} />
            <UpdateDegreeCatalogForm open={isModalVisible && updateRecord} onCancel={cancelModal} onFinish={onUpdateFinish} form={form} error={error} catalogData={updateRecord} />
        </Layout>
    );
};

export default DegreeCatalogPage;