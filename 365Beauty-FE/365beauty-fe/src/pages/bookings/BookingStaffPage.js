import React, { useState, useEffect } from 'react';
import { Modal, Card, Button, message } from 'antd';
import '../../styles/BookingStaffPage.css';
import { getAllStaffCatalogBySalonServiceId } from '../../apis/staffs/staffCatalog';

const BookingStaffPage = ({ visible, onClose, onConfirm, salonServiceId, date, timeId }) => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);
    const [isStaffInfoModalOpen, setIsStaffInfoModalOpen] = useState(false);
    const [selectedStaff, setSelectedStaff] = useState(null);

    // Hàm gọi API để lấy danh sách nhân viên
    const fetchData = async () => {
        if (!date || !timeId) return;
        setLoading(true);
        try {
            const response = await getAllStaffCatalogBySalonServiceId({
                salonServiceId,
                bookingDate: `${date.year}-${String(date.month).padStart(2, '0')}-${String(date.day).padStart(2, '0')}`,
                timeId
            });
            setData(response.data);
        } catch (error) {
            message.error('Không thể tải danh sách nhân viên!');
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchData();
    }, [date, timeId]);

    // Hàm mở modal thông tin nhân viên
    const handleOpenStaffInfoModal = (staff) => {
        setSelectedStaff(staff);
        setIsStaffInfoModalOpen(true);
    };

    // Hàm đóng modal thông tin nhân viên
    const handleCloseStaffInfoModal = () => {
        setIsStaffInfoModalOpen(false);
        setSelectedStaff(null);
    };

    // Hàm chọn nhân viên
    const handleSelectStaff = (staff) => {
        setSelectedStaff(staff);  // Lưu đầy đủ thông tin của nhân viên đã chọn
    };

    // Hàm xác nhận chọn nhân viên
    const handleConfirm = () => {
        if (selectedStaff) {
            onConfirm(selectedStaff);  // Truyền đầy đủ thông tin của nhân viên đã chọn
            onClose();
        } else {
            message.warning('Vui lòng chọn nhân viên!');
        }
    };

    return (
        <Modal
            open={visible}
            onCancel={onClose}
            footer={[
                <Button key="cancel" onClick={onClose}>
                    Đóng
                </Button>,
                <Button key="confirm" type="primary" onClick={handleConfirm}>
                    Xác nhận
                </Button>
            ]}
            width={1000}
            style={{ top: '60px' }}
        >
            <div className='container-staff-booking'>
                {data.map((staff) => (
                    <Card
                        key={staff.id}
                        className={`staff-booking ${selectedStaff?.id === staff.id ? 'selected' : ''}`}
                        cover={
                            <div className="staff-booking-image">
                                <img className="card-image" alt={staff.fullName} src={require(`../../assets/${staff.img ?? 'defaultAvatar.png'}`)} />
                            </div>
                        }
                        hoverable
                    >
                        <Card.Meta
                            title={<span onClick={() => handleOpenStaffInfoModal(staff)} className="card-title">{staff.fullName}</span>}
                            description={staff.tel}
                        />
                        <Button
                            type={selectedStaff?.id === staff.id ? 'primary' : 'default'}
                            onClick={() => handleSelectStaff(staff)}
                            style={{ marginTop: 10 }}
                        >
                            {selectedStaff?.id === staff.id ? 'Đã chọn' : 'Chọn nhân viên'}
                        </Button>
                    </Card>
                ))}
            </div>

            {/* Modal thông tin nhân viên */}
            <Modal
                open={isStaffInfoModalOpen}
                onCancel={handleCloseStaffInfoModal}
                footer={null}
            >
                {selectedStaff && (
                    <div className='staff-booking-info'>
                        <div className='container-staff-booking-info'>
                            <div className="staff-booking-info-image">
                                <img className="card-image" alt={selectedStaff.fullName} src={require(`../../assets/${selectedStaff.img ?? 'defaultAvatar.png'}`)} />
                            </div>
                            <div className='staff-booking-info-detail'>
                                <p style={{ fontSize: 20 }}>{selectedStaff.fullName}</p>
                                <p>SĐT: <span style={{ fontWeight: 400 }}>{selectedStaff.tel}</span></p>
                                <p>Chuyên ngành: <span style={{ fontWeight: 400 }}>{selectedStaff.occupationName}</span></p>
                                <p>Học hàm: <span style={{ fontWeight: 400 }}>{selectedStaff.titleName}</span></p>
                                <p>Học vị: <span style={{ fontWeight: 400 }}>{selectedStaff.degreeName}</span></p>
                            </div>
                        </div>
                        <div>
                            <p style={{ fontSize: 16, fontWeight: 600, marginTop: 10 }}>Giới thiệu: <span style={{ fontWeight: 400 }}>{selectedStaff.introduction}</span></p>
                        </div>
                    </div>
                )}
            </Modal>
        </Modal>
    );
};

export default BookingStaffPage;
