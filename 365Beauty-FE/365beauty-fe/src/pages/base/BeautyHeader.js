import React, { useEffect, useState } from 'react';
import { Layout, Flex, message } from 'antd';
import { useNavigate } from 'react-router-dom';
import '../../styles/BeautyHeader.css';
import '../../App.css';
import { Logo365Beauty } from '../../components/Text';
import { DropdownMenuProfile } from '../../components/Menu';
import { Search } from '../../components/Input';
import { ButtonAuthHome } from '../../components/Button';

const { Header } = Layout;

function BeautyHeader() {
    const navigate = useNavigate();
    const [userInfo, setUserInfo] = useState(null);
    const [isLoggedIn, setIsLoggedIn] = useState(false);
    const [isAdmin, setIsAdmin] = useState(false);
    const [isBeautySalon, setIsBeautySalon] = useState(false);

    // Lấy thông tin người dùng từ localStorage
    useEffect(() => {
        const userToken = localStorage.getItem('userToken');
        const userInfo = JSON.parse(localStorage.getItem('userInfo'));
        if (userToken && userInfo) {
            setUserInfo(userInfo);
            setIsLoggedIn(true);
            const userRoles = userInfo.UserRoles || [];
            setIsAdmin(userRoles.some(role => role.name === 'ADMIN'));
            setIsBeautySalon(userRoles.some(role => role.name === 'BEAUTY_SALON'));
        }
    }, []);

    const handleMenuClick = ({ key }) => {
        switch (key) {
            case 'profile':
                navigate(`/profile/${userInfo.Id}`); // Điều hướng đến thông tin tài khoản
                break;
            case 'transactions':
                navigate('/transactions'); // Điều hướng đến lịch sử giao dịch
                break;
            case 'appointments':
                navigate('/appointments'); // Điều hướng đến lịch hẹn
                break;
            case 'admin':
                navigate('/admin');
                break;
            case 'beauty-salon':
                navigate('/beauty-salon');
                break;
            case 'logout':
                localStorage.removeItem('userToken');
                localStorage.removeItem('userInfo');
                setUserInfo(null);
                setIsLoggedIn(false);
                setIsAdmin(false);
                message.success('Đã đăng xuất');
                navigate('/');
                break;
            default:
                break;
        }
    };

    return (
        <Header className="header" style={{ display: 'flex', alignItems: 'center', justifyContent: 'space-between' }}>
            {/* Logo */}
            <Flex style={{ width: '20%' }}>
                <Logo365Beauty />
            </Flex>
            <Search />

            {/* Nút điều hướng và menu */}
            <div style={{ width: '20%', display: 'flex', justifyContent: 'flex-end', alignItems: 'center' }}>
                {isLoggedIn ? (
                    <DropdownMenuProfile
                        userInfo={userInfo}
                        isAdmin={isAdmin}
                        isBeautySalon={isBeautySalon}
                        handleMenuClick={handleMenuClick}
                    />
                ) : (
                    <>
                        <ButtonAuthHome style={{ backgroundColor: '#c41c8b', color: 'white', padding: '0 20px', }} text={'Đăng ký'} onClick={() => navigate('/register')} />
                        <ButtonAuthHome style={{ color: 'black', padding: '0 15px', }} text={'Đăng nhập'} onClick={() => navigate('/login')} />
                    </>
                )}
            </div>
        </Header>
    );
}

export default BeautyHeader;
