import React, { useState } from 'react';
import { Form, Flex, message } from 'antd';
import { useNavigate } from 'react-router-dom';
import { loginUserAccount } from '../../apis/users/userAccount';
import { DangKyDangNhap, Logo365Beauty, ChuyenHuong } from '../../components/Text';
import { Input } from '../../components/Input';
import Background from '../../assets/background.png';
import { ButtonAuth } from '../../components/Button';

const LoginPage = () => {
    const [form] = Form.useForm();
    const [error, setErrors] = useState({});
    const navigate = useNavigate();
    const onFinish = async (values) => {
        const payload = {
            Tel: values.Tel,
            Password: values.Password,
        };
        try {
            // Gọi API để đăng nhập
            const response = await loginUserAccount(payload);
            console.log(response.data);
            // Lưu thông tin vào localStorage
            const { authResults, img, id, fullName, tel, salonId, userRoles, email } = response.data;
            localStorage.setItem('userToken', authResults.token);
            localStorage.setItem('userInfo', JSON.stringify({
                Id: id,
                FullName: fullName,
                Tel: tel,
                UserRoles: userRoles,
                Img: img,
                SalonId: salonId,
                Email: email
            }));

            message.success('Đăng nhập thành công!');
            navigate('/');
        } catch (error) {
            if (error.response && error.response.data) {
                const apiErrors = error.response.data.error.details.reduce((acc, detail) => {
                    const fieldName = detail.split(' ')[0];
                    acc[fieldName] = detail;
                    return acc;
                }, {});
                setErrors(apiErrors);
            }
            message.error('Đăng nhập thất bại!');
        }
    };

    return (
        <div style={{ backgroundImage: `url(${Background})`, backgroundSize: 'cover', backgroundPosition: 'center', height: '100vh' }}>
            <div style={{ maxWidth: 800, margin: 'auto', padding: 20 }}>
                <Flex style={{ justifyContent: 'center', alignItems: 'center', flexDirection: 'column', margin: '10px' }}>
                    <Logo365Beauty style={{ fontSize: '2.5rem' }} />
                    <DangKyDangNhap text={'Đăng nhập'} />
                </Flex>
                <Form form={form} onFinish={onFinish} layout="vertical" >
                    <Input label={'Số điện thoại'} name={'Tel'} placeholder={'Nhập số điện thoại'} errorMessage={error.Tel} />
                    <Input label={'Mật khẩu'} name={'Password'} placeholder={'Nhập mật khẩu'} type={'password'} errorMessage={error.Password} />
                    <Form.Item>
                        <ButtonAuth text={'Đăng nhập'} />
                    </Form.Item>
                    <Form.Item style={{ display: 'flex', justifyContent: 'center', marginTop: '-20px' }}>
                        <ChuyenHuong text={'Bạn chưa có tài khoản?'} locate={'/register'} button={'Đăng ký ngay'} />
                    </Form.Item>
                </Form>
            </div >
        </div>
    );
};

export default LoginPage;