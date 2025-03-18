import React, { useEffect, useState } from 'react';
import { Layout, Button, Spin, Form, Modal, message, Input as Search } from 'antd';
import { SearchOutlined, PlusOutlined, ReloadOutlined, LockOutlined, UnlockOutlined } from '@ant-design/icons';
import { getAllBeautySalonCatalogs, createBeautySalonCatalog, updateBeautySalonCatalog, lockOrUnLockBeautySalonCatalog } from '../../apis/beautySalons/beautySalonCatalog';
import BeautySalonCatalogTable from '../../components/tables/beautySalons/BeautySalonCatalogTable';
import { CreateBeautySalonCatalogForm, UpdateBeautySalonCatalogForm } from '../../components/forms/beautySalons/BeautySalonCatalogForm';

const { Content } = Layout;

const BeautySalonCatalogPage = () => {
    const [form] = Form.useForm();
    const [data, setData] = useState([]);
    const [error, setErrors] = useState({});
    const [loading, setLoading] = useState(false);
    const [searchText, setSearchText] = useState('');
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize] = useState(10);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [imageUrl, setImageUrl] = useState(null);
    const [imageName, setImageName] = useState(null);
    const [updateRecord, setUpdateRecord] = useState(null);
    const [isActived, setIsActived] = useState(1); // Trạng thái isActived mặc định là 1
    const [userInfo, setUserInfo] = useState(null);

    const handleImageUpload = (file) => {
        const imageUrl = URL.createObjectURL(file);
        setImageUrl(imageUrl);
        const fileName = file.name;
        setImageName(fileName);
        return false;
    };

    const fetchData = async (isActived) => {
        const storedUserInfo = JSON.parse(sessionStorage.getItem('userInfo'));
        setUserInfo(storedUserInfo);
        setLoading(true);
        try {
            const response = await getAllBeautySalonCatalogs(isActived);
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
            Code: values.Code,
            Name: values.Name,
            Description: values.Description,
            Content: values.Content,
            Email: values.Email,
            Website: values.Website,
            Tel: values.Tel,
            Image: imageName,
            WorkingDate: values.WorkingDate,
            Address: values.Address,
            UserIdCreated: userInfo.Id,
            WardId: values.WardId,
            beautySalonImages: values.ListImage.map(imageUrl => ({ imageUrl: imageUrl }))
        };
        try {
            const response = await createBeautySalonCatalog(payload);
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
        const payload = {
            Id: updateRecord.id,
            Code: values.Code,
            Name: values.Name,
            Description: values.Description,
            Content: values.Content,
            Email: values.Email,
            Website: values.Website,
            Tel: values.Tel,
            Image: imageName,
            WorkingDate: values.WorkingDate,
            Address: values.Address,
            UserIdUpdated: userInfo.Id,
            WardId: values.WardId
        };
        try {
            const response = await updateBeautySalonCatalog(payload); // Sử dụng id từ bản ghi đang chỉnh sửa
            console.log('Cập nhật thành công:', response);
            message.success('Cập nhật thành công!');
            cancelModal();
            fetchData(isActived);
        } catch (error) {
            console.error('Error:', error);
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

    const onLockOrUnLockFinish = async (id) => {
        try {
            await lockOrUnLockBeautySalonCatalog(id);
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

    const handleLock = () => {
        const newIsActived = isActived === 1 ? 0 : 1;
        setIsActived(newIsActived);
        fetchData(newIsActived);
    };

    const handleReload = () => {
        setSearchText('');
        fetchData(isActived);
    };

    const showCreateModal = () => {
        cancelModal();
        setIsModalVisible(true);
        setUpdateRecord(null);
    };

    const cancelModal = () => {
        form.resetFields();
        setImageUrl(null);
        setIsModalVisible(false);
    };

    const showUpdateModal = (record) => {
        console.log(record);
        setUpdateRecord(record);
        form.setFieldsValue(record);
        setIsModalVisible(true);
    };

    useEffect(() => {
        fetchData(isActived); // Lấy dữ liệu khi trang được load với giá trị isActived mặc định là 1
    }, [isActived]);

    return (
        <Layout>
            <Content style={{ padding: '0px 10px' }}>
                <div style={{ marginBottom: '20px', display: 'flex', justifyContent: 'right', alignItems: 'center' }}>
                    <Search placeholder="Tìm kiếm tên thẩm mỹ viện" value={searchText} onChange={(e) => setSearchText(e.target.value)} style={{ marginRight: 10, border: '1px black solid' }} />
                    <Button icon={<SearchOutlined />} style={{ marginRight: 10, color: '#0099FF', border: '2px #0099FF solid' }}>Tìm kiếm</Button>
                    <Button icon={<PlusOutlined />} onClick={showCreateModal} style={{ marginRight: 10, padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}>Thêm mới</Button>
                    <Button icon={<ReloadOutlined />} onClick={handleReload} style={{ marginRight: 10, padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}>Tải lại</Button>
                    <Button icon={isActived === 1 ? <LockOutlined /> : <UnlockOutlined />} onClick={handleLock} style={{ padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}>
                        {isActived === 1 ? 'Danh sách khóa' : 'Danh sách kích hoạt'}
                    </Button>
                </div>
                {loading ? (
                    <Spin size="large" />
                ) : (
                    <BeautySalonCatalogTable
                        data={data}
                        currentPage={currentPage}
                        pageSize={pageSize}
                        isActived={isActived}
                        handleUpdate={showUpdateModal}
                        handleLockAndUnLock={confirmLockOrUnLock}
                        setCurrentPage={setCurrentPage}
                    />
                )}
                <CreateBeautySalonCatalogForm
                    open={isModalVisible && !updateRecord}
                    onCancel={cancelModal}
                    onFinish={onCreateFinish}
                    form={form}
                    imageUrl={imageUrl}
                    handleImageUpload={handleImageUpload}
                    error={error}
                />
                <UpdateBeautySalonCatalogForm
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

export default BeautySalonCatalogPage;