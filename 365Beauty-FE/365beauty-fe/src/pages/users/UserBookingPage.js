import React, { useState } from 'react';
import { Button, Modal, Input, Rate, message } from 'antd';
import "../../styles/UserBookingPage.css";
import { useUserBookingActivedData } from '../../hooks/users/UserBookingData';
import { updateUserBookingByUser } from '../../apis/users/userBooking';

function UserBookingPage() {
    const userInfo = JSON.parse(sessionStorage.getItem('userInfo'));

    const [currentPage, setCurrentPage] = useState(1);
    const [activeFilter, setActiveFilter] = useState(0);
    const recordsPerPage = 5;

    // Gọi API với userId và activeFilter
    const { data, reload } = useUserBookingActivedData(userInfo.Id, activeFilter);

    const indexOfLastRecord = currentPage * recordsPerPage;
    const indexOfFirstRecord = indexOfLastRecord - recordsPerPage;
    const currentRecords = data.slice(indexOfFirstRecord, indexOfLastRecord);

    // State cho modal hủy
    const [cancelModalVisible, setCancelModalVisible] = useState(false);
    const [selectedBooking, setSelectedBooking] = useState(null);

    // State cho modal đánh giá
    const [reviewModalVisible, setReviewModalVisible] = useState(false);
    const [rating, setRating] = useState(0);
    const [comment, setComment] = useState("");

    // Xử lý mở modal hủy
    const showCancelModal = (booking) => {
        setSelectedBooking(booking);
        setCancelModalVisible(true);
    };

    // Xác nhận hủy
    const confirmCancel = async () => {
        if (!selectedBooking) return;
        try {
            await updateUserBookingByUser({
                id: selectedBooking.id,
                isActived: 4  // Cập nhật trạng thái đã hủy
            });
            message.success("Hủy đặt lịch thành công!");
            setCancelModalVisible(false);
            reload();
        } catch (error) {
            message.error("Hủy thất bại, vui lòng thử lại!");
        }
    };

    // Xử lý mở modal đánh giá
    const showReviewModal = (booking) => {
        setSelectedBooking(booking);
        setReviewModalVisible(true);
        setRating(0);
        setComment("");
    };

    // Xác nhận đánh giá
    const confirmReview = async () => {
        console.log(selectedBooking)
        if (!selectedBooking) return;
        try {
            await updateUserBookingByUser({
                id: selectedBooking.id,
                userId: userInfo.Id,
                salonServiceId: selectedBooking.salonServiceId,
                count: rating,
                comment: comment,
                isActived: 3  // Cập nhật trạng thái đã đánh giá
            });
            message.success("Gửi đánh giá thành công!");
            setReviewModalVisible(false);
            reload();
        } catch (error) {
            message.error("Gửi đánh giá thất bại, vui lòng thử lại!");
        }
    };

    return (
        <div className='right-container-user-info' style={{ paddingBottom: 50 }}>
            {/* Nút lọc trạng thái */}
            <div className='header-user-booking'>
                {["Chờ xác nhận", "Đã xác nhận", "Đã hoàn thành", "Đã đánh giá", "Đã hủy"].map((status, index) => (
                    <div
                        key={index}
                        className={`button-header ${activeFilter === index ? 'active' : ''}`}
                        onClick={() => { setActiveFilter(index); setCurrentPage(1); }}
                    >
                        {status}
                    </div>
                ))}
            </div>

            {currentRecords.map((booking) => (
                <div key={booking.id} style={{ border: '1px solid rgba(0, 0, 0, 0.3)', borderRadius: 10, overflow: 'hidden', marginBottom: 10 }}>
                    <div className='container-user-booking'>
                        <div className='container-user-booking-image'>
                            <img src={require(`../../assets/${booking.salonServiceImage ?? 'defaultAvatar.png'}`)} alt={booking.salonServiceName} />
                        </div>
                        <div className='container-user-booking-info'>
                            <p>Loại dịch vụ: <span className='span'>{booking.serviceName}</span></p>
                            <p style={{ color: 'rgba(0, 0, 0, 0.8)', fontSize: '25px', fontWeight: 500 }}>{booking.salonServiceName}</p>
                            <p style={{ fontSize: '18px', fontWeight: 500 }}>THẨM MỸ VIỆN {booking.salonName}</p>
                            <p style={{ color: 'rgba(0, 0, 0, 0.8)', fontSize: '16px' }}>{booking.addressFullAscending}</p>
                            <p>Thời gian: <span className='span'>{new Date(booking.bookingDate).toLocaleDateString('vi-VN')} - {booking.times}</span></p>
                            <p style={{ fontSize: '18px', fontWeight: 600 }} className='p-price'>{`Số tiền( ${booking.bookingTypeName}): ${booking.price.toLocaleString('vi-VN')}đ`}</p>
                        </div>
                    </div>
                    <div className='container-user-booking-button'>
                        <div
                            className='user-booking-button'
                            style={{ cursor: booking.isActived === 0 || booking.isActived === 2 ? 'pointer' : 'default' }}
                            onClick={() => {
                                if (booking.isActived === 0) showCancelModal(booking);
                                if (booking.isActived === 2) showReviewModal(booking);
                            }}
                        >
                            {booking.actived}
                        </div>
                    </div>
                </div>
            ))}

            {/* Modal Hủy */}
            <Modal
                title="Xác nhận hủy lịch hẹn"
                open={cancelModalVisible}
                onOk={confirmCancel}
                onCancel={() => setCancelModalVisible(false)}
                okText="Xác nhận"
                cancelText="Hủy"
            >
                <p>Bạn có chắc chắn muốn hủy lịch hẹn này?</p>
            </Modal>

            {/* Modal Đánh Giá */}
            <Modal
                title="Đánh giá dịch vụ"
                open={reviewModalVisible}
                onOk={confirmReview}
                onCancel={() => setReviewModalVisible(false)}
                okText="Gửi đánh giá"
                cancelText="Hủy"
            >
                <p>Vui lòng đánh giá chất lượng dịch vụ:</p>
                <Rate allowHalf value={rating} onChange={setRating} />
                <p>Bình luận:</p>
                <Input.TextArea value={comment} onChange={(e) => setComment(e.target.value)} placeholder="Nhập đánh giá..." />
            </Modal>

            {/* Nút chuyển trang */}
            <div style={{ display: 'flex', justifyContent: 'end', position: 'absolute', right: 10, bottom: 10 }}>
                <Button onClick={() => setCurrentPage(prev => prev - 1)} disabled={currentPage === 1}>Trang trước</Button>
                <span style={{ margin: '0 10px', lineHeight: '32px' }}>Trang {currentPage}</span>
                <Button onClick={() => setCurrentPage(prev => prev + 1)} disabled={indexOfLastRecord >= data.length}>Trang sau</Button>
            </div>
        </div>
    );
}

export default UserBookingPage;