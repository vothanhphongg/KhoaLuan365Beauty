import React from 'react';
import { Form, Input as AntInput } from 'antd';
import '../styles/component.css';

export const Input = ({ label, placeholder, name, type, errorMessage }) => {
    return (
        <Form.Item label={label} name={name} style={{ fontWeight: 500, margin: 3 }} validateStatus={errorMessage ? 'error' : ''} help={errorMessage || ''}>
            <AntInput placeholder={placeholder} type={type} size="large" />
        </Form.Item >
    );
};