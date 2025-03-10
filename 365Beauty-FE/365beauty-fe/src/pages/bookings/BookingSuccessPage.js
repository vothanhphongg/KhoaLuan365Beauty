import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import "../../styles/BookingSuccessPage.css";
import { CheckCircleOutlined } from '@ant-design/icons';
import { getDetailUserBooking } from '../../apis/users/userBooking';
const BookingSuccessPage = () => {
    const navigate = useNavigate();
    const userInfo = JSON.parse(localStorage.getItem('userInfo'));
    const [data, setData] = useState({});
    const { id } = useParams();

    useEffect(() => {
        const fetchSalonServiceDetail = async () => {
            const response = await getDetailUserBooking(id);
            setData(response.data);
        };
        fetchSalonServiceDetail();
    }, [id]);
    console.log(data);
    return (
        <div className='content-booking-success'>
            <div className='container-booking-success'>
                <div>
                    <CheckCircleOutlined className='icon-success' />
                </div>
                <h2>Thanh toán thành công</h2>
                <hr style={{ margin: '10px 200px' }} />
                <h3>Thông tin đặt lịch</h3>
                <p>{userInfo.FullName}</p>
                <p>{userInfo.Tel}</p>
                <p>{userInfo.Email}</p>
                <p>Thời gian: {data.time?.times}</p>
                <hr style={{ margin: '10px 200px' }} />
                <h3>Phương thức thanh toán</h3>
                <p>{data.bookingType?.name}</p>
                <p style={{ marginTop: 30, fontWeight: 500 }}>Cảm ơn bạn đã đặt lịch. Chúng tôi sẽ liên hệ với bạn sớm nhất có thể.</p>
            </div>
            <div className='button-back-home' onClick={() => navigate(`/`)}> Quay lại trang chủ </div>
        </div>
    );
};

export default BookingSuccessPage;