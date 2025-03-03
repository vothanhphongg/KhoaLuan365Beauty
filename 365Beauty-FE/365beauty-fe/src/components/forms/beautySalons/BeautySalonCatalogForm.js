import React, { useState, useEffect } from 'react';
import { Modal, Form, Row, Col, Button, Upload, message } from "antd";
import { PlusOutlined } from "@ant-design/icons";
import { Input, TextAreaInput } from '../../Input';
import '../../../styles/component.css';
import { ImageInput } from '../../Image';
import LocalizationSelect from '../../selects/LocalizationSelect';

export const CreateBeautySalonCatalogForm = ({ open, onCancel, onFinish, form, imageUrl, handleImageUpload, error }) => {
    const [wardId, setWardId] = useState(null);
    const [fileList, setFileList] = useState([]);

    useEffect(() => {
        if (wardId) {
            form.setFieldsValue({ WardId: wardId });
        }
    }, [wardId, form]);

    const handleChange = ({ fileList: newFileList }) => {
        if (newFileList.length > 5) {
            message.warning("Chỉ được tải lên tối đa 5 ảnh.");
            return;
        }
        setFileList(newFileList);
        form.setFieldsValue({ ListImage: newFileList.map((file) => file.name) });
    };

    return (
        <Modal title={<div className="modal-title">THÊM MỚI THẨM MỸ VIỆN</div>} open={open} onCancel={onCancel} footer={null} width={1000} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">

                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Mã thẩm mỹ viện" name="Code" placeholder="Nhập mã thẩm mỹ viện" errorMessage={error.Code} />
                    </Col>
                    <Col span={12}>
                        <Input label="Tên thẩm mỹ viện" name="Name" placeholder="Nhập tên thẩm mỹ viện" errorMessage={error.Name} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Số điện thoại" name="Tel" placeholder="Nhập số điện thoại" errorMessage={error.Tel} />
                    </Col>
                    <Col span={12}>
                        <Input label="Email" name="Email" placeholder="Nhập email" errorMessage={error.Email} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Website" name="Website" placeholder="Nhập Website" errorMessage={error.Website} />
                    </Col>
                    <Col span={12}>
                        <Input label="Thời gian làm việc" name="WorkingDate" placeholder="Nhập thời gian làm việc" errorMessage={error.WorkingDate} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={18}>
                        <LocalizationSelect onWardSelect={(wardId) => setWardId(wardId)} />
                        <Input type="hidden" name="WardId" />
                    </Col>
                    <Col span={6}>
                        <Input label="Địa chỉ" name="Address" placeholder="Nhập địa chỉ" errorMessage={error.Address} />
                    </Col>
                </Row>
                <TextAreaInput label="Mô tả thẩm mỹ viện" name="Description" placeholder="Nhập mô tả" />
                <Row gutter={16}>
                    <Col span={8}>
                        <ImageInput label="Hình ảnh" imageUrl={imageUrl} handleImageUpload={handleImageUpload} style={{ fontWeight: 500, margin: 3, height: 'auto', width: '180px' }} />

                    </Col>
                    <Col span={16}>
                        {/* Upload nhiều ảnh với Ant Design */}
                        <Form.Item label="Hình ảnh chi tiết (tối đa 5 ảnh)" style={{ fontWeight: 500, margin: 3 }}>
                            <Upload
                                listType="picture-card"
                                fileList={fileList}
                                onChange={handleChange}
                                beforeUpload={() => false}
                            >
                                {fileList.length >= 5 ? null : (
                                    <div>
                                        <PlusOutlined /> {/* Icon to hơn */}
                                        <div style={{ marginTop: 8, fontSize: '14px', fontWeight: 400 }}>Chọn hình ảnh</div> {/* Chữ to hơn */}
                                    </div>
                                )}
                            </Upload>
                            <Input type="hidden" name="ListImage" />
                        </Form.Item>

                    </Col>
                </Row>


                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>

            {/* CSS để hiển thị nút xóa khi hover và đổi chữ "Choose file" thành "Chọn hình ảnh" */}
            <style>
                {`
                    input[type="file"]::file-selector-button {
                        padding: 20px;
                        border: 1px solid black;
                        background: none;
                        color: black;
                        cursor: pointer;
                    }
                    input[type="file"]::file-selector-button:hover {
                        background-color: #f0f0f0;
                    }
                    .delete-btn {
                        position: absolute;
                        top: 5px;
                        right: 5px;
                        background: rgba(0, 0, 0, 0.6);
                        color: #fff;
                        border: none;
                        border-radius: 50%;
                        cursor: pointer;
                        padding: 2px 5px;
                        display: none;  /* Ẩn mặc định */
                    }
                    .image-container:hover .delete-btn {
                        display: block;  /* Hiện khi hover */
                    }
                `}
            </style>
        </Modal>
    );
};



export const UpdateBeautySalonCatalogForm = ({ open, editingRecord, onCancel, onFinish, form, imageUrl, handleImageUpload, error, catalogData }) => {
    const [wardId, setWardId] = useState(null);
    useEffect(() => {
        if (catalogData) {
            form.setFieldsValue({
                Name: catalogData.name,
                Code: catalogData.code,
                Email: catalogData.email,
                Tel: catalogData.tel,
                WorkingDate: catalogData.workingDate,
                Website: catalogData.website,
                Address: catalogData.address,
                Description: catalogData.description,
                WardId: catalogData.wardId,
            });
            setWardId(catalogData.wardId);
        }
    }, [open, editingRecord, catalogData, form]);
    if (!catalogData) {
        return null;
    }
    return (
        <Modal title={<div className="modal-title">CẬP NHẬT THẨM MỸ VIỆN</div>} open={open} onCancel={onCancel} footer={null} width={1000} style={{ top: '20px' }} >
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Mã thẩm mỹ viện" name="Code" placeholder="Nhập mã thẩm mỹ viện" errorMessage={error.Code} />
                    </Col>
                    <Col span={12}>
                        <Input label="Tên thẩm mỹ viện" name="Name" placeholder="Nhập tên thẩm mỹ viện" errorMessage={error.Name} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Số điện thoại" name="Tel" placeholder="Nhập số điện thoại" errorMessage={error.Tel} />
                    </Col>
                    <Col span={12}>
                        <Input label="Email" name="Email" placeholder="Nhập email" errorMessage={error.Email} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Website" name="Website" placeholder="Nhập Website" errorMessage={error.Website} />
                    </Col>
                    <Col span={12}>
                        <Input label="Thời gian làm việc" name="WorkingDate" placeholder="Nhập thời gian làm việc" errorMessage={error.WorkingDate} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={18}>
                        <LocalizationSelect onWardSelect={(wardId) => { setWardId(wardId); form.setFieldsValue({ WardId: wardId }) }} wardId={wardId} />
                        <Input type="hidden" name="WardId" /></Col>
                    <Col span={6}>
                        <Input label="Địa chỉ" name="Address" placeholder="Nhập địa chỉ" errorMessage={error.Address} />
                    </Col>
                </Row>
                <TextAreaInput label="Mô tả thẩm mỹ viện" name="Description" placeholder="Nhập mô tả" />
                <ImageInput imageUrl={imageUrl || require(`../../../assets/${catalogData?.image}`)} handleImageUpload={handleImageUpload} style={{ fontWeight: 500, margin: 3, height: 'auto', width: '200px' }} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};