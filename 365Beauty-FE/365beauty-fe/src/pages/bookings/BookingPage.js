import React, { useEffect, useState } from 'react';
import { Layout, Input, Select } from 'antd';
import { useNavigate, useParams } from 'react-router-dom';
import '../../styles/BookingPage.css';
import { getDetailBeautySalonService } from '../../apis/beautySalons/beautySalonService';
import { ClockCircleOutlined, UserOutlined } from '@ant-design/icons';
import BookingTimePage from './BookingTimePage';
import useBookingTypeData from '../../hooks/bookings/bookingTypeData';

const { Content } = Layout;
const { Option } = Select;

const BookingPage = () => {
    const navigate = useNavigate();
    const [data, setData] = useState({});
    const [selectedBookingTypeId, setSelectedBookingTypeId] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [selectedDate, setSelectedDate] = useState(null);
    const [selectedTime, setSelectedTime] = useState(null);
    const handleOpenModal = () => setIsModalOpen(true);
    const handleCloseModal = () => setIsModalOpen(false);
    const { id } = useParams();

    const userInfo = JSON.parse(localStorage.getItem('userInfo'));
    const { data: bookingType } = useBookingTypeData();
    console.log(bookingType);
    useEffect(() => {
        const fetchSalonServiceDetail = async () => {
            const response = await getDetailBeautySalonService(id);
            setData(response.data);
        };
        fetchSalonServiceDetail();
    }, [id]);



    const handleConfirmTime = (date, time) => {
        setSelectedDate(date);
        setSelectedTime(time.times);
        setIsModalOpen(false);
    };

    const handleBookingTypeChange = (value) => {
        setSelectedBookingTypeId(value);
    };

    return (
        <Content className='content-booking'>
            <div className='info-transaction'>
                <div className='header-info'><h2>Thông tin thanh toán</h2></div>
                <div className='detail-info'>
                    <p>Người đặt lịch: {userInfo?.FullName}.</p>
                    <p>Số điện thoại: {userInfo?.Tel}.</p>
                    <p>Email: {userInfo?.Email}.</p>
                    <div className="detail-salon">
                        <img src={require(`../../assets/${data.slnImage ?? 'defaultAvatar.png'}`)} alt={data.slnName} className="salon-logo" />
                        <div>
                            <h3>{data.slnName}</h3>
                            <p style={{ fontSize: '15px', fontWeight: 400 }}>{data.addressFullAscending}</p>
                        </div>
                    </div>
                    <div className="detail-salon-service">
                        <img src={require(`../../assets/${data.image ?? 'defaultAvatar.png'}`)} alt={data.name} className="salon-logo" />
                        <div>
                            <h3>{data.name}</h3>
                            <div className="price">
                                <div style={{ fontSize: '10px' }} className='precent-discount'>{data.precentDiscount}%</div>
                                <div style={{ fontSize: '18px' }} className="service-final-price">{(data.finalPrice ?? 0).toLocaleString('vi-VN')}đ</div>
                                <div style={{ fontSize: '14px' }} className="service-base-price">{(data.basePrice ?? 0).toLocaleString('vi-VN')}đ</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div className='info-booking'>
                <div className='header-info'><h2>Thông tin đặt lịch</h2></div>
                <div className='detail-info'>
                    <div className='booking-time'>
                        <span>
                            <ClockCircleOutlined style={{ marginRight: '10px' }} />
                            {selectedDate && selectedTime ? (
                                `Đã chọn: ${selectedDate.day}/${selectedDate.month}/${selectedDate.year} - ${selectedTime}`
                            ) : (
                                'Vui lòng chọn thời gian'
                            )}
                            <button className='booking-time-button' onClick={handleOpenModal}>
                                Chọn thời gian &gt;
                            </button>
                        </span>
                    </div>
                    <div className='booking-staff'>
                        <span><UserOutlined style={{ marginRight: '10px' }} />Chọn nhân viên (Có thể không chọn)<button className='booking-time-button'>Chọn nhân viên &gt;</button></span>
                    </div>
                    <div className='booking-description'>
                        <label>Ghi chú</label>
                        <Input.TextArea style={{ marginTop: 10 }} name='content' placeholder='Ghi chú: Thông tin liên quan đến lịch hẹn,.......' autoSize={{ minRows: 5 }} />
                    </div>
                    <div className='booking-type'>
                        <label>Chọn loại đặt lịch</label>
                        <Select
                            placeholder="Chọn loại đặt lịch"
                            onChange={handleBookingTypeChange}
                            style={{ width: '100%', fontWeight: 500, marginTop: 10 }}
                        >
                            {bookingType.map((type) => (
                                <Option key={type.id} value={type.id}>{type.name}</Option>
                            ))}
                        </Select>
                    </div>
                    {selectedBookingTypeId === 1 && (
                        <div className="booking-transaction">
                            <p>Chọn phương thức đặt lịch</p>
                            <div className="booking-transaction-image">
                                <img src={require('../../assets/06ncktiwd6dc1694418196384.png')} alt={data.name} className="salon-logo" />
                                <p>Thanh toán qua VNPAY</p>
                            </div>
                        </div>
                    )}
                </div>
                <div className='button-confirm-booking'>
                    {bookingType.find(type => type.id === selectedBookingTypeId)?.name}
                </div>

            </div>
            <BookingTimePage
                visible={isModalOpen}
                onClose={handleCloseModal}
                onConfirm={handleConfirmTime}
                salonServiceId={id}
            />
        </Content>
    );
}

export default BookingPage;
