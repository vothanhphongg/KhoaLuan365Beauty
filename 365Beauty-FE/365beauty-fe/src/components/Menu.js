import React from 'react';
import { Menu, Dropdown, Avatar, Button } from 'antd';
import {
    UserOutlined, DownOutlined, TransactionOutlined, CalendarOutlined, AppstoreAddOutlined, LogoutOutlined, ApartmentOutlined, ProductOutlined, AuditOutlined
} from '@ant-design/icons';

export const DropdownMenuProfile = ({ userInfo, isAdmin, handleMenuClick }) => {
    // Định nghĩa menuItems với các icon tương ứng
    const menuItems = [
        { key: 'profile', label: 'Thông tin tài khoản', icon: <UserOutlined /> },
        { key: 'transactions', label: 'Lịch sử giao dịch', icon: <TransactionOutlined /> },
        { key: 'appointments', label: 'Lịch hẹn', icon: <CalendarOutlined /> },
        isAdmin && { key: 'admin', label: 'Trang Admin', icon: <AppstoreAddOutlined /> },
        { type: 'divider' },
        { key: 'logout', label: 'Đăng xuất', icon: <LogoutOutlined /> },
    ].filter(Boolean); // Loại bỏ các mục falsy như khi không phải admin

    // Tạo menu với các items
    const menu = (
        <Menu onClick={handleMenuClick} style={{ width: '220px', boxShadow: '10px 10px 12px rgba(0, 0, 0, 0.5)' }}>
            {menuItems.map(item =>
                item.type === 'divider' ? (
                    <Menu.Divider key={item.key} />
                ) : (
                    <Menu.Item key={item.key} icon={item.icon} style={{ fontSize: '1rem', fontWeight: '500', padding: '10px' }}>
                        {item.label}
                    </Menu.Item>
                )
            )}
        </Menu>
    );

    return (
        <Dropdown overlay={menu} trigger={['click']}>
            <Button type="text" style={{ display: 'flex', alignItems: 'center', gap: '10px', fontFamily: 'Arial, sans-serif', fontSize: '1rem', fontWeight: '600', margin: '10px' }} >
                <Avatar src={require(`../assets/${userInfo?.Img ?? 'defaultAvatar.png'}`)} size="large" style={{ margin: '10px' }} />
                {userInfo.FullName}
                <DownOutlined />
            </Button>
        </Dropdown>
    );
};


export const MenuMain = ({ menuClick }) => {
    const items = [
        {
            label: 'Quản lí danh mục dịch vụ',
            icon: <ProductOutlined />,
            key: 'service-catalog'
        },
        {
            label: 'Quản lí thẩm mỹ viện',
            icon: <ApartmentOutlined />,
            key: 'beauty-salon-catalog'
        },
        {
            label: 'Quản lí học thuật',
            icon: < AuditOutlined />,
            children: [
                {
                    key: 'title-catalog',
                    label: 'Danh mục học hàm',
                },
                {
                    key: 'degree-catalog',
                    label: 'Dịch vụ học vị',
                },
                {
                    key: 'occupation-catalog',
                    label: 'Danh mục nghề nghiệp',
                }
            ]
        },
    ];

    return (
        <Menu onClick={menuClick} mode='inline' items={items} />
    );
};