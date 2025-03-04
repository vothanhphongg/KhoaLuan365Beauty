import React from 'react';
import { Table, Button, Space } from 'antd';
import { EditOutlined, DeleteOutlined } from '@ant-design/icons';

const BookingTypeTable = ({ data, currentPage, pageSize, handleUpdate, setCurrentPage, handleDelete }) => {
    const columns = [
        {
            title: 'STT',
            key: 'index',
            render: (_, record, index) => (currentPage - 1) * pageSize + index + 1,
            align: 'center',
        },
        {
            title: 'Tên loại đặt lịch',
            dataIndex: 'name',
            key: 'name',
            align: 'center',
        },
        {
            title: 'Hành động',
            key: 'action',
            align: 'center',
            render: (record) => (
                <Space>
                    <Button icon={< EditOutlined />} onClick={() => handleUpdate(record)} style={{ padding: 10, border: '#00ff00 2px solid', color: '#00CC00' }} />
                    <Button icon={< DeleteOutlined />} style={{ padding: 10, border: "#FF0000 2px solid", color: '#FF0000' }} onClick={() => handleDelete(record.id)} />
                </Space>
            ),
        },
    ];

    return (
        <Table columns={columns} dataSource={data} rowKey="id" pagination={{ current: currentPage, pageSize: pageSize, total: data.length, onChange: (page) => setCurrentPage(page), }}
        />
    );
};

export default BookingTypeTable;