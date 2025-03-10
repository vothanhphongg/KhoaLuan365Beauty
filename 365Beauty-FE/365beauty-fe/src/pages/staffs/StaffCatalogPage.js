import React, { useEffect, useState } from 'react';
import { Layout, Button, Spin, Form, Modal, message } from 'antd';
import { PlusOutlined, ReloadOutlined, LockOutlined, UnlockOutlined } from '@ant-design/icons';
import { createBeautySalonService, getAllBeautySalonServiceBySalonId, lockOrUnLockBeautySalonService, updateBeautySalonService } from '../../apis/beautySalons/beautySalonService';
import { useParams } from 'react-router-dom';
import { createStaffCatalog, getAllStaffCatalogBySalonIds, lockOrUnLockStaffCatalog, upateStaffCatalog } from '../../apis/staffs/staffCatalog';
import StaffCatalogTable from '../../components/tables/staffs/StaffCatalogTable';
import { CreateStaffCatalogForm, UpdateStaffCatalogForm } from '../../components/forms/staffs/StaffCatalogForm';

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

    const fetchData = async (id) => {
        setLoading(true);
        try {
            const response = await getAllStaffCatalogBySalonIds(id);
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
            code: values.Code,
            idCard: values.IdCard,
            fullName: values.Name,
            gender: values.Gender,
            email: values.Email,
            dateOfBirth: values.DateOfBirth ? values.DateOfBirth.format('YYYY-MM-DD') : null,
            tel: values.Tel,
            introduction: values.Introduction,
            img: imageName,
            degreeId: values.DegId,
            titleId: values.TitleId,
            occupationId: values.OccId,
            address: values.Address,
            wardId: values.WardId,
            services: values.ServiceId.map(id => ({ staffId: 0, serviceId: id }))
        };
        try {
            const response = await createStaffCatalog(payload);
            console.log('Thêm mới thành công:', response);
            message.success('Thêm mới thành công!');
            cancelModal();
            fetchData(isActived);
        } catch (error) {
            console.error('Error:', error);
            console.log(error.response.data);
            if (error.response && error.response.data) {
                const apiErrors = error.response.data.error.details.reduce((acc, detail) => {
                    const fieldName = detail.split(' ')[0];
                    acc[fieldName] = detail;
                    return acc;
                }, {});
                setErrors(apiErrors);
            }
            message.error('Đã xảy ra lỗi. Vui lòng thử lại.');
        }
    };

    const onUpdateFinish = async (values) => {
        console.log(values);
        const payload = {
            salonId: id,
            Id: updateRecord.id,
            code: values.Code,
            idCard: values.IdCard,
            fullName: values.Name,
            gender: values.Gender,
            email: values.Email,
            dateOfBirth: values.DateOfBirth ? values.DateOfBirth.format('YYYY-MM-DD') : null,
            tel: values.Tel,
            introduction: values.Introduction,
            img: imageName,
            degreeId: values.DegId,
            titleId: values.TitleId,
            occupationId: values.OccId,
            address: values.Address,
            wardId: values.WardId,
            services: values.ServiceId.map(id => ({ staffId: 0, serviceId: id }))
        };
        try {
            await upateStaffCatalog(payload);
            message.success('Cập nhật thành công!');
            cancelModal();
            fetchData(id, 1);
        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại!');
        }
    };

    const onLockOrUnLockFinish = async (staffId) => {
        try {
            await lockOrUnLockStaffCatalog(staffId);
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
                    <StaffCatalogTable
                        data={data}
                        currentPage={currentPage}
                        pageSize={pageSize}
                        setCurrentPage={setCurrentPage}
                        handleUpdate={showUpdateModal}
                        handleLockAndUnLock={confirmLockOrUnLock}
                    />
                )}
                <CreateStaffCatalogForm
                    open={isModalVisible && !updateRecord}
                    onCancel={cancelModal}
                    onFinish={onCreateFinish}
                    form={form}
                    error={error}
                    imageUrl={imageUrl}
                    handleImageUpload={handleImageUpload}
                />
                <UpdateStaffCatalogForm
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