import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Card, Button } from 'antd';
import '../../styles/AllBeautySalonCatalogPage.css';
import useBeautySalonCatalogData from '../../hooks/beautySalons/beautySalonCatalogData';

const AllBeautySalonCatalogPage = () => {
    const navigate = useNavigate();
    const { data: salons } = useBeautySalonCatalogData();

    const [currentPage, setCurrentPage] = useState(1);
    const recordsPerPage = 12;  // 12 bản ghi mỗi trang
    const indexOfLastRecord = currentPage * recordsPerPage;
    const indexOfFirstRecord = indexOfLastRecord - recordsPerPage;
    const currentRecords = salons.slice(indexOfFirstRecord, indexOfLastRecord);

    // Chuyển trang
    const nextPage = () => {
        if (indexOfLastRecord < salons.length) setCurrentPage(prev => prev + 1);
    };

    const prevPage = () => {
        if (currentPage > 1) setCurrentPage(prev => prev - 1);
    };

    return (
        <div className='all-salon-container'>
            <span style={{ fontSize: '1.5rem', fontWeight: '500', color: 'rgb(75, 75, 75)', paddingLeft: 10 }}>
                Tất cả cơ sở làm đẹp
            </span>
            <div className="all-salon-card">
                {currentRecords.map((salon) => (
                    <Card
                        key={salon.id}
                        className="all-salon-custom-card"
                        cover={
                            <div className="card-image-container">
                                <img className="card-image" alt={salon.name} src={require(`../../assets/${salon.image}`)} />
                            </div>
                        }
                        onClick={() => navigate(`/detailsaloncatalog/${salon.id}`)}
                    >
                        <Card.Meta
                            title={<span className="card-title">{salon.name}</span>}
                            description={salon.addressFullAscending}
                        />
                    </Card>
                ))}
            </div>

            {/* Nút chuyển trang */}
            <div style={{ display: 'flex', justifyContent: 'end', marginTop: 20 }}>
                <Button onClick={prevPage} disabled={currentPage === 1}>Trang trước</Button>
                <span style={{ margin: '0 10px', lineHeight: '32px' }}>Trang {currentPage}</span>
                <Button onClick={nextPage} disabled={indexOfLastRecord >= salons.length}>Trang sau</Button>
            </div>
        </div>
    );
};

export default AllBeautySalonCatalogPage;
