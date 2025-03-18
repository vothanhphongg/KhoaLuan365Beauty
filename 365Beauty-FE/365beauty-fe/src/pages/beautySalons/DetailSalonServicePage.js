import React, { useEffect, useState } from 'react';
import { Layout } from 'antd';
import { useNavigate, useParams } from 'react-router-dom';
import '../../styles/DetailSalonServicePage.css';
import { getDetailBeautySalonService } from '../../apis/beautySalons/beautySalonService';
import { useUserRatingData } from '../../hooks/users/UserRatingData';
import { useBountUserBookingBySalonServiceIdData } from '../../hooks/users/UserBookingData';

const { Content } = Layout;
const DetailSalonServicePage = () => {
    const navigate = useNavigate();
    const [data, setData] = useState({});
    const { id } = useParams();

    const userInfo = JSON.parse(sessionStorage.getItem('userInfo'));
    const comments = useUserRatingData(id);
    const serviceCount = useBountUserBookingBySalonServiceIdData(id);
    console.log(serviceCount)

    useEffect(() => {
        const fetchSalonServiceDetail = async () => {
            const response = await getDetailBeautySalonService(id);
            setData(response.data);
        };
        fetchSalonServiceDetail();
    }, [id]);

    const averageRating = comments.length > 0
        ? (comments.reduce((sum, c) => sum + c.count, 0) / comments.length).toFixed(1)
        : 5;

    // Hàm render 5 ngôi sao
    const renderStars = (rating) => {
        return (
            <div className="star-rating">
                {[...Array(5)].map((_, index) => (
                    <span key={index} style={{ color: index < rating ? 'gold' : 'lightgray', fontSize: 18 }}>
                        ★
                    </span>
                ))}
            </div>
        );
    };

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
                        {averageRating ?? 5}⭐ | {serviceCount.count ?? 0} đã bán
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
                        <button onClick={() => navigate(`/detailsaloncatalog/${data.salonId}`)}>Xem chi tiết</button>
                    </div>
                    <div className='button-booking' onClick={() => {
                        if (userInfo) {
                            navigate(`/booking/${data.id}`);
                        } else {
                            navigate('/login');
                        }
                    }}>Đặt lịch hẹn</div>
                </div>
            </div>
            <div className="container-detail-salon-service-description">
                <h2>Mô tả dịch vụ</h2>
                <p>{data.description}</p>
            </div>
            <div className="container-detail-salon-service-description">
                <h2>Bình luận</h2>
                <hr />
                {comments.map((item) => (
                    <div className='container-comment'>
                        <div className='comment-avatar'>
                            <img src={require(`../../assets/${item.img ?? 'defaultAvatar.png'}`)} alt="Avatar" />
                            <div>
                                <p style={{ fontSize: 16, fontWeight: 600, marginLeft: 20 }}>{item.fullName} -
                                    <span style={{ fontWeight: 400 }}>{new Date(item.createdDate).toLocaleDateString('vi-VN')}</span>
                                </p>
                                <div style={{ marginLeft: 20 }}>
                                    {renderStars(item.count)}
                                </div>
                            </div>
                        </div>
                        <p style={{ marginLeft: 20 }}>{item.comment}</p>
                    </div>
                ))}
            </div>
        </Content>
    );
}

export default DetailSalonServicePage;
