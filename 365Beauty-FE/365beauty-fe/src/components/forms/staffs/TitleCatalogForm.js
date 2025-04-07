import React, { useEffect } from 'react';
import { Modal, Form, Button } from 'antd';
import '../../../styles/component.css';
import { Input } from '../../Input';

export const CreateTitleCatalogForm = ({ open, onCancel, onFinish, form, error }) => {

    return (
        <Modal title={<div className="modal-title">THÊM MỚI DANH MỤC HỌC HÀM</div>} open={open} onCancel={onCancel} footer={null} width={600} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Input label="Tên học hàm" name="Name" placeholder="Nhập tên học hàm" errorMessage={error.Name} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};

export const UpdateTitleCatalogForm = ({ open, onCancel, onFinish, form, error, catalogData }) => {
    useEffect(() => {
        if (catalogData) {
            form.setFieldsValue({
                Name: catalogData.name,
            });
        }
    }, [catalogData, form]); // Chỉ cập nhật khi catalogData thay đổi

    if (!catalogData) { return null; }

    return (
        <Modal title={<div className="modal-title">CẬP NHẬT DANH MỤC HỌC HÀM</div>} open={open} onCancel={onCancel} footer={null} width={600} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Input label="Tên học hàm" name="Name" placeholder="Nhập tên học hàm" errorMessage={error.Name} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit" >Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};