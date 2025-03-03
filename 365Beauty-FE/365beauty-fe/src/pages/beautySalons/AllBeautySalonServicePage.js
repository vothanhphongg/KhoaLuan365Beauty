import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Card } from 'antd';
import '../../styles/AllBeautySalonServicePage.css';
import { useBeautySalonServiceWithPriceData } from '../../hooks/beautySalons/beautySalonServiceData';

const AllBeautySalonServicePage = () => {
    const navigate = useNavigate();
    const services = useBeautySalonServiceWithPriceData();
    console.log(services);

    return (
        <div>
            <span style={{ fontSize: '1.5rem', fontWeight: '500', color: ' rgb(75, 75, 75)', paddingLeft: 10 }}>
                Tất cả dịch vụ
            </span>
            <div className="all-service-card">
                {services.map((salonService) => (
                    <Card
                        key={salonService.id}
                        className="all-service-custom-card"
                        cover={
                            <div className="card-image-container">
                                <div className="discount-badge">{salonService.precentDiscount}%</div>
                                <img className="card-image" alt={salonService.name} src={require(`../../assets/${salonService.image}`)} />
                            </div>
                        }
                        onClick={() => navigate(`/detailsalonservice/${salonService.id}`)}
                    >
                        <Card.Meta
                            title={<span className="card-title">{salonService.name}</span>}
                            description={<span className="final-price">{salonService.finalPrice.toLocaleString('vi-VN')}đ</span>}
                        />
                        <span className="base-price">{salonService.basePrice.toLocaleString('vi-VN')}đ</span>
                    </Card>
                ))}
            </div>
        </div>
    );
};

export default AllBeautySalonServicePage;
