import React, { useState } from 'react';
import { Button } from 'antd';
import "../../styles/BeautySalonConfirmPage.css";
import { useUserBookingActivedData } from '../../hooks/users/UserBookingData';

function BeautySalonConfirmPage() {
    const userInfo = JSON.parse(localStorage.getItem('userInfo'));

    const [currentPage, setCurrentPage] = useState(1);
    const [activeFilter, setActiveFilter] = useState(0); // Trạng thái mặc định là "Chờ xác nhận"
    const recordsPerPage = 5;

    // Gọi API với userId và activeFilter
    const data = useUserBookingActivedData(userInfo.Id, activeFilter);

    const indexOfLastRecord = currentPage * recordsPerPage;
    const indexOfFirstRecord = indexOfLastRecord - recordsPerPage;
    const currentRecords = data.slice(indexOfFirstRecord, indexOfLastRecord);

    // Chuyển trang
    const nextPage = () => {
        if (indexOfLastRecord < data.length) setCurrentPage(prev => prev + 1);
    };

    const prevPage = () => {
        if (currentPage > 1) setCurrentPage(prev => prev - 1);
    };

    // Chọn trạng thái
    const handleFilterChange = (status) => {
        setActiveFilter(status);
        setCurrentPage(1); // Reset về trang đầu khi thay đổi filter
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
                    className={`button-header button-3 ${activeFilter === 2 ? 'active' : ''}`}
                    onClick={() => handleFilterChange(2)}>
                    Đã hoàn thành
                </div>
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
                        <div className='user-booking-button' style={{ cursor: booking.isActived === 0 || booking.isActived === 2 ? 'pointer' : 'default' }}>{booking.actived}</div>
                    </div>
                </div>
            ))}

            {/* Nút chuyển trang */}
            <div style={{ display: 'flex', justifyContent: 'end', position: 'absolute', right: 10, bottom: 10 }}>
                <Button onClick={prevPage} disabled={currentPage === 1}>Trang trước</Button>
                <span style={{ margin: '0 10px', lineHeight: '32px' }}>Trang {currentPage}</span>
                <Button onClick={nextPage} disabled={indexOfLastRecord >= data.length}>Trang sau</Button>
            </div>
        </div>
    );
}

export default BeautySalonConfirmPage;
