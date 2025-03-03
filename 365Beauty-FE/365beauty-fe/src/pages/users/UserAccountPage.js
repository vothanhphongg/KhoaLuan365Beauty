import React, { useState } from 'react';
import { Layout, Button, Spin, Form, Input as Search } from 'antd';
import { SearchOutlined } from '@ant-design/icons';
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


    return (
        <Layout>
            <Content style={{ padding: '0px 10px' }}>
                <div style={{ marginBottom: '20px', display: 'flex', justifyContent: 'right', alignItems: 'center' }}>
                    <Search placeholder="Tìm kiếm tên thẩm mỹ viện" value={searchText} onChange={(e) => setSearchText(e.target.value)} style={{ marginRight: 10, border: '1px black solid' }} />
                    <Button icon={<SearchOutlined />} style={{ marginRight: 10, color: '#0099FF', border: '2px #0099FF solid' }}>Tìm kiếm</Button>
                </div>
                {loading ? (<Spin size="large" />) : (<UserAccountTable data={userAccount} currentPage={currentPage} pageSize={pageSize} setCurrentPage={setCurrentPage} />)}
            </Content>
        </Layout>
    );
};

export default UserAccountPage;
