import React from 'react';
import { Layout, Carousel } from 'antd';
import '../styles/BeautyContent.css'
import BannerHome1 from '../assets/BannerHome1.3cd36b.png';
import BannerHome2 from '../assets/BannerHome2.f4abb3.png';
const { Content } = Layout;
const text =
    <div className="text-overlay">
        <span>
            Tự tin lung linh
            <br />
            tỏa sáng mỗi ngày với
        </span>
        <h2>365BEAUTY</h2>
        <p>Đặt lịch chăm sóc da ngay hôm nay</p>
    </div>

class BeautyContent extends React.Component {
    render() {
        return (
            <Content className="content">
                <Carousel autoplay className="CarouselSlide">
                    <div className="image-container">
                        <img src={BannerHome1} alt="Slide 1" style={{ width: '100%', height: 'auto' }} />
                        <div className="text-overlay">
                            <span>
                                Tự tin lung linh
                                <br />
                                tỏa sáng mỗi ngày với
                            </span>
                            <h2>365BEAUTY</h2>
                            <p>Đặt lịch chăm sóc da ngay hôm nay</p>
                        </div>
                    </div>
                    <div className="image-container">
                        <img src={BannerHome2} alt="Slide 2" style={{ width: '100%', height: 'auto' }} />
                        {text}
                    </div>
                </Carousel>
            </Content>

        )
    }
}

export default BeautyContent;