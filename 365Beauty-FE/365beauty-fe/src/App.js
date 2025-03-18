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
import BookingPage from './pages/bookings/BookingPage';
import AllBeautySalonCatalogPage from './pages/beautySalons/AllBeautySalonCatalogPage';
import GetAllPage from './pages/base/GetAllPage';
import AllBeautySalonServicePage from './pages/beautySalons/AllBeautySalonServicePage';
import StaffCatalogPage from './pages/staffs/StaffCatalogPage';
import DetailSalonCatalogPage from './pages/beautySalons/DetailBeautySalonCatalogPage';
import AllBeautySalonServiceByServiceIdPage from './pages/beautySalons/AllBeautySalonServiceByServiceIdPage';
import UserAccountPage from './pages/users/UserAccountPage';
import HomeAdminPage from './pages/base/HomeAdminPage';
import BeautySalonPage from './pages/base/BeautySalonPage';
import HomeBeautySalonPage from './pages/base/HomeBeautySalonPage';
import BeautySalonPricePage from './pages/beautySalons/BeautySalonPricePage';
import BookingTypePage from './pages/bookings/BookingTypePage';
import TimePage from './pages/bookings/TimePage';
import BookingSuccessPage from './pages/bookings/BookingSuccessPage';
import ProfilePage from './pages/base/ProfilePage';
import InfoProfilePage from './pages/users/InfoProfilePage';
import UserBookingPage from './pages/users/UserBookingPage';
import StaffAccountPage from './pages/staffs/StaffAccountPage';
import BeautySalonConfirmPage from './pages/beautySalons/BeautySalonConfirmPage';
import BeautySalonReportPage from './pages/beautySalons/BeautySalonReportPage';
import EditProfilePage from './pages/users/EditProfilePage';

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
  const [isBeautySalon, setIsBeautySalon] = useState(false);

  useEffect(() => {
    // Lấy thông tin từ localStorage hoặc API
    const userInfo = JSON.parse(sessionStorage.getItem('userInfo'));
    if (userInfo && userInfo.UserRoles) {
      setIsAdmin(userInfo.UserRoles.some(role => role.name === 'ADMIN'));
      setIsBeautySalon(userInfo.UserRoles.some(role => role.name === 'BEAUTY_SALON'));
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
          <Route path="/booking-success/:id" element={<BookingSuccessPage />} />
          <Route path="/profile/:id" element={<ProfilePage />} />
          <Route path="get-all" element={<GetAllPage />}>
            <Route path="beauty-salons" element={<AllBeautySalonCatalogPage />} />
            <Route path="salon-services" element={<AllBeautySalonServicePage />} />
          </Route>
        </Route>
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/admin" element={isAdmin ? <AdminPage /> : <NotFoundPage />} >
          <Route index element={<HomeAdminPage />} />
          {/* Các route con của Admin */}
          <Route path="beauty-salon-catalog" element={<BeautySalonCatalogPage />} />
          <Route path="beauty-salon-services/:id" element={<BeautySalonServiceDetailPage />} />
          <Route path="beauty-salon-staffs/:id" element={<StaffCatalogPage />} />
          <Route path="service-catalog" element={<ServiceCatalogPage />} />
          <Route path="user-account" element={<UserAccountPage />} />
          <Route path="staff-account" element={<StaffAccountPage />} />
          <Route path="title-catalog" element={<TitleCatalogPage />} />
          <Route path="degree-catalog" element={<DegreeCatalogPage />} />
          <Route path="occupation-catalog" element={<OccupationCatalogPage />} />
          <Route path="booking-type" element={<BookingTypePage />} />
          <Route path="time" element={<TimePage />} />
        </Route>
        <Route path="/beauty-salon" element={isBeautySalon ? <BeautySalonPage /> : <NotFoundPage />} >

          {/* Các route con của BeautySalon */}
          <Route path="beauty-salon-catalog" element={<BeautySalonCatalogPage />} />
          <Route index element={<HomeBeautySalonPage />} />
          <Route path="salon-services/:id" element={<BeautySalonServiceDetailPage />} />
          <Route path="staff-services/:id" element={<StaffCatalogPage />} />
          <Route path="price-services/:id" element={<BeautySalonPricePage />} />
          <Route path="confirm-services/:id" element={<BeautySalonConfirmPage />} />
          <Route path="report-services/:id" element={<BeautySalonReportPage />} />
        </Route>
        <Route element={<ProfilePage />} >
          <Route path="info-profile/:id" element={<InfoProfilePage />} />
          <Route path="edit-profile/:id" element={<EditProfilePage />} />
          <Route path="user-booking/:id" element={<UserBookingPage />} />
        </Route>
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </Router>
  );
}

export default App;
