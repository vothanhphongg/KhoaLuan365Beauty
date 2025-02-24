import React from 'react';
import { Table, Button, Space, Flex } from 'antd';
import { EditOutlined, LockOutlined, UnlockOutlined } from '@ant-design/icons';

const ServiceCatalogTable = ({ data, currentPage, pageSize, handleUpdate, setCurrentPage, handleLockAndUnLock }) => {
    const columns = [
        {
            title: 'STT',
            key: 'index',
            render: (_, record, index) => (currentPage - 1) * pageSize + index + 1,
            align: 'center',
        },
        {
            title: 'Tên loại dịch vụ',
            dataIndex: 'name',
            key: 'name',
            align: 'center',
        },
        {
            title: 'Hình ảnh',
            dataIndex: 'icon',
            key: 'icon',
            align: 'center',
            render: (imageName) => (
                <Flex style={{ justifyContent: 'center', textAlign: 'center' }}>
                    <img
                        src={require(`../../../assets/${imageName}`)} // Đường dẫn hình ảnh trên server
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
                <Space>
                    <Button
                        icon={<EditOutlined />}
                        onClick={() => handleUpdate(record)}
                        style={{ padding: 10, border: '#00ff00 2px solid', color: '#00CC00' }}
                    />
                    <Button icon={record.isActived === 1 ? <LockOutlined /> : <UnlockOutlined />} style={{ padding: 10, border: "#FF0000 2px solid", color: '#FF0000' }} onClick={() => handleLockAndUnLock(record.id)} />

                </Space>
            ),
        },
    ];

    return (
        <Table
            columns={columns}
            dataSource={data}
            rowKey="id"
            pagination={{
                current: currentPage,
                pageSize: pageSize,
                total: data.length,
                onChange: (page) => setCurrentPage(page),
            }}
        />
    );
};

export default ServiceCatalogTable;