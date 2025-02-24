import React, { useEffect } from 'react';
import { Modal, Form, Button } from 'antd';
import '../../../styles/component.css';
import { Input } from '../../Input';
import { ImageInput } from '../../Image';

const { Item } = Form;

export const CreateServiceCatalogForm = ({ open, onCancel, onFinish, form, imageUrl, handleImageUpload, error }) => {

    return (
        <Modal title={<div className="modal-title">THÊM MỚI DANH MỤC DỊCH VỤ</div>} open={open} onCancel={onCancel} footer={null} width={600} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Input label="Tên dịch vụ" name="Name" placeholder="Nhập tên dịch vụ" errorMessage={error.Name} />
                <ImageInput imageUrl={imageUrl} handleImageUpload={handleImageUpload} style={{ height: 'auto', width: '145px' }} label={'Hình ảnh'} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};

export const UpdateServiceCatalogForm = ({ open, onCancel, onFinish, form, imageUrl, handleImageUpload, error, catalogData }) => {

    useEffect(() => {
        if (catalogData) {
            form.setFieldsValue({
                Name: catalogData.name,
            });
        }
    }, [catalogData, form]); // Chỉ cập nhật khi catalogData thay đổi

    if (!catalogData) { return null; }

    return (
        <Modal title={<div className="modal-title">CẬP NHẬT DANH MỤC DỊCH VỤ</div>} open={open} onCancel={onCancel} footer={null} width={600} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Input label="Tên dịch vụ" name="Name" placeholder="Nhập tên dịch vụ" errorMessage={error.Name} />
                <ImageInput imageUrl={imageUrl || require(`../../../assets/${catalogData?.icon}`)} handleImageUpload={handleImageUpload} style={{ height: 'auto', width: '200px' }} label={'Hình ảnh'} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit" >Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};
