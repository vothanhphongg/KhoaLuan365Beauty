import React from 'react';
import { Form, Input as AntInput } from 'antd';
import { SearchOutlined } from '@ant-design/icons';
import '../styles/component.css';

export const Input = ({ label, placeholder, name, type, errorMessage, size }) => {
    return (
        <Form.Item label={label} name={name} style={{ fontWeight: 500, margin: 3 }} validateStatus={errorMessage ? 'error' : ''} help={errorMessage || ''}>
            <AntInput placeholder={placeholder} type={type} size={size} />
        </Form.Item >
    );
};

export const TextAreaInput = ({ label, placeholder, name }) => {
    return (
        <Form.Item label={label} name={name} style={{ fontWeight: 500, margin: 3 }}>
            <AntInput.TextArea placeholder={placeholder} autoSize={{ minRows: 4 }} />
        </Form.Item>
    );
};


export const Search = ({ label, placeholder, name, type, errorMessage }) => {
    return (
        <AntInput
            className="Search"
            size="large"
            placeholder="Tìm kiếm trên 365Beauty"
            prefix={<SearchOutlined />}
            style={{ width: '50%' }}

        />
    );
};