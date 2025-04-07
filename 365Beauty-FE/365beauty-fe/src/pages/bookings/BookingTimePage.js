import React, { useState } from 'react';
import { Modal, Calendar, Button, List, Spin, message } from 'antd';
import moment from 'moment';
import { getAllBookingTimeByBookingDate } from '../../apis/bookings/booking';
import '../../styles/BookingTimePage.css';  // Import file CSS

const BookingTimePage = ({ visible, onClose, onConfirm, salonServiceId }) => {
    const [selectedDate, setSelectedDate] = useState(null);
    const [availableTimes, setAvailableTimes] = useState([]);
    const [selectedTime, setSelectedTime] = useState(null);
    const [loading, setLoading] = useState(false);

    // Hàm gọi API để lấy danh sách thời gian có sẵn
    const fetchAvailableTimes = async (date) => {
        setLoading(true);
        try {
            const response = await getAllBookingTimeByBookingDate({
                salonServiceId,
                bookingDate: `${date.year}-${String(date.month).padStart(2, '0')}-${String(date.day).padStart(2, '0')}`
            });
            setAvailableTimes(response.data); // Lưu toàn bộ dữ liệu trả về
        } catch (error) {
            message.error('Không thể tải thời gian có sẵn!');
        } finally {
            setLoading(false);
        }
    };

    // Khi chọn ngày, gọi API để lấy thời gian có sẵn
    const handleDateChange = (date) => {
        const selected = {
            day: date.date(),
            month: date.month() + 1,
            year: date.year()
        };
        setSelectedDate(selected);
        setSelectedTime(null);  // Reset thời gian đã chọn
        fetchAvailableTimes(selected);
    };

    // Giới hạn chọn ngày từ ngày hiện tại + 1 đến 7 ngày tới
    const disabledDate = (current) => {
        const tomorrow = moment().add(1, 'days').startOf('day');
        const sevenDaysLater = moment().add(7, 'days').endOf('day');
        return current.isBefore(tomorrow) || current.isAfter(sevenDaysLater);
    };

    // Khi chọn giờ
    const handleTimeSelect = (time) => {
        setSelectedTime(time);
    };

    // Xác nhận thời gian đặt
    const handleConfirm = () => {
        if (selectedDate && selectedTime) {
            onConfirm(selectedDate, selectedTime);
            onClose();
        } else {
            message.warning('Vui lòng chọn cả ngày và giờ!');
        }
    };

    return (
        <Modal
            open={visible}
            onCancel={onClose}
            footer={null} width={1000} style={{ top: '100px' }}
        >
            <div style={{ margin: '20px 0px 0px 20px', fontSize: '18px', fontWeight: 'bold' }}>
                {selectedDate
                    ? moment(`${selectedDate.year}-${selectedDate.month}-${selectedDate.day}`, "YYYY-MM-DD").format('DD/MM/YYYY')
                    : 'Vui lòng chọn ngày'}

            </div>
            <div className="booking-container">
                <Calendar
                    fullscreen={false}
                    onSelect={handleDateChange}
                    disabledDate={disabledDate}  // Áp dụng giới hạn ngày
                    headerRender={() => null}
                    className="custom-calendar"
                />
                {loading ? (
                    <Spin style={{ display: 'block', textAlign: 'center', margin: '20px 0' }} />
                ) : (
                    <div className="time-list">
                        {availableTimes.map((item) => (
                            <div
                                key={item.id}
                                className={`time-slot ${selectedTime?.id === item.id ? 'selected' : ''}`}
                                onClick={() => handleTimeSelect(item)}
                            >
                                {item.times}
                            </div>
                        ))}
                        <div className='confirm-time' type='button' onClick={handleConfirm}>Xác nhận thời gian</div>
                    </div>
                )}
            </div>
        </Modal>
    );
};

export default BookingTimePage;