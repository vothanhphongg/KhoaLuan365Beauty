// NotFoundPage.jsx
import React, { useEffect, useState } from 'react';
import { Row, Col } from 'antd';
import { useNavigate } from 'react-router-dom';
import { useParams } from 'react-router-dom';
import '../../styles/ProfilePage.css';
import { EditOutlined } from '@ant-design/icons';
import { GetDetailUserInformation } from '../../apis/users/userInformation';
import { getDetailStaffCatalog } from '../../apis/staffs/staffCatalog';
const InfoProfilePage = () => {
    const navigate = useNavigate();
    const [data, setData] = useState({});
    const { id } = useParams();
    const userInfo = JSON.parse(sessionStorage.getItem('userInfo'));
    useEffect(() => {
        const fetchUserInfoDetail = async () => {
            if (userInfo.UserRoles.some(role => role.name === 'BEAUTY_SALON')) {
                // Gọi API GetDetailStaffCatalog nếu role là beautysalon
                const response = await getDetailStaffCatalog(id);
                setData(response.data);
            } else {
                // Gọi API GetDetailUserInformation nếu role khác
                const response = await GetDetailUserInformation(id);
                setData(response.data);
            }
        };
        fetchUserInfoDetail();
    }, [id, userInfo?.Role]);

    return (
        <div className='right-container-user-info'>
            <div className='header-right-container'>
                <h2>Hồ sơ</h2>
                <a onClick={() => navigate(`/edit-profile/${id}`)}><EditOutlined style={{ marginRight: '5px' }} />Chỉnh sửa hồ sơ</a>
            </div>
            <div className='right-container-avatar-user-info'>
                <img src={require(`../../assets/${userInfo.Img ?? 'defaultAvatar.png'}`)} alt={data.lastName} />
                <div className='right-name-user-info'>
                    <p>{userInfo.FullName}</p>
                    <p style={{ color: '#22a90d', fontWeight: 400 }}>{userInfo.Tel}</p>
                </div>
            </div>
            <div className='right-user-detail-information'>
                <Row gutter={16}>
                    <Col span={12} style={{ padding: '5px 30px 15px 5px' }}>
                        <label style={{ fontSize: '14px' }}>Họ và tên</label>
                        <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{userInfo.FullName}</p>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                    </Col>
                    <Col span={12} style={{ padding: '5px 30px 15px 5px' }}  >
                        <label style={{ fontSize: '14px' }}>Email</label>
                        <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{userInfo.Email}</p>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12} style={{ padding: '5px 30px 15px 5px' }}>
                        <label style={{ fontSize: '14px' }}>Số điện thoại</label>
                        <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{userInfo.Tel}</p>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                    </Col>
                    <Col span={12} style={{ padding: '5px 30px 15px 5px' }}  >
                        <label style={{ fontSize: '14px' }}>Giới tính</label>
                        <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>
                            {data.gender === 1 ? 'Nam' : data.gender === 2 ? 'Nữ' : '--'}
                        </p>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12} style={{ padding: '5px 30px 15px 5px' }}>
                        <label style={{ fontSize: '14px' }}>Ngày sinh</label>
                        <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>
                            {data?.dateOfBirth ? new Date(data.dateOfBirth).toLocaleDateString('vi-VN') : '--'}
                        </p>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12} style={{ padding: '5px 30px 15px 5px' }}>
                        <label style={{ fontSize: '14px' }}>Căn cước công nhân</label>
                        <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.idCard ?? '--'}</p>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                    </Col>
                    <Col span={12} style={{ padding: '5px 30px 15px 5px' }}>
                        <label style={{ fontSize: '14px' }}>Địa chỉ</label>
                        <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.address ?? '--'}</p>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={8} style={{ padding: '5px 30px 15px 5px' }}>
                        <label style={{ fontSize: '14px' }}>Tỉnh/Thành phố</label>
                        <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.provinceName ?? '--'}</p>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                    </Col>
                    <Col span={8} style={{ padding: '5px 30px 15px 5px' }}>
                        <label style={{ fontSize: '14px' }}>Quận/Huyện</label>
                        <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.districtName ?? '--'}</p>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                    </Col>
                    <Col span={8} style={{ padding: '5px 30px 15px 5px' }}>
                        <label style={{ fontSize: '14px' }}>Phường/Xã</label>
                        <p style={{ fontSize: '18px', fontWeight: 400, margin: '10px 0px' }}>{data.wardName ?? '--'}</p>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                    </Col>
                </Row>
            </div>
        </div>
    );
}

export default InfoProfilePage;
