import React from 'react';
import '../styles/component.css';

export const DangKyDangNhap = ({ text, style }) => {
    return <h2 className="textDangKyDangNhap" style={style}>{text}</h2>;
};

export const Logo365Beauty = ({ style }) => {
    return <h1 className="Logo365Beauty" style={style}>365BEAUTY</h1>;
};
