import React, { useState } from 'react';
import { Spin, Form, message } from 'antd';
import { useParams } from 'react-router-dom';
import "../../styles/BeautySalonConfirmPage.css";
import { useUserBookingBySalonIdData } from '../../hooks/users/UserBookingData';
import { BeautySalonServiceBookingTable } from '../../components/tables/beautySalons/BeautySalonServiceTable';
import { ConfirmUserBookingForm } from '../../components/forms/beautySalons/BeautySalonServiceForm';
import { updateUserBookingByAdmin } from '../../apis/users/userBooking';

function BeautySalonConfirmPage() {
    const [form] = Form.useForm();
    const { id } = useParams();
    const [updateRecord, setUpdateRecord] = useState(null);
    const [isModalVisible, setIsModalVisible] = useState(false);
    const [currentPage, setCurrentPage] = useState(1);
    const [activeFilter, setActiveFilter] = useState(0);
    const [loading, setLoading] = useState(false);
    const [pageSize] = useState(10);

    // Gọi API với userId và activeFilter
    const { data, reload } = useUserBookingBySalonIdData(id, activeFilter);

    const onConfirmFinish = async (values) => {
        try {
            console.log(values);
            const payload = {
                id: values.id,
                staffId: values.staffId,
                amount: values.price,
                isActived: values.isActived
            };

            const response = await updateUserBookingByAdmin(payload);
            message.success('Cập nhật thành công!');
            cancelModal();
            reload();
        } catch (error) {
            message.error('Cập nhật thất bại. Vui lòng thử lại!');
        }
    };

    // Chọn trạng thái
    const handleFilterChange = (status) => {
        setActiveFilter(status);
        setCurrentPage(1); // Reset về trang đầu khi thay đổi filter
    };

    const showConfirmModal = (record) => {
        cancelModal();
        setIsModalVisible(true);
        setUpdateRecord(record);
    };

    const cancelModal = () => {
        form.resetFields();
        setIsModalVisible(false);
    };
    return (
        <div className='content-beauty-salon-confirm' style={{ paddingBottom: 50 }}>
            {/* Nút lọc trạng thái */}
            <div className='header-user-booking'>
                <div
                    className={`button-header ${activeFilter === 0 ? 'active' : ''}`}
                    onClick={() => handleFilterChange(0)} >
                    Chờ xác nhận
                </div>
                <div
                    className={`button-header button-2 ${activeFilter === 1 ? 'active' : ''}`}
                    onClick={() => handleFilterChange(1)}>
                    Đã xác nhận
                </div>
                <div
                    className={`button-header  ${activeFilter === 2 ? 'active' : ''}`}
                    onClick={() => handleFilterChange(2)}>
                    Đã hoàn thành
                </div>
                <div
                    className={`button-header button-2 ${activeFilter === 3 ? 'active' : ''}`}
                    onClick={() => handleFilterChange(3)}>
                    Đã đánh giá
                </div>
                <div
                    className={`button-header ${activeFilter === 4 ? 'active' : ''}`}
                    onClick={() => handleFilterChange(4)}>
                    Đã hủy
                </div>
            </div>
            {loading ? (
                <Spin size="large" />
            ) : (
                <BeautySalonServiceBookingTable
                    data={data}
                    currentPage={currentPage}
                    pageSize={pageSize}
                    handleConfirm={showConfirmModal}
                    setCurrentPage={setCurrentPage}
                />
            )}
            <ConfirmUserBookingForm
                open={isModalVisible}
                onCancel={cancelModal}
                onFinish={onConfirmFinish}
                form={form}
                catalogData={updateRecord}
                setCatalogData={setUpdateRecord}
            />
        </div>
    );
}

export default BeautySalonConfirmPage;
