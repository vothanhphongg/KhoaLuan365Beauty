// NotFoundPage.jsx
import React from 'react';
import { Button } from 'antd';
import { useNavigate } from 'react-router-dom';

function NotFoundPage() {
    const navigate = useNavigate();

    return (
        <div style={{ textAlign: 'center', padding: '50px' }}>
            <h1>404 - Trang không tồn tại</h1>
            <p>Xin lỗi, chúng tôi không thể tìm thấy trang bạn đang tìm kiếm.</p>
            <Button type="primary" onClick={() => navigate('/')}>
                Quay về Trang chủ
            </Button>
        </div>
    );
}

export default NotFoundPage;
