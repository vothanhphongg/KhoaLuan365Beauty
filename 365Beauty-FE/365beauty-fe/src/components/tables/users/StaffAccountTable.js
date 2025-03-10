import React from 'react';
import { Table, Button, Flex } from 'antd';
import { PlusOutlined } from '@ant-design/icons';

const StaffAccountTable = ({ data, currentPage, pageSize, handleCreate, setCurrentPage }) => {
    const columns = [
        {
            title: 'STT',
            key: 'index',
            render: (_, record, index) => (currentPage - 1) * pageSize + index + 1,
            align: 'center',
        },
        {
            title: 'Tên thẩm mỹ viện',
            dataIndex: 'salonName',
            key: 'salonName',
            align: 'center',
        },
        {
            title: 'Số điện thoại',
            dataIndex: 'tel',
            key: 'tel',
            align: 'center',
        },
        {
            title: 'Email',
            dataIndex: 'email',
            key: 'email',
            align: 'center',
        },
        {
            title: 'Hình ảnh',
            dataIndex: 'img',
            key: 'img',
            align: 'center',
            render: (img) => (
                <Flex style={{ justifyContent: 'center', textAlign: 'center' }}>
                    <img
                        src={require(`../../../assets/${img ?? 'defaultAvatar.png'}`)}
                        alt="Hình ảnh"
                        style={{ width: 100, height: 100, objectFit: 'contain', borderRadius: '50%' }}
                    />
                </Flex>
            ),
        },
        {
            title: 'Hành động',
            key: 'action',
            align: 'center',
            render: (record) => (
                !record.isActived && (
                    <Button
                        icon={<PlusOutlined />}
                        onClick={() => handleCreate(record)}  // Truyền record vào handleCreate
                        style={{ padding: 15, border: "#00ff00 2px solid", color: '#00CC00' }}
                    />
                )
            ),
        }
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

export default StaffAccountTable;
