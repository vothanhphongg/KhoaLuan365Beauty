import React from 'react';
import { Button } from 'antd';
import '../styles/component.css';

export const ButtonRegister = ({ label, placeholder, name, type }) => {
    return (
        <Button type="primary" htmlType="submit" style={{
            backgroundColor: '#c41c8b',
            border: '1px solid #c41c8b',
            color: '#fff',
            padding: '20px 0px',
            margin: '15px 0px',
            width: '100%',
            fontWeight: 500,
            fontSize: '1.1rem'
        }}>
            Đăng ký
        </Button>
    );
};