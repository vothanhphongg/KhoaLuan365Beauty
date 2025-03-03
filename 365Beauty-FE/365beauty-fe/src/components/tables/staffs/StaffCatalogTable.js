import React from 'react';
import { Table, Button, Flex } from 'antd';
import { EditOutlined, LockOutlined, UnlockOutlined } from '@ant-design/icons';

const StaffCatalogTable = ({ data, currentPage, pageSize, handleUpdate, setCurrentPage, handleLockAndUnLock }) => {
    const columns = [
        {
            title: 'STT',
            key: 'index',
            render: (_, record, index) => (currentPage - 1) * pageSize + index + 1,
            align: 'center',
        },
        {
            title: 'Tên nhân viên',
            dataIndex: 'fullName',
            key: 'fullName',
            align: 'center',
        },
        {
            title: 'Căn cước công dân',
            dataIndex: 'idCard',
            key: 'idCard',
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
            dataIndex: 'img',
            key: 'img',
            align: 'center',
            render: (imageName) => (
                <Flex style={{ justifyContent: 'center', textAlign: 'center' }}>
                    <img
                        src={require(`../../../assets/${imageName ?? 'defaultAvatar.png'}`)}
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
                    <Button icon={<EditOutlined />} onClick={() => handleUpdate(record)} style={{ padding: 15, border: "#00ff00 2px solid", color: '#00CC00' }} />
                    <Button
                        icon={record.isActived === 1 ? <LockOutlined /> : <UnlockOutlined />}
                        style={{ padding: 15, border: "#FF0000 2px solid", color: '#FF0000' }}
                        onClick={() => handleLockAndUnLock(record.id)}
                    />                </div>
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

export default StaffCatalogTable;