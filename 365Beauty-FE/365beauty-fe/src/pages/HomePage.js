import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Layout, Carousel, Card } from 'antd';
import '../App.css';
import '../styles/BeautyContent.css';
import BannerHome1 from '../assets/BannerHome1.3cd36b.png';
import BannerHome2 from '../assets/BannerHome2.f4abb3.png';
import { TextPanel } from '../components/Text';
import useBeautySalonCatalogData from '../hooks/beautySalons/beautySalonCatalogData';
import useServiceCatalogData from '../hooks/services/ServiceCatalogData';
import useBeautySalonServiceData from '../hooks/beautySalons/beautySalonServiceData';

const { Content } = Layout;

const HomePage = () => {
    const navigate = useNavigate();
    const { data: salons } = useBeautySalonCatalogData();
    const { data: services } = useServiceCatalogData();
    const salonServices = useBeautySalonServiceData();
    return (
        <Content>
            <div className='baner'>
                {<div className="service-menu">
                    {services.map((service) => (
                        <button key={service.id} className="service-button">
                            <img src={require(`../assets/${service.icon}`)} alt={service.name} className="service-icon" />
                            <h3>
                                Đặt lịch
                                <br />
                                {service.name}
                            </h3>
                        </button>
                    ))}
                </div>}
                <Carousel autoplay>
                    <div className="image-carousel">
                        <img src={BannerHome1} alt="Slide 1" className="carousel-image" />
                        <TextPanel />
                    </div>
                    <div className="image-carousel">
                        <img src={BannerHome2} alt="Slide 2" className="carousel-image" />
                        <TextPanel />
                    </div>
                </Carousel>
            </div>
            <div className='container'>
                <div style={{ marginTop: '10px', }}>
                    <span style={{ fontSize: '1.5rem', fontWeight: '500', color: ' rgb(75, 75, 75)', display: 'flex', justifyContent: 'space-between' }}>
                        Dịch vụ
                        <a href="javascript:void(0);" style={{ fontSize: '1rem', color: '#c41c8b' }}>
                            Xem tất cả &gt;
                        </a>                    </span>
                    <hr className='hr' style={{ marginTop: 10 }} />
                </div>
                <div className="card-container">
                    {salonServices.slice(0, 5).map((salonService) => (
                        <Card
                            key={salonService.id}
                            className="custom-card"
                            style={{ margin: '20px 5px' }}
                            cover={
                                <div className="card-image-container">
                                    <div className="discount-badge">{salonService.precentDiscount}%</div>
                                    <img className="card-image" alt={salonService.name} src={require(`../assets/${salonService.image}`)} />
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
            <div className='container'>
                <div style={{ marginTop: '10px', }}>
                    <span style={{ fontSize: '1.5rem', fontWeight: '500', color: ' rgb(75, 75, 75)', display: 'flex', justifyContent: 'space-between' }}>
                        Cơ sở làm đẹp
                        <a href="javascript:void(0);" style={{ fontSize: '1rem', color: '#c41c8b' }}>
                            Xem tất cả &gt;
                        </a>
                    </span>
                    <hr className='hr' style={{ marginTop: 10 }} />

                </div>
                <div className="card-container">
                    {salons.slice(0, 4).map((salon) => (
                        <Card
                            key={salon.id}
                            className="custom-card"
                            cover={
                                <div className="card-image-container">
                                    <img className="card-image" alt={salon.name} src={require(`../assets/${salon.image}`)} />
                                </div>
                            }
                        >
                            <Card.Meta
                                title={<span className="card-title">{salon.name}</span>}
                                description={salon.addressFullAscending}
                            />
                        </Card>

                    ))}
                </div>
            </div>
        </Content>
    );
};

export default HomePage;
