import React from 'react';
import { Menu, Dropdown, Avatar, Button } from 'antd';
import {
    UserOutlined, PhoneOutlined, DollarOutlined, HomeOutlined, DownOutlined, BarChartOutlined, CalendarOutlined,
    AppstoreAddOutlined, LogoutOutlined, ApartmentOutlined, ProductOutlined, AuditOutlined, ScheduleOutlined
} from '@ant-design/icons';

export const DropdownMenuProfile = ({ userInfo, isAdmin, isBeautySalon, handleMenuClick }) => {
    // Định nghĩa menuItems với các icon tương ứng
    const menuItems = [
        { key: 'profile', label: 'Hồ sơ của tôi', icon: <UserOutlined /> },
        { key: 'appointments', label: 'Lịch hẹn', icon: <CalendarOutlined /> },
        isAdmin && { key: 'admin', label: 'Trang Admin', icon: <AppstoreAddOutlined /> },
        isBeautySalon && { key: 'beauty-salon', label: 'Trang Quản lý', icon: <AppstoreAddOutlined /> },
        { type: 'divider' },
        { key: 'logout', label: 'Đăng xuất', icon: <LogoutOutlined /> },
    ].filter(Boolean); // Loại bỏ các mục falsy như khi không phải admin

    // Tạo menu với các items
    const menu = (
        <Menu onClick={handleMenuClick} style={{ width: '220px', boxShadow: '10px 10px 12px rgba(0, 0, 0, 0.5)', left: '30%' }}>
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
            label: 'Home Admin',
            icon: <HomeOutlined />,
            key: 'admin'
        },
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
            label: 'Quản lí tài khoản',
            icon: <UserOutlined />,
            children: [
                {
                    key: 'user-account',
                    label: 'Tài khoản người dùng',
                },
                {
                    key: 'staff-account',
                    label: 'Tài khoản quản lí',
                }
            ]
        },
        {
            label: 'Quản lí học thuật',
            icon: <AuditOutlined />,
            children: [
                {
                    key: 'title-catalog',
                    label: 'Danh mục học hàm',
                },
                {
                    key: 'degree-catalog',
                    label: 'Danh mục học vị',
                },
                {
                    key: 'occupation-catalog',
                    label: 'Danh mục nghề nghiệp',
                }
            ]
        },
        {
            label: 'Quản lí đặt lịch',
            icon: <ScheduleOutlined />,
            children: [
                {
                    key: 'booking-type',
                    label: 'Loại đặt lịch',
                },
                {
                    key: 'time',
                    label: 'Thời gian đặt lịch',
                }
            ]
        }
    ];

    return (
        <Menu
            onClick={menuClick}
            mode='inline'
            items={items.map(item => ({
                ...item,
                style: { marginBottom: '15px' }  // Tùy chỉnh style từng item
            }))}
            style={{ fontSize: '16px', fontWeight: 500 }}
        />
    );
};

export const MenuAllPage = ({ menuClick }) => {
    const items = [
        {
            label: 'Cơ sở làm đẹp',
            icon: <ProductOutlined />,
            key: 'beauty-salons'
        },
        {
            label: 'Dịch vụ',
            icon: <ApartmentOutlined />,
            key: 'salon-services'
        }
    ];

    return (
        <Menu onClick={menuClick} mode='inline' items={items} style={{ fontSize: '15px', fontWeight: 500 }} />
    );
};

export const MenuBeautySalon = ({ menuClick }) => {
    const items = [
        {
            label: 'Thông tin thẩm mỹ viện',
            icon: <HomeOutlined />,
            key: 'beauty-salon'
        },
        {
            label: 'Quản lí dịch vụ',
            icon: <ProductOutlined />,
            key: 'salon-services'
        },
        {
            label: 'Quản lí nhân viên',
            icon: <UserOutlined />,
            key: 'staff-services'
        },
        {
            label: 'Quản lí giá và lịch',
            icon: <DollarOutlined />,
            key: 'price-services'
        },
        {
            label: 'Xác nhận dịch vụ',
            icon: <PhoneOutlined />,
            key: 'confirm-services'
        },
        {
            label: 'Thống kê dịch vụ',
            icon: <BarChartOutlined />,
            key: 'report-services'
        },
    ];

    return (
        <Menu
            onClick={menuClick}
            mode='inline'
            items={items.map(item => ({
                ...item,
                style: { marginBottom: '15px' }  // Tùy chỉnh style từng item
            }))}
            style={{ fontSize: '16px', fontWeight: 500 }}
        />
    );
};