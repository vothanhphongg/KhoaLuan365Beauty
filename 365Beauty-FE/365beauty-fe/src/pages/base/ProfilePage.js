import React, { useEffect, useState } from 'react';
import { Layout, message } from 'antd';
import { Outlet, useNavigate, useParams } from 'react-router-dom';
import '../../styles/ProfilePage.css';
import { RubyOutlined, UserOutlined, CalendarOutlined, LogoutOutlined, LockOutlined } from '@ant-design/icons';
import { GetDetailUserInformation } from '../../apis/users/userInformation';
import { getDetailStaffCatalog } from '../../apis/staffs/staffCatalog';
import BeautyHeader from './BeautyHeader';

const { Content, Sider } = Layout;

const ProfilePage = () => {
    const navigate = useNavigate();
    const [data, setData] = useState({});
    const { id } = useParams();
    const [userInfo, setUserInfo] = useState(() => {
        const storedUserInfo = sessionStorage.getItem('userInfo');
        return storedUserInfo ? JSON.parse(storedUserInfo) : null;
    });
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [isAdmin, setIsAdmin] = useState(false);
    const [isBeautySalon, setIsBeautySalon] = useState(false);
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

    const handleLogout = () => {
        sessionStorage.removeItem('userToken');
        sessionStorage.removeItem('userInfo');
        setUserInfo(null);
        setIsLoggedIn(false);
        setIsAdmin(false);
        setIsBeautySalon(false);
        message.success('Đã đăng xuất');
        navigate('/');  // Điều hướng về trang chủ
    };
    return (
        userInfo && (
            <Content>
                <BeautyHeader />
                <div className='content-user-info'>
                    <div className='left-container-user-info'>
                        <div className='header-left-container'>
                            <div className='left-container-avatar-user-info'>
                                <div className='left-avatar-user-info'>
                                    <img src={require(`../../assets/${userInfo.Img ?? 'defaultAvatar.png'}`)} alt={data.lastName} />
                                </div>
                                <div className='left-name-user-info'>
                                    <p>{userInfo.FullName}</p>
                                    <p style={{ color: '#22a90d', fontWeight: 400 }}>{userInfo.Tel}</p>
                                </div>
                            </div>
                            <div className='member'><RubyOutlined style={{ marginRight: '5px' }} />Thành viên</div>
                        </div>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                        <div className='locate-user-info'>
                            <div onClick={() => navigate(`info-profile/${userInfo.Id}`)} className='locate'>
                                <UserOutlined style={{ marginRight: '10px', color: '#22a90d' }} />Hồ sơ của tôi
                            </div>
                            <div onClick={() => navigate(`user-booking/${userInfo.Id}`)} className='locate'>
                                <CalendarOutlined style={{ marginRight: '10px', color: 'red' }} />Lịch hẹn
                            </div>
                        </div>
                        <hr style={{ color: 'rgba(0, 0, 0, 0.2)' }} />
                        <div className='locate-user-info'>
                            <div className='locate'>
                                <LockOutlined style={{ marginRight: '10px', color: 'gray' }} />Thay đổi mật khẩu
                            </div>
                            <div onClick={handleLogout} className='locate'>
                                <LogoutOutlined style={{ marginRight: '10px', color: 'red' }} />Đăng xuất
                            </div>
                        </div>
                    </div>
                    <Outlet />
                </div>
            </Content>
        )
    );
};

export default ProfilePage;