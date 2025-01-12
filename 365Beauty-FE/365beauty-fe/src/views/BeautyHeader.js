import React from 'react';
import { Layout, Button, Flex, Input } from 'antd';
import { SearchOutlined } from '@ant-design/icons';
import { useNavigate } from 'react-router-dom';
import '../styles/BeautyHeader.css';
import '../App.css';
import { Logo365Beauty } from '../components/Text';

const { Header } = Layout;

function BeautyHeader() {
    const navigate = useNavigate();

    const handleRegisterClick = () => {
        navigate('/register'); // Điều hướng đến trang đăng ký
    };

    return (
        <Header className="header">
            <Flex style={{ width: '20%' }}>
                <Logo365Beauty />
            </Flex>
            <Input
                className="Search"
                size="large"
                placeholder="Tìm kiếm trên 365Beauty"
                prefix={<SearchOutlined />}
            />
            <Flex wrap="wrap" gap="small" style={{ width: '20%' }}>
                <Button
                    className="Button"
                    style={{
                        backgroundColor: '#c41c8b',
                        border: '1px solid #c41c8b',
                        color: 'white',
                        padding: '17px 28px',
                        margin: '0px 5px',
                    }}
                    onClick={handleRegisterClick}
                >
                    Đăng ký
                </Button>
                <Button
                    className="Button"
                    style={{
                        border: '1px solid #c41c8b',
                        color: 'black',
                        padding: '17px 23px',
                        margin: '0px 5px',
                    }}
                >
                    Đăng nhập
                </Button>
            </Flex>
        </Header>
    );
}

export default BeautyHeader;
