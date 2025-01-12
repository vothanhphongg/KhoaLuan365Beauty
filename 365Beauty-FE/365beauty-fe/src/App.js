import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { Layout } from 'antd';
import BeautyHeader from './views/BeautyHeader';
import BeautyContent from './views/BeautyConent';
import BeautyRegisterPage from './views/BeautyRegisterPage'; // Trang đăng ký
import './App.css';

const { Footer, Content } = Layout;

function App() {
  return (
    <Router>  {/* Bao bọc ứng dụng trong Router */}
      <Routes>
        {/* Trang chính với header */}
        <Route path="/" element={
          <Layout className="layout">
            <BeautyHeader />  {/* Header luôn hiển thị */}
            <Content>
              <BeautyContent />
            </Content>
            <Footer className="footer">Footer</Footer>
          </Layout>
        } />

        {/* Trang đăng ký mà không có header */}
        <Route path="/register" element={<BeautyRegisterPage />} />  {/* Trang đăng ký */}
      </Routes>
    </Router>
  );
}

export default App;
