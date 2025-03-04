import React from 'react';
import { Layout } from 'antd';
import { MenuMain } from '../../components/Menu';
import { Outlet, useNavigate } from 'react-router-dom';
import BeautyHeader from './BeautyHeader';

const { Content, Sider } = Layout;

const MainPage = () => {
    const navigate = useNavigate();

    const menuClick = ({ key }) => {
        switch (key) {
            case 'admin':
                navigate('/admin');
                break;
            case 'service-catalog':
                navigate('/admin/service-catalog');
                break;
            case 'beauty-salon-catalog':
                navigate('/admin/beauty-salon-catalog');
                break;
            case 'beauty-salon-services':
                navigate('/admin/beauty-salon-services');
                break;
            case 'beauty-salon-staffs':
                navigate('/admin/beauty-salon-staffs');
                break;
            case 'degree-catalog':
                navigate('/admin/degree-catalog');
                break;
            case 'title-catalog':
                navigate('/admin/title-catalog');
                break;
            case 'occupation-catalog':
                navigate('/admin/occupation-catalog');
                break;
            case 'user-account':
                navigate('/admin/user-account');
                break;
            case 'booking-type':
                navigate('/admin/booking-type');
                break;
            case 'time':
                navigate('/admin/time');
                break;
            default:
                break;
        }
    };

    return (
        <Layout>
            <BeautyHeader />
            <Sider width={'260px'} style={{ backgroundColor: 'white', paddingTop: 10, position: 'fixed', height: '90vh', left: 0, top: '10%', overflow: 'auto' }}>
                <MenuMain menuClick={menuClick} />
            </Sider>
            <Layout style={{ marginLeft: '250px' }}>
                <Content style={{ margin: '80px 15px 0px', minHeight: '70vh' }}>
                    <Outlet />
                </Content>
            </Layout>
        </Layout>
    );
};

export default MainPage;