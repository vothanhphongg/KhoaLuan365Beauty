import React, { useEffect } from 'react';
import { Modal, Form, Button } from 'antd';
import '../../../styles/component.css';
import { Input } from '../../Input';

export const CreateBookingTypeForm = ({ open, onCancel, onFinish, form, error }) => {

    return (
        <Modal title={<div className="modal-title">THÊM MỚI LOẠI ĐẶT LỊCH</div>} open={open} onCancel={onCancel} footer={null} width={600} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Input label="Tên loại đặt lịch" name="Name" placeholder="Nhập tên loại đặt lịch" errorMessage={error.Name} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};

export const UpdateBookingTypeForm = ({ open, onCancel, onFinish, form, error, catalogData }) => {
    useEffect(() => {
        if (catalogData) {
            form.setFieldsValue({
                Name: catalogData.name,
            });
        }
    }, [catalogData, form]); // Chỉ cập nhật khi catalogData thay đổi

    if (!catalogData) { return null; }

    return (
        <Modal title={<div className="modal-title">CẬP NHẬT LOẠI ĐẶT LỊCH</div>} open={open} onCancel={onCancel} footer={null} width={600} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Input label="Tên loại đặt lịch" name="Name" placeholder="Nhập tên loại đặt lịch" errorMessage={error.Name} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit" >Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};