import React from 'react';
import { Button, Form, Upload } from 'antd';
import { PlusOutlined } from '@ant-design/icons';
import '../styles/component.css';

export const ImageInput = ({ imageUrl, handleImageUpload, style, styleImage, label }) => {
    return (
        <Form.Item label={label} className="image-input-container" style={style}>
            <Upload
                beforeUpload={handleImageUpload}
                showUploadList={false}
                accept="image/*"
            >
                <Button icon={<PlusOutlined />}>Chọn hình ảnh</Button>
            </Upload>
            {imageUrl && (
                <div className="image-preview" style={styleImage}>
                    <img
                        src={imageUrl}
                        alt="Hình đã chọn"
                    />
                </div>
            )}
        </Form.Item>
    );
};