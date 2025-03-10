import React from 'react';
import { Table, Button, Flex } from 'antd';
import { EditOutlined, LockOutlined, UnlockOutlined, PlusOutlined, InfoCircleOutlined } from '@ant-design/icons';

export const BeautySalonServiceTable = ({ data, currentPage, pageSize, handleUpdate, setCurrentPage, handleLockAndUnLock }) => {
    const columns = [
        {
            title: 'STT',
            key: 'index',
            render: (_, record, index) => (currentPage - 1) * pageSize + index + 1,
            align: 'center',
        },
        {
            title: 'Tên dịch vụ thẩm mỹ',
            dataIndex: 'name',
            key: 'name',
            align: 'center',
        },
        {
            title: 'Hình ảnh',
            dataIndex: 'image',
            key: 'image',
            align: 'center',
            render: (imageName) => (
                <Flex style={{ justifyContent: 'center', textAlign: 'center' }}>
                    <img src={require(`../../../assets/${imageName}`)} alt="Hình ảnh" style={{ width: 200, height: 100, objectFit: 'contain' }} />
                </Flex>
            ),
        },
        {
            title: 'Hành động',
            key: 'action',
            align: 'center',
            render: (record) => (
                <Flex style={{ justifyContent: 'center', textAlign: 'center', gap: '10px' }}>
                    <Button icon={<EditOutlined />} onClick={() => handleUpdate(record)} style={{ padding: 15, border: "#00ff00 2px solid", color: '#00CC00' }} />
                    <Button icon={record.isActived === 1 ? <LockOutlined /> : <UnlockOutlined />} style={{ padding: 15, border: "#FF0000 2px solid", color: '#FF0000' }} onClick={() => handleLockAndUnLock(record.id)} />
                </Flex>
            ),
        },
    ];

    return (
        <Table columns={columns} dataSource={data}
            pagination={{
                current: currentPage,
                pageSize: pageSize,
                total: data.length,
                onChange: (page) => setCurrentPage(page),
            }}
        />
    );
};

export const BeautySalonServiceNoPriceTable = ({ data, currentPage, pageSize, handleCreate, setCurrentPage }) => {
    const columns = [
        {
            title: 'Tên dịch vụ thẩm mỹ',
            dataIndex: 'name',
            key: 'name',
            align: 'center',
        },
        {
            title: 'Hình ảnh',
            dataIndex: 'image',
            key: 'image',
            align: 'center',
            render: (imageName) => (
                <Flex style={{ justifyContent: 'center', textAlign: 'center' }}>
                    <img src={require(`../../../assets/${imageName}`)} alt="Hình ảnh" style={{ width: 50, height: 50, objectFit: 'contain' }} />
                </Flex>
            ),
        },
        {
            title: 'Hành động',
            key: 'action',
            align: 'center',
            render: (record) => (
                <Button icon={<PlusOutlined />} onClick={() => handleCreate(record)} style={{ border: "#00ff00 2px solid", color: '#00CC00' }} />
            ),
        },
    ];

    return (
        <Table columns={columns} dataSource={data}
            pagination={{
                current: currentPage,
                pageSize: pageSize,
                total: data.length,
                onChange: (page) => setCurrentPage(page),
            }}
        />
    );
};

export const BeautySalonServiceWithPriceTable = ({ data, currentPage, pageSize, handleUpdate, setCurrentPage }) => {
    const columns = [
        {
            title: 'Tên dịch vụ thẩm mỹ',
            dataIndex: 'name',
            key: 'name',
            align: 'center',
        },
        {
            title: 'Giá cơ bản',
            key: 'basePrice',
            align: 'center',
            render: (record) => `${(record.basePrice ?? 0).toLocaleString()}đ`
        },
        {
            title: 'Giá dịch vụ',
            key: 'finalPrice',
            align: 'center',
            render: (record) => `${(record.finalPrice ?? 0).toLocaleString()}đ`
        },
        {
            title: 'Hình ảnh',
            dataIndex: 'image',
            key: 'image',
            align: 'center',
            render: (imageName) => (
                <Flex style={{ justifyContent: 'center', textAlign: 'center' }}>
                    <img src={require(`../../../assets/${imageName}`)} alt="Hình ảnh" style={{ width: 50, height: 50, objectFit: 'contain' }} />
                </Flex>
            ),
        },
        {
            title: 'Hành động',
            key: 'action',
            align: 'center',
            render: (record) => (
                <Button icon={<EditOutlined />} onClick={() => handleUpdate(record)} style={{ border: "#00ff00 2px solid", color: '#00CC00' }} />
            ),
        },
    ];

    return (
        <Table columns={columns} dataSource={data} style={{ marginLeft: 10 }}
            pagination={{
                current: currentPage,
                pageSize: pageSize,
                total: data.length,
                onChange: (page) => setCurrentPage(page),
            }}
        />
    );
};

export const BeautySalonServiceBookingTable = ({ data, currentPage, pageSize, handleUpdate, setCurrentPage }) => {
    const columns = [
        {
            title: 'STT',
            key: 'index',
            render: (_, record, index) => (currentPage - 1) * pageSize + index + 1,
            align: 'center',
        },
        {
            title: 'Người đặt lịch',
            dataIndex: 'userName',
            key: 'userName',
            align: 'center',
        },
        {
            title: 'Dịch vụ đặt lịch',
            dataIndex: 'salonServiceName',
            key: 'salonServiceName',
            align: 'center',
        },
        {
            title: 'Ngày đặt lịch',
            dataIndex: 'bookingDate',
            key: 'bookingDate',
            align: 'center',
        },
        {
            title: 'Thời gian',
            dataIndex: 'times',
            key: 'times',
            align: 'center',
        },
        {
            title: 'Ngày tạo lịch',
            dataIndex: 'userName',
            key: 'userName',
            align: 'center',
        },
        {
            title: 'Hành động',
            key: 'action',
            align: 'center',
            render: (record) => (
                <Flex style={{ justifyContent: 'center', textAlign: 'center' }}>
                    <Button icon={<InfoCircleOutlined />} onClick={() => handleUpdate(record)} style={{ border: "#00ff00 2px solid", color: '#00CC00' }} />
                </Flex>
            ),
        },
    ];

    return (
        <Table columns={columns} dataSource={data}
            pagination={{
                current: currentPage,
                pageSize: pageSize,
                total: data.length,
                onChange: (page) => setCurrentPage(page),
            }}
        />
    );
};