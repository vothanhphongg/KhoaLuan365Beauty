import React, { useEffect, useState } from 'react';
import { Layout, Card } from 'antd';
import { useNavigate, useParams } from 'react-router-dom';
import '../../styles/DetailSalonCatalogPage.css';
import { getDetailBeautySalonCatalog } from '../../apis/beautySalons/beautySalonCatalog';

const { Content } = Layout;
const DetailSalonCatalogPage = () => {
    const navigate = useNavigate();
    const [data, setData] = useState({});
    const { id } = useParams();


    useEffect(() => {
        const fetchSalonServiceDetail = async () => {
            const response = await getDetailBeautySalonCatalog(id);
            setData(response.data);
        };
        fetchSalonServiceDetail();
    }, [id]);

    return (
        <Content className="content-detail-salon">
            <div className="header-detail-salon">
                <div style={{ display: 'flex', alignItems: 'center', marginBottom: 10 }}>
                    <img src={require(`../../assets/${data.image ?? 'defaultAvatar.png'}`)} alt={data.name} className="header-detail-salon-image" />
                    <h2 style={{ fontSize: '30px', fontWeight: 500 }}>{data.name}</h2>
                </div>
                <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                    <p style={{ fontSize: '18px', textDecoration: 'underline' }}>{data.addressFullAscending} </p>
                    <p style={{ fontSize: '18px', fontWeight: 500 }}>Thời gian làm việc: <span style={{ fontSize: '18px', fontWeight: 400 }}>{data.workingDate}.</span></p>
                </div>

            </div>
            {(data?.beautySalonImages?.length > 0 ? (
                <div className='container-image-detail-salon'>
                    <div className='container-main-image'>
                        <img
                            src={require(`../../assets/${data.beautySalonImages[0]?.imageUrl ?? 'defaultAvatar.png'}`)}
                            alt={data.name}
                            className="main-image"
                        />
                    </div>

                    <div className='container-other-image'>
                        {data.beautySalonImages.slice(1, 5).map((image, index) => (
                            <img
                                key={index}
                                src={require(`../../assets/${image?.imageUrl ?? 'defaultAvatar.png'}`)}
                                alt={data.name}
                                className="main-image"
                            />
                        ))}
                    </div>
                </div>
            ) : (
                <div className='container-image-detail-salon'>
                    <div className='container-main-image'>
                        <img
                            src={require(`../../assets/${data.image ?? 'defaultAvatar.png'}`)}
                            alt={data.name}
                            className="main-image"
                        />
                    </div>
                </div>
            ))}
            <div className="detail-salon-info">
                <h2>Thông tin chi tiết</h2>
                <p>Email: {data.email}</p>
                <p>Số điện thoại tư vấn: {data.tel}</p>
                <p>Website: {data.website}</p>
            </div>
            <div className="detail-salon-info">
                <h2>Dịch vụ thẩm mỹ</h2>
                <div className="detail-salon-service-card">
                    {data.beautySalonServices?.map((service) => (
                        <Card
                            key={service.id}
                            className="detail-salon-service-custom-card"
                            cover={
                                <div className="card-image-container">
                                    <div className="discount-badge">{service.precentDiscount}%</div>
                                    <img className="card-image" alt={service.name} src={require(`../../assets/${service.image}`)} />
                                </div>
                            }
                            onClick={() => navigate(`/detailsalonservice/${service.id}`)}
                        >
                            <Card.Meta
                                title={<span className="card-title">{service.name}</span>}
                                description={<span className="final-price">{service.finalPrice.toLocaleString('vi-VN')}đ</span>}
                            />
                            <span className="base-price">{service.basePrice.toLocaleString('vi-VN')}đ</span>
                        </Card>
                    ))}
                </div>
            </div>
            <div className="detail-salon-info">
                <h2>Nhân viên thẩm mỹ</h2>
                <div className="detail-salon-service-card">
                    {data.staffCatalogs?.map((staff) => (
                        <Card
                            key={staff.id}
                            className="detail-salon-service-custom-card"
                            cover={
                                <div className="card-image-container">
                                    <img className="card-image" alt={staff.name} src={require(`../../assets/${staff.img ?? 'defaultAvatar.png'}`)} />
                                </div>
                            }
                            onClick={() => navigate(`/detailsalonservice/${staff.id}`)}
                        >
                            <Card.Meta
                                title={<span className="card-title">{staff.fullName}</span>}
                            />
                        </Card>
                    ))}
                </div>
            </div>
            <div className="detail-salon-info">
                <h2>Mô tả dịch vụ</h2>
                <p>{data.description}</p>
            </div>
        </Content >
    );
}

export default DetailSalonCatalogPage;
