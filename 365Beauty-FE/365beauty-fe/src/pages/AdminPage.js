import React, { useEffect, useState } from 'react';
import { Layout, Flex, Avatar } from 'antd';
import { MenuMain } from '../components/Menu';
import { Logo365Beauty, ChuyenHuong } from '../components/Text';
import { Outlet, useNavigate } from 'react-router-dom';

const { Header, Content, Footer, Sider } = Layout;

const MainPage = () => {
    const navigate = useNavigate();
    const [userInfo, setUserInfo] = useState(null);
    useEffect(() => {
        const storedUserInfo = localStorage.getItem('userInfo');
        console.log(storedUserInfo);
        if (storedUserInfo) {
            const userInfo = JSON.parse(storedUserInfo);
            setUserInfo(userInfo);
        }
    }, []);

    const menuClick = ({ key }) => {
        switch (key) {
            case 'service-catalog':
                navigate('/admin/service-catalog');
                break;
            case 'beauty-salon-catalog':
                navigate('/admin/beauty-salon-catalog');
                break;
            case 'beauty-salon-services':
                navigate('/admin/beauty-salon-services');
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
            default:
                break;
        }
    };

    return (
        <Layout>
            <Sider width={'250px'} style={{ backgroundColor: 'white', position: 'fixed', height: '100vh', left: 0, top: 0, zIndex: 1000, overflow: 'auto' }}>
                <Flex style={{ justifyContent: 'center', alignItems: 'center', flexDirection: 'column', margin: '6px 0px 10px', borderBottom: '1.5px gray solid', height: '58px' }}>
                    <Logo365Beauty />
                </Flex>
                <Flex style={{ justifyContent: 'center', alignItems: 'center' }}>
                    <ChuyenHuong style={{ color: 'black', fontSize: '1.3rem' }} locate={'/admin'} button={'ADMIN'} />
                </Flex>
                <MenuMain menuClick={menuClick} />
            </Sider>
            <Layout style={{ marginLeft: '250px' }}>
                <Header style={{ borderBottom: '1.5px gray solid', position: 'fixed', width: 'calc(100% - 250px)', zIndex: 999, backgroundColor: 'white', display: 'flex', justifyContent: 'right' }} >
                    {userInfo && (
                        <>
                            <Avatar src={require(`../assets/${userInfo?.Img}`)} size="large" style={{ margin: '10px' }} />
                            <h3 style={{ fontSize: '1rem' }}> {userInfo?.FullName} </h3>
                        </>
                    )}
                </Header>
                <Content style={{ margin: '80px 16px 0', minHeight: '70vh' }}>
                    <Outlet />
                </Content>
                <Footer style={{ textAlign: 'center' }}>
                    Ant Design ©{new Date().getFullYear()} Created by Ant UED
                </Footer>
            </Layout>
        </Layout>
    );
};

export default MainPage;