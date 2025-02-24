// NotFoundPage.jsx
import React, { useEffect, useState } from 'react';
import { Layout, Carousel, Card } from 'antd';
import { useNavigate } from 'react-router-dom';
import { useParams } from 'react-router-dom';
import '../../styles/DetailSalonServicePage.css';
import { getDetailBeautySalonService } from '../../apis/beautySalons/beautySalonService';

const { Content } = Layout;
const DetailSalonServicePage = () => {
    const navigate = useNavigate();
    const [data, setData] = useState({});
    const { id } = useParams();


    useEffect(() => {
        const fetchSalonServiceDetail = async () => {
            const response = await getDetailBeautySalonService(id);
            console.log(response.data);
            setData(response.data);
        };
        fetchSalonServiceDetail();
    }, [id]);


    return (
        <Content className="content-detail-salon-service">
            <div className="container-detail-salon-service">
                {/* Hình ảnh bên trái */}
                <div>
                    <img
                        src={require(`../../assets/${data.image ?? 'defaultAvatar.png'}`)}
                        alt={data.name}
                        className="image-detail-salon-service"
                    />
                </div>

                {/* Thông tin bên phải */}
                <div className="container-service-info">
                    <span>Loại: <a> {data.serName} </a></span>
                    <h1>{data.name}</h1>
                    <div className="rating">
                        {data.rating ?? 5}⭐ | {data.count ?? 0} đã bán
                    </div>
                    <div className="price">
                        <div className='precent-discount'>{data.precentDiscount}%</div>
                        <div className="service-final-price">{(data.finalPrice ?? 0).toLocaleString('vi-VN')}đ</div>
                        <div className="service-base-price">{(data.basePrice ?? 0).toLocaleString('vi-VN')}đ</div>
                    </div>
                    <div className="salon-info">
                        <img src={require(`../../assets/${data.slnImage ?? 'defaultAvatar.png'}`)} alt="Salon Logo" className="salon-logo" />
                        <div>
                            <h3>{data.slnName}</h3>
                            <p>{data.addressFullAscending}</p>
                            <p>📍 10km</p>
                        </div>
                        <button>Xem chi tiết</button>
                    </div>
                    <div className='button-booking' onClick={() => navigate(`/booking/${data.id}`)}>Đặt lịch hẹn</div>
                </div>
            </div>
            <div className="container-detail-salon-service-description">
                <h2>Mô tả dịch vụ</h2>
                <p>{data.description}</p>
            </div>
        </Content>
    );
}

export default DetailSalonServicePage;
