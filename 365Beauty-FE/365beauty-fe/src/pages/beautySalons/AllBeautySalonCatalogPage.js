import React from 'react';
import { useNavigate } from 'react-router-dom';
import { Card } from 'antd';
import '../../styles/AllBeautySalonCatalogPage.css';
import useBeautySalonCatalogData from '../../hooks/beautySalons/beautySalonCatalogData';

const AllBeautySalonCatalogPage = () => {
    const navigate = useNavigate();
    const { data: salons } = useBeautySalonCatalogData();


    return (
        <div className='all-salon-container' >
            <span style={{ fontSize: '1.5rem', fontWeight: '500', color: ' rgb(75, 75, 75)', paddingLeft: 10 }}>
                Tất cả cơ sở làm đẹp
            </span>
            <div className="all-salon-card">
                {salons.map((salon) => (
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
        </div>
    );
};

export default AllBeautySalonCatalogPage;
