import React, { useState } from 'react';
import { Form, Col, Row, Flex, message } from 'antd';
import { createUserAccountAPI } from '../apis/userAccount';
import { DangKyDangNhap, Logo365Beauty } from '../components/Text';
import { Input } from '../components/Input';
import Background from '../assets/background.png';
import { RadioButtonGender } from '../components/RadioButton';
import { DateTimePicker } from '../components/DateTimePicker';
import { ButtonRegister } from '../components/Button';

const BeautyRegisterPage = () => {
    const [form] = Form.useForm();
    const [error, setErrors] = useState({});
    const onFinish = async (values) => {
        const payload = {
            Tel: values.Tel,
            Password: values.Password,
            FirstName: values.FirstName,
            LastName: values.LastName,
            Gender: values.Gender,
            IdCard: values.IdCard,
            Email: values.Email,
            Address: values.Address,
            DateOfBirth: values.DateOfBirth ? values.DateOfBirth.format('YYYY-MM-DD') : null
        };
        console.log(payload);
        try {
            // Gọi API để tạo tài khoản người dùng
            const response = await createUserAccountAPI(payload);
            console.log('Registration successful:', response);
            message.success('Registration successful!');
        } catch (error) {
            console.error('Error:', error);

            // Nếu có lỗi, hiển thị thông báo và cập nhật state lỗi
            if (error.response && error.response.data) {
                const apiErrors = error.response.data.error.details.reduce((acc, detail) => {
                    const fieldName = detail.split(' ')[0];
                    acc[fieldName] = detail;
                    return acc;
                }, {});

                console.log('Processed API Errors:', apiErrors);
                setErrors(apiErrors); // Cập nhật state lỗi
            }

            message.error('Registration failed. Please try again.');
        }
    };

    return (
        <div style={{ backgroundImage: `url(${Background})`, backgroundSize: 'cover', backgroundPosition: 'center' }}>
            <div style={{ maxWidth: 800, margin: 'auto', padding: 20 }}>
                <Flex style={{ justifyContent: 'center', alignItems: 'center', flexDirection: 'column', margin: '10px' }}>
                    <Logo365Beauty style={{ fontSize: '2.5rem' }} />
                    <DangKyDangNhap text={'Đăng ký'} />
                </Flex>

                <Form
                    form={form}
                    onFinish={onFinish}
                    layout="vertical"
                    initialValues={{ Gender: 1 }}
                >
                    <Row gutter={16}>
                        <Col span={12}>
                            <Input label={'Tên'} name={'FirstName'} placeholder={'Nhập tên'} errorMessage={error.FirstName} />
                        </Col>
                        <Col span={12}>
                            <Input label={'Họ'} name={'LastName'} placeholder={'Nhập họ'} />
                        </Col>
                    </Row>
                    <Input label={'Số điện thoại'} name={'Tel'} placeholder={'Nhập số điện thoại'} errorMessage={error.Tel} />
                    <Input label={'Căn cước công dân'} name={'IdCard'} placeholder={'Nhập căn cước công dân'} />
                    <Input label={'Email'} name={'Email'} placeholder={'Nhập email'} />
                    <Input label={'Địa chỉ'} name={'Address'} placeholder={'Nhập địa chỉ'} />
                    <Row gutter={16}>
                        <Col span={8}>
                            <RadioButtonGender name={'Gender'} />
                        </Col>
                        <Col span={16}>
                            <DateTimePicker name={'DateOfBirth'} />
                        </Col>
                    </Row>
                    <Input label={'Mật khẩu'} name={'Password'} placeholder={'Nhập mật khẩu'} type={'password'} />
                    <Form.Item
                        label={'Nhập lại mật khẩu'}
                        name={'ConfirmPassword'}
                        hasFeedback
                        rules={[
                            {
                                required: true,
                                message: 'Vui lòng nhập lại mật khẩu!',
                            },
                            ({ getFieldValue }) => ({
                                validator(_, value) {
                                    if (!value || getFieldValue('Password') === value) {
                                        return Promise.resolve();
                                    }
                                    return Promise.reject(new Error('Mật khẩu không khớp!'));
                                },
                            }),
                        ]}
                    >
                        <Input
                            placeholder={'Nhập lại mật khẩu'}
                            type={'password'}
                        />
                    </Form.Item>
                    <Form.Item>
                        <ButtonRegister />
                    </Form.Item>
                </Form>
            </div >
        </div>
    );
};

export default BeautyRegisterPage;