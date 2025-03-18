// NotFoundPage.jsx
import React, { useEffect, useState } from 'react';
import { Layout, Row, Col } from 'antd';
import { useNavigate } from 'react-router-dom';
import '../../styles/HomeBeautySalonPage.css';
import { EditOutlined } from '@ant-design/icons';
import { getDetailBeautySalonCatalog } from '../../apis/beautySalons/beautySalonCatalog';

const { Content } = Layout;
const HomeBeautySalonPage = () => {
    const navigate = useNavigate();
    const [data, setData] = useState({});
    const userInfo = JSON.parse(sessionStorage.getItem('userInfo'));
    useEffect(() => {
        const fetchSalonServiceDetail = async () => {
            const response = await getDetailBeautySalonCatalog(userInfo.SalonId);
            console.log(response.data);
            setData(response.data);
        };
        fetchSalonServiceDetail();
    }, [userInfo.SalonId]);

    return (
        <Content className='content-info-beauty-salon'>
            <div className='container-info-beauty-salon'>
                <div className='header-right-container'>
                    <h2>Thông tin thẩm mỹ viện</h2>
                    <a><EditOutlined style={{ marginRight: '5px' }} />Chỉnh sửa thông tin thẩm mỹ viện</a>
                </div>
                <div className='right-container-avatar-user-info'>
                    <img src={require(`../../assets/${data.image ?? 'defaultAvatar.png'}`)} alt={data.name} />
                    <div className='right-name-user-info'>
                        <p>{data.name}</p>
                        <p style={{ color: '#22a90d', fontWeight: 400 }}>{data.tel}</p>
                        <p style={{ fontWeight: 400 }}>{data.addressFullAscending}</p>
                    </div>
                </div>
                <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                    {data.beautySalonImages?.slice(0, 5).map((image, index) => (
                        <div className='container-image-info-beauty-salon'>
                            <img
                                key={index}
                                src={require(`../../assets/${image?.imageUrl ?? 'defaultAvatar.png'}`)}
                                alt={data.name}
                                className="image-info-beauty-salon"
                            />
                        </div>
                    ))}
                </div>
                <div className='right-user-detail-information'>
                    <Row gutter={16}>
                        <Col span={12} style={{ padding: '5px 30px 15px 5px' }}>
                            <label style={{ fontSize: '14px' }}>Mã thẩm mỹ viện</label>
                            <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.code}</p>
                            <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                        </Col>
                        <Col span={12} style={{ padding: '5px 30px 15px 5px' }}  >
                            <label style={{ fontSize: '14px' }}>Tên thẩm mỹ viện</label>
                            <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.name}</p>
                            <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                        </Col>
                    </Row>
                    <Row gutter={16}>
                        <Col span={12} style={{ padding: '5px 30px 15px 5px' }}>
                            <label style={{ fontSize: '14px' }}>Số điện thoại</label>
                            <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.tel}</p>
                            <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                        </Col>
                        <Col span={12} style={{ padding: '5px 30px 15px 5px' }}  >
                            <label style={{ fontSize: '14px' }}>Email</label>
                            <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.email}</p>
                            <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                        </Col>
                    </Row>
                    <Row gutter={16}>
                        <Col span={12} style={{ padding: '5px 30px 15px 5px' }}>
                            <label style={{ fontSize: '14px' }}>Website</label>
                            <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.website}</p>
                            <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                        </Col>
                        <Col span={12} style={{ padding: '5px 30px 15px 5px' }}  >
                            <label style={{ fontSize: '14px' }}>Thời gian làm việc</label>
                            <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.workingDate}</p>
                            <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                        </Col>
                    </Row>
                    <Row gutter={16}>
                        <Col span={24} style={{ padding: '5px 30px 15px 5px' }}>
                            <label style={{ fontSize: '14px' }}>Mô tả</label>
                            <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.description}</p>
                            <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                        </Col>

                    </Row>
                </div>
            </div>
        </Content>
    );
}

export default HomeBeautySalonPage;
