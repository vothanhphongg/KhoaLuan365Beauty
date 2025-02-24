import React from 'react';
import { Form, DatePicker } from 'antd';
import moment from 'moment';
import '../styles/component.css';

export const DateTimePicker = ({ name }) => {
    return (
        <Form.Item
            label="Ngày sinh"
            name={name}
            style={{ fontWeight: 500, margin: 3 }}
            initialValue={moment('2000-01-01')} // Sử dụng initialValue để đặt giá trị mặc định
        >
            <DatePicker
                style={{ width: '100%' }}
            />
        </Form.Item>
    );
};
