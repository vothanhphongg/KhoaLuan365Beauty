import React, { useEffect } from 'react';
import { Modal, Form, Button } from 'antd';
import '../../../styles/component.css';
import { Input } from '../../Input';

export const CreateOccupationCatalogForm = ({ open, onCancel, onFinish, form, error }) => {

    return (
        <Modal title={<div className="modal-title">THÊM MỚI DANH MỤC NGHỀ NGHIỆP</div>} open={open} onCancel={onCancel} footer={null} width={600} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Input label="Tên nghề nghiệp" name="Name" placeholder="Nhập tên nghề nghiệp" errorMessage={error.Name} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};

export const UpdateOccupationCatalogForm = ({ open, onCancel, onFinish, form, error, catalogData }) => {
    useEffect(() => {
        if (catalogData) {
            form.setFieldsValue({
                Name: catalogData.name,
            });
        }
    }, [catalogData, form]); // Chỉ cập nhật khi catalogData thay đổi

    if (!catalogData) { return null; }

    return (
        <Modal title={<div className="modal-title">CẬP NHẬT DANH MỤC NGHỀ NGHIỆP</div>} open={open} onCancel={onCancel} footer={null} width={600} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Input label="Tên nghề nghiệp" name="Name" placeholder="Nhập tên nghề nghiệp" errorMessage={error.Name} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit" >Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};