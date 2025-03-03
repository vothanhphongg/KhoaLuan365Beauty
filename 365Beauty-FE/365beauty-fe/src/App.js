import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route, Outlet } from 'react-router-dom';
import { Layout } from 'antd';
import BeautyHeader from './pages/base/BeautyHeader';
import HomePage from './pages/base/HomePage';
import AdminPage from './pages/base/AdminPage';
import NotFoundPage from './pages/base/NotFoundPage';
import './App.css';
import BeautySalonCatalogPage from './pages/beautySalons/BeautySalonCatalogPage';
import RegisterPage from './pages/users/RegisterPage';
import LoginPage from './pages/users/LoginPage';
import ServiceCatalogPage from './pages/services/ServiceCatalogPage';
import BeautySalonServiceDetailPage from './pages/beautySalons/BeautySalonServicePage';
import DegreeCatalogPage from './pages/staffs/DegreeCatalogPage';
import TitleCatalogPage from './pages/staffs/TitleCatalogPage';
import OccupationCatalogPage from './pages/staffs/OccupationCatalogPage';
import BeautyFooter from './pages/base/BeautyFooter';
import DetailSalonServicePage from './pages/beautySalons/DetailSalonServicePage';
import BookingPage from './pages/beautySalons/BookingPage';
import ProfilePage from './pages/users/ProfilePage';
import AllBeautySalonCatalogPage from './pages/beautySalons/AllBeautySalonCatalogPage';
import GetAllPage from './pages/base/GetAllPage';
import AllBeautySalonServicePage from './pages/beautySalons/AllBeautySalonServicePage';
import StaffCatalogPage from './pages/staffs/StaffCatalogPage';
import DetailSalonCatalogPage from './pages/beautySalons/DetailBeautySalonCatalogPage';
import AllBeautySalonServiceByServiceIdPage from './pages/beautySalons/AllBeautySalonServiceByServiceIdPage';
import HomeAdminPgae from './pages/base/HomeAdminPgae';
import UserAccountPage from './pages/users/UserAccountPage';

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
          <Route path="/all-salon-service-by-service-id/:id" element={<AllBeautySalonServiceByServiceIdPage />} />
          <Route path="/detailsalonservice/:id" element={<DetailSalonServicePage />} />
          <Route path="/detailsaloncatalog/:id" element={<DetailSalonCatalogPage />} />
          <Route path="/booking/:id" element={<BookingPage />} />
          <Route path="/profile/:id" element={<ProfilePage />} />
          <Route path="get-all" element={<GetAllPage />}>
            <Route path="beauty-salons" element={<AllBeautySalonCatalogPage />} />
            <Route path="salon-services" element={<AllBeautySalonServicePage />} />
          </Route>
        </Route>
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/admin" element={isAdmin ? <AdminPage /> : <NotFoundPage />} >
          <Route index element={<HomeAdminPgae />} />
          {/* Các route con của Admin */}
          <Route path="beauty-salon-catalog" element={<BeautySalonCatalogPage />} />
          <Route path="beauty-salon-services/:id" element={<BeautySalonServiceDetailPage />} />
          <Route path="beauty-salon-staffs/:id" element={<StaffCatalogPage />} />
          <Route path="service-catalog" element={<ServiceCatalogPage />} />
          <Route path="user-account" element={<UserAccountPage />} />
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
