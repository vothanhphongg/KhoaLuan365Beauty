import React, { useState } from 'react';
import { Layout, Button, Spin, Form, Input as Search } from 'antd';
import { SearchOutlined, ReloadOutlined } from '@ant-design/icons';  // Đã sửa lỗi ở đây
import { useUserAccountData } from '../../hooks/users/UserAccountData';
import UserAccountTable from '../../components/tables/users/UserAccountTable';

const { Content } = Layout;

const UserAccountPage = () => {
    const [form] = Form.useForm();
    const [loading, setLoading] = useState(false);
    const [searchText, setSearchText] = useState('');
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize] = useState(10);
    const userAccount = useUserAccountData();

    const handleReload = () => {
        setLoading(true);
        setTimeout(() => setLoading(false), 100);  // Giả lập tải lại dữ liệu
    };

    return (
        <Layout>
            <Content style={{ padding: '0px 10px' }}>
                <div style={{ marginBottom: '20px', display: 'flex', justifyContent: 'right', alignItems: 'center' }}>
                    <Search
                        placeholder="Tìm kiếm tên nhân viên"
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
                    <UserAccountTable
                        data={userAccount}
                        currentPage={currentPage}
                        pageSize={pageSize}
                        setCurrentPage={setCurrentPage}
                    />
                )}
            </Content>
        </Layout>
    );
};

export default UserAccountPage;
