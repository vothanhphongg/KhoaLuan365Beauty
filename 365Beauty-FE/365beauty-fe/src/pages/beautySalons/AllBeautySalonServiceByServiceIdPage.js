import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';
import { Card, Layout, Button } from 'antd';
import '../../styles/AllBeautySalonServiceByServiceIdPage.css';
import { useBeautySalonServiceByServiceIdData } from '../../hooks/beautySalons/beautySalonServiceData';
import { getDetailServiceCatalogs } from '../../apis/services/serviceCatalog';
const { Content } = Layout;

const AllBeautySalonServiceByServiceIdPage = () => {
    const navigate = useNavigate();
    const [service, setData] = useState({});
    const { id } = useParams();
    const salonservices = useBeautySalonServiceByServiceIdData(id);
    console.log(salonservices);

    useEffect(() => {
        const fetchSalonServiceDetail = async () => {
            const response = await getDetailServiceCatalogs(id);
            setData(response.data);
        };
        fetchSalonServiceDetail();
    }, [id]);

    // Phân trang
    const [currentPage, setCurrentPage] = useState(1);
    const recordsPerPage = 15;  // 15 bản ghi mỗi trang
    const indexOfLastRecord = currentPage * recordsPerPage;
    const indexOfFirstRecord = indexOfLastRecord - recordsPerPage;
    const currentRecords = salonservices.slice(indexOfFirstRecord, indexOfLastRecord);

    // Chuyển trang
    const nextPage = () => {
        if (indexOfLastRecord < salonservices.length) setCurrentPage(prev => prev + 1);
    };

    const prevPage = () => {
        if (currentPage > 1) setCurrentPage(prev => prev - 1);
    };

    return (
        <Content className='content-get-all-service-by-service-id'>
            <span style={{ fontSize: '1.5rem', fontWeight: '500', color: 'rgb(75, 75, 75)', paddingLeft: 10 }}>
                Tất cả dịch vụ đặt lịch {service.name}
            </span>
            <div className="all-service-card">
                {currentRecords.map((salonService) => (
                    <Card
                        key={salonService.id}
                        className="all-service-custom-card"
                        cover={
                            <div className="card-image-container">
                                <div className="discount-badge">{salonService.precentDiscount}%</div>
                                <img className="card-image" alt={salonService.name} src={require(`../../assets/${salonService.image}`)} />
                            </div>
                        }
                        onClick={() => navigate(`/detailsalonservice/${salonService.id}`)}
                    >
                        <Card.Meta
                            title={<span className="card-title">{salonService.name}</span>}
                            description={<span className="final-price">{salonService.finalPrice.toLocaleString('vi-VN')}đ</span>}
                        />
                        <span className="base-price">{salonService.basePrice.toLocaleString('vi-VN')}đ</span>
                    </Card>
                ))}
            </div>

            {/* Nút chuyển trang */}
            <div style={{ display: 'flex', justifyContent: 'end', marginTop: 20 }}>
                <Button onClick={prevPage} disabled={currentPage === 1}>Trang trước</Button>
                <span style={{ margin: '0 10px', lineHeight: '32px' }}>Trang {currentPage}</span>
                <Button onClick={nextPage} disabled={indexOfLastRecord >= salonservices.length}>Trang sau</Button>
            </div>
        </Content>
    );
};

export default AllBeautySalonServiceByServiceIdPage;
