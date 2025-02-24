import React from 'react';
import '../styles/component.css';

export const DangKyDangNhap = ({ text, style }) => {
    return <h2 className="textDangKyDangNhap" style={style}>{text}</h2>;
};

export const Logo365Beauty = ({ style }) => {
    return <a href="/" style={style}>
        <h1 className="Logo365Beauty" style={{
            userSelect: 'none',
            ...style,
        }} translate="no">365BEAUTY</h1>
    </a>
};

export const ChuyenHuong = ({ style, text, button, locate }) => {
    return (
        <p className='ChuyenHuong'>
            {text}
            <a href={locate} style={style}>
                {button}
            </a>
        </p>
    );
};

export const TextPanel = () => {
    return (
        <div className="text-overlay">
            <span>
                Tự tin lung linh
                <br />
                tỏa sáng mỗi ngày với
            </span>
            <h2>365BEAUTY</h2>
            <p>Đặt lịch chăm sóc da ngay hôm nay</p>
        </div>
    );
};