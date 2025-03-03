// NotFoundPage.jsx
import React, { useEffect, useState } from 'react';
import { Layout, Input, Card, Button } from 'antd';
import { useNavigate } from 'react-router-dom';
import { useParams } from 'react-router-dom';
import '../../styles/BookingPage.css';
import { getDetailBeautySalonService } from '../../apis/beautySalons/beautySalonService';
import { ClockCircleOutlined, UserOutlined } from '@ant-design/icons';

const { Content } = Layout;
const BookingPage = () => {
    const navigate = useNavigate();
    const [data, setData] = useState({});
    const { id } = useParams();

    const userInfo = JSON.parse(localStorage.getItem('userInfo'));
    console.log(userInfo);
    useEffect(() => {
        const fetchSalonServiceDetail = async () => {
            const response = await getDetailBeautySalonService(id);
            console.log(response.data);
            setData(response.data);
        };
        fetchSalonServiceDetail();
    }, [id]);


    return (
        <Content className='content-booking'>
            <div className='info-transaction'>
                <div className='header-info'><h2>Thông tin thanh toán</h2></div>
                <div className='detail-info'>
                    <p>Người đặt lịch: {userInfo.FullName}.</p>
                    <p>Số điện thoại: {userInfo.Tel}.</p>
                    <p>Email: {userInfo.Email}.</p>
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
                        <span><ClockCircleOutlined style={{ marginRight: '10px' }} />Vui lòng chọn thời gian<button className='booking-time-button'>Chọn thời gian &gt;</button></span>
                    </div>
                    <div className='booking-staff'>
                        <span><UserOutlined style={{ marginRight: '10px' }} />Chọn nhân viên (Có thể không chọn)<button className='booking-time-button'>Chọn nhân viên &gt;</button></span>
                    </div>
                    <div className='booking-description'>
                        <label>Ghi chú</label>
                        <Input.TextArea name='content' placeholder='Ghi chú: Thông tin liên quan đến lịch hẹn,.......' autoSize={{ minRows: 5 }} />
                    </div>
                    <div className='booking-transaction'>
                        <p>Phương thức thanh toán</p>
                        <div className="booking-transaction-image">
                            <img src={require(`../../assets/06ncktiwd6dc1694418196384.png`)} alt={data.name} className="salon-logo" />
                            <p>Thanh toán qua VNPAY </p>
                        </div>
                    </div>
                </div>
                <div className='button-confirm-booking'>Thanh toán và đặt lịch hẹn</div>
            </div>
        </Content>
    );
}

export default BookingPage;
