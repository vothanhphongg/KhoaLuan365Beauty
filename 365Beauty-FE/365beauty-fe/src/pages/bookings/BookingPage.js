import React, { useEffect, useState } from 'react';
import { Layout, Input, Select, message } from 'antd';
import { useNavigate, useParams } from 'react-router-dom';
import '../../styles/BookingPage.css';
import { getDetailBeautySalonService } from '../../apis/beautySalons/beautySalonService';
import { ClockCircleOutlined, UserOutlined } from '@ant-design/icons';
import BookingTimePage from './BookingTimePage';
import useBookingTypeData from '../../hooks/bookings/bookingTypeData';
import { createUserBooking } from '../../apis/users/userBooking';
import BookingStaffPage from './BookingStaffPage';

const { Content } = Layout;
const { Option } = Select;

const BookingPage = () => {
    const navigate = useNavigate();
    const [data, setData] = useState({});
    const [selectedBookingTypeId, setSelectedBookingTypeId] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);
    const [description, setDescription] = useState('');
    const [selectedDate, setSelectedDate] = useState(null);
    const [selectedTime, setSelectedTime] = useState(null);
    const [isTimeModalOpen, setIsTimeModalOpen] = useState(false);
    const [isStaffModalOpen, setIsStaffModalOpen] = useState(false);
    const [selectedStaff, setSelectedStaff] = useState(null);

    const { id } = useParams();

    const userInfo = JSON.parse(sessionStorage.getItem('userInfo'));
    const { data: bookingType = [] } = useBookingTypeData();  // Thêm giá trị mặc định để tránh lỗi khi chưa có dữ liệu

    useEffect(() => {
        const fetchSalonServiceDetail = async () => {
            try {
                const response = await getDetailBeautySalonService(id);
                setData(response.data);
            } catch (error) {
                message.error('Không thể tải dữ liệu dịch vụ.');
            }
        };
        if (id) fetchSalonServiceDetail();
    }, [id]);

    const handleOpenTimeModal = () => setIsTimeModalOpen(true);
    const handleCloseTimeModal = () => setIsTimeModalOpen(false);

    const handleOpenStaffModal = () => {
        if (!selectedDate || !selectedTime) {
            message.warning('Vui lòng chọn thời gian trước!');
            return;
        }
        setIsStaffModalOpen(true);
    };

    const handleCloseStaffModal = () => setIsStaffModalOpen(false);

    const onCreateFinish = async () => {
        if (!userInfo || !selectedDate || !selectedTime || !selectedBookingTypeId) {
            message.warning('Vui lòng điền đầy đủ thông tin!');
            return;
        }
        const payload = {
            userId: userInfo.Id,
            salonServiceId: id,
            timeId: selectedTime.id,
            staffId: selectedStaff.id,
            bookingTypeId: selectedBookingTypeId,
            description: description,
            bookingDate: `${selectedDate.year}-${String(selectedDate.month).padStart(2, '0')}-${String(selectedDate.day).padStart(2, '0')}`
        };

        try {
            const response = await createUserBooking(payload);
            const { data } = response.data;
            if (data?.redirectUrl) {
                window.location.href = data.redirectUrl;  // Chuyển đến trang thanh toán ảo
            } else {
                navigate(`/booking-success/${data}`);  // Nếu không có URL thì chuyển đến trang thành công
            }


        } catch (error) {
            message.error('Đã xảy ra lỗi. Vui lòng thử lại.');
        }
    };

    const handleConfirmTime = (date, time) => {
        setSelectedDate(date);
        setSelectedTime(time);
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
                    <p>Người đặt lịch: {userInfo?.FullName || 'Không có thông tin'}.</p>
                    <p>Số điện thoại: {userInfo?.Tel || 'Không có thông tin'}.</p>
                    <p>Email: {userInfo?.Email || 'Không có thông tin'}.</p>
                    <div className="detail-salon">
                        <img src={require(`../../assets/${data.slnImage ?? 'defaultAvatar.png'}`)} alt={data.slnName || 'Salon'} className="salon-logo" />
                        <div>
                            <h3>{data.slnName || 'Tên salon'}</h3>
                            <p style={{ fontSize: '15px', fontWeight: 400 }}>{data.addressFullAscending || 'Địa chỉ không có sẵn'}</p>
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
                                `Đã chọn: ${selectedDate.day}/${selectedDate.month}/${selectedDate.year} - ${selectedTime.times}`
                            ) : (
                                'Vui lòng chọn thời gian'
                            )}
                            <button className='booking-time-button' onClick={handleOpenTimeModal}>
                                Chọn thời gian &gt;
                            </button>
                        </span>
                    </div>
                    <div className='booking-staff'>
                        <span><UserOutlined style={{ marginRight: '10px' }} />
                            {selectedStaff ? `Nhân viên đã chọn: ${selectedStaff.fullName}` : 'Chọn nhân viên (Có thể không chọn)'}
                            <button className='booking-time-button' onClick={handleOpenStaffModal}>Chọn nhân viên &gt;</button>
                        </span>
                    </div>

                    <div className='booking-description'>
                        <label>Ghi chú</label>
                        <Input.TextArea
                            style={{ marginTop: 10 }}
                            name='description'
                            placeholder='Ghi chú: Thông tin liên quan đến lịch hẹn,.......'
                            autoSize={{ minRows: 5 }}
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                        />                    </div>
                    <div className='booking-type'>
                        <label>Chọn loại đặt lịch</label>
                        <Select
                            placeholder="Chọn loại đặt lịch"
                            onChange={handleBookingTypeChange}
                            style={{ width: '100%', fontWeight: 500, marginTop: 10 }}
                            value={selectedBookingTypeId}
                        >
                            {bookingType.map((type) => (
                                <Option key={type.id} value={type.id}>{type.name}</Option>
                            ))}
                        </Select>
                    </div>
                </div>
                <div
                    className='button-confirm-booking'
                    onClick={onCreateFinish}
                >
                    Đặt lịch và {bookingType.find(type => type.id === selectedBookingTypeId)?.name}
                </div>

            </div>
            <BookingTimePage
                visible={isTimeModalOpen}
                onClose={handleCloseTimeModal}
                onConfirm={handleConfirmTime}
                salonServiceId={id}
            />

            <BookingStaffPage
                visible={isStaffModalOpen}
                onClose={handleCloseStaffModal}
                onConfirm={(staff) => setSelectedStaff(staff)}  // Nhận staffId từ BookingStaffPage
                salonServiceId={id}
                date={selectedDate}
                timeId={selectedTime?.id}
            />


        </Content>
    );
}

export default BookingPage;