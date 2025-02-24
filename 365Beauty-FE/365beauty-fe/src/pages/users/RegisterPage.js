import React, { useState } from 'react';
import { Form, Col, Row, Flex, message } from 'antd';
import { useNavigate } from 'react-router-dom';
import { registerUserAccountAPI } from '../../apis/users/userAccount';
import { DangKyDangNhap, Logo365Beauty, ChuyenHuong } from '../../components/Text';
import { Input } from '../../components/Input';
import Background from '../../assets/background.png';
import { ButtonAuth } from '../../components/Button';

const RegisterPage = () => {
    const [form] = Form.useForm();
    const navigate = useNavigate();
    const [error, setErrors] = useState({});
    const onFinish = async (values) => {
        const payload = {
            Tel: values.Tel,
            Password: values.Password,
            ConfirmPassword: values.ConfirmPassword,
            FirstName: values.FirstName,
            LastName: values.LastName,
            Email: values.Email,
        };
        console.log(payload);
        try {
            // Gọi API để tạo tài khoản người dùng
            await registerUserAccountAPI(payload);
            message.success('Tạo tài khoản thành công!');
            navigate('/login');
        } catch (error) {
            console.error('Error:', error);

            // Nếu có lỗi, hiển thị thông báo và cập nhật state lỗi
            if (error.response && error.response.data) {
                const apiErrors = error.response.data.error.details.reduce((acc, detail) => {
                    const fieldName = detail.split(' ')[0];
                    acc[fieldName] = detail;
                    return acc;
                }, {});
                setErrors(apiErrors); // Cập nhật state lỗi
            }
            message.error('Đăng ký thất bại. Vui lòng thử lại.');
        }
    };

    return (
        <div style={{ backgroundImage: `url(${Background})`, backgroundSize: 'cover', backgroundPosition: 'center', height: '100vh' }}>
            <div style={{ maxWidth: 800, margin: 'auto', padding: 20 }}>
                <Flex style={{ justifyContent: 'center', alignItems: 'center', flexDirection: 'column', margin: '10px' }}>
                    <Logo365Beauty style={{ fontSize: '2.5rem' }} />
                    <DangKyDangNhap text={'Đăng ký'} />
                </Flex>
                <Form form={form} onFinish={onFinish} layout="vertical">
                    <Row gutter={16}>
                        <Col span={12}>
                            <Input label={'Ho'} name={'FirstName'} placeholder={'Nhập họ'} errorMessage={error.FirstName} />
                        </Col>
                        <Col span={12}>
                            <Input label={'Tên'} name={'LastName'} placeholder={'Nhập tên'} errorMessage={error.LastName} />
                        </Col>
                    </Row>
                    <Input label={'Số điện thoại'} name={'Tel'} placeholder={'Nhập số điện thoại'} errorMessage={error.Tel} />
                    <Input label={'Email'} name={'Email'} placeholder={'Nhập email'} errorMessage={error.Email} />
                    <Input label={'Mật khẩu'} name={'Password'} placeholder={'Nhập mật khẩu'} type={'password'} errorMessage={error.Password} />
                    <Input label={'Nhập lại mật khẩu'} name={'ConfirmPassword'} placeholder={'Nhập mật khẩu'} type={'password'} errorMessage={error.ConfirmPassword} />
                    <Form.Item>
                        <ButtonAuth text={'Đăng ký'} />
                    </Form.Item>
                    <Form.Item style={{ display: 'flex', justifyContent: 'center', marginTop: '-20px' }}>
                        <ChuyenHuong text={'Bạn đã có tài khoản?'} locate={'/login'} button={'Đăng nhập ngay'} />
                    </Form.Item>
                </Form>
            </div >
        </div>
    );
};

export default RegisterPage;