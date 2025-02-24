import React from 'react';
import { Table, Button, Flex, Dropdown, Menu } from 'antd';
import { useNavigate } from 'react-router-dom';
import { EditOutlined, LockOutlined, UnlockOutlined, EllipsisOutlined, EyeOutlined, ScissorOutlined, TeamOutlined } from '@ant-design/icons';

const BeautySalonCatalogTable = ({ data, currentPage, pageSize, handleUpdate, setCurrentPage, handleLockAndUnLock }) => {
    const navigate = useNavigate();
    const handleMenuClick = (key, record) => {
        console.log(`Clicked: ${key}, Record ID: ${record.id}`);

        switch (key) {
            case 'view':
                console.log('Xem chi tiết:', record.id);
                break;
            case 'service':
                navigate(`/admin/beauty-salon-services/${record.id}`);
                break;
            case 'staff':
                console.log('Nhân viên thẩm mỹ:', record.id);
                break;
            default:
                break;
        }
    };

    const renderDropdownMenu = (record) => (
        <Menu
            onClick={({ key }) => handleMenuClick(key, record)}
            style={{
                borderRadius: 10,
                boxShadow: '0px 5px 10px rgba(0, 0, 0, 0.2)',
                minWidth: 160
            }}
        >
            <Menu.Item key="view" icon={<EyeOutlined />} style={{ fontSize: '16px', padding: '10px' }}>
                Xem chi tiết
            </Menu.Item>
            <Menu.Item key="service" icon={<ScissorOutlined />} style={{ fontSize: '16px', padding: '10px' }}>
                Dịch vụ thẩm mỹ
            </Menu.Item>
            <Menu.Item key="staff" icon={<TeamOutlined />} style={{ fontSize: '16px', padding: '10px' }}>
                Nhân viên thẩm mỹ
            </Menu.Item>
        </Menu>
    );

    const columns = [
        {
            title: 'STT',
            key: 'index',
            render: (_, record, index) => (currentPage - 1) * pageSize + index + 1,
            align: 'center',
        },
        {
            title: 'Tên thẩm mỹ viện',
            dataIndex: 'name',
            key: 'name',
            align: 'center',
        },
        {
            title: 'Thời gian làm việc',
            dataIndex: 'workingDate',
            key: 'workingDate',
            align: 'center',
        },
        {
            title: 'Số điện thoại',
            dataIndex: 'tel',
            key: 'tel',
            align: 'center',
        },
        {
            title: 'Hình ảnh',
            dataIndex: 'image',
            key: 'image',
            align: 'center',
            render: (imageName) => (
                <Flex style={{ justifyContent: 'center', textAlign: 'center' }}>
                    <img
                        src={require(`../../../assets/${imageName}`)}
                        alt="Hình ảnh"
                        style={{ width: 200, height: 100, objectFit: 'contain' }}
                    />
                </Flex>
            ),
        },
        {
            title: 'Hành động',
            key: 'action',
            align: 'center',
            render: (record) => (
                <div style={{ display: 'flex', gap: '10px' }}>
                    <Button
                        icon={<EditOutlined />}
                        onClick={() => handleUpdate(record)}
                        style={{ padding: 15, border: "#00ff00 2px solid", color: '#00CC00' }}
                    />
                    <Button
                        icon={record.isActived === 1 ? <LockOutlined /> : <UnlockOutlined />}
                        style={{ padding: 15, border: "#FF0000 2px solid", color: '#FF0000' }}
                        onClick={() => handleLockAndUnLock(record.id)}
                    />
                    <Dropdown overlay={renderDropdownMenu(record)} trigger={['click']} placement="bottomRight">
                        <Button
                            icon={<EllipsisOutlined />}
                            style={{ padding: 15, border: "#0099FF 2px solid", color: '#0099FF' }}
                        />
                    </Dropdown>
                </div>
            ),
        },
    ];

    return (
        <Table
            columns={columns}
            dataSource={data}
            pagination={{
                current: currentPage,
                pageSize: pageSize,
                total: data.length,
                onChange: (page) => setCurrentPage(page),
            }}
        />
    );
};

export default BeautySalonCatalogTable;
