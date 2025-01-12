import React from 'react';
import { Form, Radio } from 'antd';
import '../styles/component.css';

export const RadioButtonGender = ({ name }) => {
    return (
        <Form.Item label='Giới tính' name={name} style={{ fontWeight: 500, margin: 3 }}>
            <Radio.Group style={{ display: 'flex', justifyContent: 'space-between' }}>
                <Radio value={1}>Nam</Radio>
                <Radio value={2}>Nữ</Radio>
                <Radio value={0}>Khác</Radio>
            </Radio.Group>
        </Form.Item>
    );
};
