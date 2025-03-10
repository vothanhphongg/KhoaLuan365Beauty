import React from 'react';
import { Layout } from 'antd';
import { MenuBeautySalon } from '../../components/Menu';
import { Outlet, useNavigate } from 'react-router-dom';
import BeautyHeader from './BeautyHeader';

const { Content, Sider } = Layout;

const BeautySalonPage = () => {
    const navigate = useNavigate();
    const userInfo = JSON.parse(localStorage.getItem('userInfo'));
    const menuClick = ({ key }) => {
        switch (key) {
            case 'beauty-salon':
                navigate('/beauty-salon');
                break;
            case 'salon-services':
                navigate(`/beauty-salon/salon-services/${userInfo.SalonId}`);
                break;
            case 'staff-services':
                navigate(`/beauty-salon/staff-services/${userInfo.SalonId}`);
                break;
            case 'price-services':
                navigate(`/beauty-salon/price-services/${userInfo.SalonId}`);
                break;
            case 'confirm-services':
                navigate(`/beauty-salon/confirm-services/${userInfo.SalonId}`);
                break;
            case 'stats-salon-service':
                navigate('/beauty-salon/stats-salon-service');
                break;
            default:
                break;
        }
    };

    return (
        <Layout>
            <BeautyHeader />
            <Sider width={'260px'} style={{ backgroundColor: 'white', paddingTop: 10, position: 'fixed', height: '85vh', left: 0, top: '10%', overflow: 'auto' }}>
                <MenuBeautySalon menuClick={menuClick} />
            </Sider>
            <Layout style={{ marginLeft: '250px' }}>
                <Content style={{ margin: '80px 15px 0px', minHeight: '70vh' }}>
                    <Outlet />
                </Content>
            </Layout>
        </Layout>
    );
};

export default BeautySalonPage;