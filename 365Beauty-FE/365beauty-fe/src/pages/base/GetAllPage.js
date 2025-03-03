import React from 'react';
import { Layout } from 'antd';
import { MenuAllPage } from '../../components/Menu';
import { ArrowLeftOutlined } from '@ant-design/icons';
import { Outlet, useNavigate } from 'react-router-dom';
import '../../styles/GetAllPage.css';

const { Content } = Layout;

const GetAllPage = () => {
    const navigate = useNavigate();

    const menuClick = ({ key }) => {
        switch (key) {
            case 'beauty-salons':
                navigate('beauty-salons');
                break;
            case 'salon-services':
                navigate('salon-services');
                break;
            case 'salon-staffs':
                navigate('salon-staffs');
                break;
            default:
                break;
        }
    };
    return (
        <Content className='all-content'>
            <div className='all-container-menu'>
                <MenuAllPage menuClick={menuClick} />
                <hr style={{ margin: 10 }} />
                <button onClick={() => navigate('/')}> <ArrowLeftOutlined style={{ marginRight: 10 }} />Quay lại</button>
            </div>
            <div className='all-container'>
                <Outlet />
            </div>
        </Content>

    );
};

export default GetAllPage;