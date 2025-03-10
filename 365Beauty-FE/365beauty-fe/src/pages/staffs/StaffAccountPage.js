import React, { useState } from 'react';
import { Layout, Button, Spin, Form, Input as Search, message } from 'antd';
import { SearchOutlined, ReloadOutlined } from '@ant-design/icons';
import { useStaffAccountData } from '../../hooks/users/StaffAccountData';
import StaffAccountTable from '../../components/tables/users/StaffAccountTable';
import { createStaffAccount } from '../../apis/users/userAccount';

const { Content } = Layout;

const StaffAccountPage = () => {
    const [form] = Form.useForm();
    const [loading, setLoading] = useState(false);
    const [searchText, setSearchText] = useState('');
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize] = useState(10);
    const [reload, setReload] = useState(false);
    const userAccount = useStaffAccountData(reload);

    const handleReload = () => {
        setReload(!reload);
        setTimeout(() => setLoading(false), 100);  // Giả lập tải lại dữ liệu
    };

    const CreateFinish = async (record) => {
        const payload = {
            salonId: record.salonId,
        };
        try {
            await createStaffAccount(payload);
            message.success('Tạo tài khoản quản lý thành công!');
            setReload(!reload);
        } catch (error) {
            console.error('Lỗi khi tạo tài khoản:', error);
            message.error('Đã xảy ra lỗi. Vui lòng thử lại.');
        }
    };


    return (
        <Layout>
            <Content style={{ padding: '0px 10px' }}>
                <div style={{ marginBottom: '20px', display: 'flex', justifyContent: 'right', alignItems: 'center' }}>
                    <Search
                        placeholder="Tìm kiếm tên người dùng"
                        value={searchText}
                        onChange={(e) => setSearchText(e.target.value)}
                        style={{ marginRight: 10, border: '1px black solid' }}
                    />
                    <Button
                        icon={<SearchOutlined />}
                        style={{ marginRight: 10, color: '#0099FF', border: '2px #0099FF solid' }}
                    >
                        Tìm kiếm
                    </Button>
                    <Button
                        icon={<ReloadOutlined />}
                        onClick={handleReload}
                        style={{ marginRight: 10, padding: '10px 20px', color: '#0099FF', border: '2px #0099FF solid' }}
                    >
                        Tải lại
                    </Button>
                </div>
                {loading ? (
                    <Spin size="large" />
                ) : (
                    <StaffAccountTable
                        data={userAccount}
                        currentPage={currentPage}
                        pageSize={pageSize}
                        handleCreate={CreateFinish}
                        setCurrentPage={setCurrentPage}
                    />
                )}
            </Content>
        </Layout>
    );
};

export default StaffAccountPage;
