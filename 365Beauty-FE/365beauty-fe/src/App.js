import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route, Outlet } from 'react-router-dom';
import { Layout } from 'antd';
import BeautyHeader from './pages/BeautyHeader';
import HomePage from './pages/HomePage';
import AdminPage from './pages/AdminPage';
import NotFoundPage from './pages/NotFoundPage';
import './App.css';
import BeautySalonCatalogPage from './pages/beautySalons/BeautySalonCatalogPage';
import RegisterPage from './pages/users/RegisterPage';
import LoginPage from './pages/users/LoginPage';
import ServiceCatalogPage from './pages/services/ServiceCatalogPage';
import BeautySalonServiceDetailPage from './pages/beautySalons/BeautySalonServicePage';
import DegreeCatalogPage from './pages/staffs/DegreeCatalogPage';
import TitleCatalogPage from './pages/staffs/TitleCatalogPage';
import OccupationCatalogPage from './pages/staffs/OccupationCatalogPage';
import BeautyFooter from './pages/BeautyFooter';
import DetailSalonServicePage from './pages/beautySalons/DetailSalonServicePage';
import BookingPage from './pages/beautySalons/BookingPage';

const { Content } = Layout;

const AppLayout = () => (
  <Layout className="layout">
    <BeautyHeader />
    <Content>
      <Outlet />
    </Content>
    <BeautyFooter />
  </Layout>
);

function App() {
  const [isAdmin, setIsAdmin] = useState(false);

  useEffect(() => {
    // Lấy thông tin từ localStorage hoặc API
    const userInfo = JSON.parse(localStorage.getItem('userInfo'));
    if (userInfo && userInfo.UserRoles) {
      setIsAdmin(userInfo.UserRoles.some(role => role.name === 'ADMIN'));
      console.log(setIsAdmin);
    }
  }, []);

  return (
    <Router>
      <Routes>
        <Route path="/" element={<AppLayout />}>
          <Route index element={<HomePage />} />
          <Route path="/detailsalonservice/:id" element={<DetailSalonServicePage />} />
          <Route path="/booking/:id" element={<BookingPage />} />
        </Route>
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/admin" element={isAdmin ? <AdminPage /> : <NotFoundPage />} >
          {/* Các route con của Admin */}
          <Route path="beauty-salon-catalog" element={<BeautySalonCatalogPage />} />
          <Route path="beauty-salon-services/:id" element={<BeautySalonServiceDetailPage />}>
          </Route>

          <Route path="service-catalog" element={<ServiceCatalogPage />} />
          <Route path="title-catalog" element={<TitleCatalogPage />} />
          <Route path="degree-catalog" element={<DegreeCatalogPage />} />
          <Route path="occupation-catalog" element={<OccupationCatalogPage />} />
        </Route>
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </Router>
  );
}

export default App;
