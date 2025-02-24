import React from 'react';
import { Button } from 'antd';
import '../styles/component.css';

export const ButtonAuth = ({ text }) => {
    return (
        <Button type="primary" htmlType="submit" style={{
            backgroundColor: '#c41c8b',
            border: '1px solid #c41c8b',
            color: '#fff',
            padding: '20px 0px',
            margin: '20px 0px',
            width: '100%',
            fontWeight: 500,
            fontSize: '1.1rem'
        }}>
            {text}
        </Button>
    );
};

export const ButtonAuthHome = ({ text, style, onClick }) => {
    return (
        <Button
            className="Button"
            style={{
                border: '1px solid #c41c8b',
                color: 'white',
                margin: '0 5px',
                ...style
            }}
            onClick={onClick}
        >
            {text}
        </Button>
    );
};
