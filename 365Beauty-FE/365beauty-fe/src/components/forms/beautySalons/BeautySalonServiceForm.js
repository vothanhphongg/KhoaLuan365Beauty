import React, { useState, useEffect } from 'react';
import { Modal, Form, Button, Row, Col, Input as InputItem, Descriptions } from 'antd';
import { PlusOutlined, DeleteOutlined } from '@ant-design/icons';
import '../../../styles/component.css';
import { ImageInput } from '../../Image';
import ServiceCatalogSelect from '../../selects/ServiceCatalogSelect';
import { Input, TextAreaInput } from '../../Input';

export const CreateBeautySalonServiceForm = ({ open, onCancel, onFinish, form }) => {

    const handleSubImageUpload = (file, index) => {
        const imageUrl = URL.createObjectURL(file);  // Tạo URL tạm thời cho hình ảnh
        const fileName = file.name;

        const updatedBeautySalonServices = form.getFieldValue('beautySalonServices').map((item, idx) => {
            if (idx === index) {
                return { ...item, image: imageUrl, imageName: fileName };
            }
            return item;
        });

        form.setFieldsValue({
            beautySalonServices: updatedBeautySalonServices,
        });
        return false;
    };

    const handleServiceSelect = (serviceId, index) => {
        const updatedServices = form.getFieldValue('beautySalonServices').map((item, idx) => {
            if (idx === index) {
                return { ...item, serviceId };
            }
            return item;
        });

        form.setFieldsValue({ beautySalonServices: updatedServices });
    };
    return (
        <Modal title={<div className="modal-title">THÊM MỚI DỊCH VỤ THẨM MỸ VIỆN</div>} open={open} onCancel={onCancel} footer={null} width={1000} style={{ top: '20px' }}
        >
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Form.List name="beautySalonServices" initialValue={[{ name: '', image: null, imageName: '' }]} >
                    {(fields, { add, remove }) => (
                        <>
                            {fields.map(({ key, name }) =>
                            (
                                <>
                                    <Row gutter={16}>
                                        <Col span={12}>
                                            <Form.Item name={[name, 'name']} label="Tên dịch vụ thẩm mỹ" style={{ fontWeight: 500, margin: 3 }}>
                                                <InputItem placeholder="Nhập tên dịch vụ thẩm mỹ" />
                                            </Form.Item>
                                            <Form.Item name={[name, 'description']} label="Mô tả dịch vụ thẩm mỹ" style={{ fontWeight: 500, margin: 3 }}>
                                                <InputItem.TextArea placeholder="Nhập mô tả dịch vụ thẩm mỹ viện" autoSize={{ minRows: 4 }} />
                                            </Form.Item>
                                        </Col>
                                        <Col span={6}>
                                            <Form.Item name={[name, 'serviceId']} rules={[{ required: true, message: 'Vui lòng chọn dịch vụ!' }]}>
                                                <ServiceCatalogSelect
                                                    onServiceSelect={(serviceId) => handleServiceSelect(serviceId, name)}
                                                    serviceId={form.getFieldValue(['beautySalonServices', name, 'serviceId'])}
                                                />
                                            </Form.Item>
                                        </Col>
                                        <Col span={4}>
                                            <Form.Item name={[name, 'image']} label="Hình ảnh" style={{ fontWeight: 500, margin: 3 }}>
                                                <ImageInput
                                                    handleImageUpload={(file) => handleSubImageUpload(file, name)}
                                                    imageUrl={form.getFieldValue(['beautySalonServices', name, 'image'])}
                                                    style={{ height: 'auto', width: '120px' }}
                                                />
                                            </Form.Item>
                                        </Col>
                                        <Col span={2}>
                                            <Button type="danger" onClick={() => remove(name)} icon={<DeleteOutlined style={{ fontSize: '1.2rem' }} />} style={{ color: 'red' }} />
                                        </Col>
                                    </Row>
                                    <hr style={{ margin: '10px 0', borderTop: '1px solid black' }} />
                                </>
                            ))}
                            <Form.Item>
                                <Button type="dashed" onClick={() => add()} icon={<PlusOutlined />}> Thêm dịch vụ con </Button>
                            </Form.Item>
                        </>
                    )}
                </Form.List>
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};

export const UpdateBeautySalonServiceForm = ({ open, onCancel, onFinish, form, imageUrl, handleImageUpload, error, catalogData }) => {
    const [serviceId, setServiceId] = useState(null);
    useEffect(() => {
        if (catalogData) {
            console.log(catalogData);
            form.setFieldsValue({
                Id: catalogData.id,
                Name: catalogData.name,
                Description: catalogData.description,
                ServiceId: catalogData.serviceId,
            });
            setServiceId(catalogData.serviceId)
        }

    }, [open, catalogData, form]);


    if (!catalogData) { return null; }
    return (
        <Modal title={<div className="modal-title">CẬP NHẬT DỊCH VỤ THẨM MỸ VIỆN</div>} open={open} onCancel={onCancel} footer={null} width={1000} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Tên dịch vụ thẩm mỹ" name="Name" placeholder="Nhập tên dịch vụ thẩm mỹ" errorMessage={error.Name} />
                        <TextAreaInput label="Mô tả dịch vụ thẩm mỹ" name="Description" placeholder="Nhập mô tả dịch vụ thẩm mỹ" errorMessage={error.Name} />
                    </Col>
                    <Col span={6}>
                        <ServiceCatalogSelect
                            onServiceSelect={(serviceId) => {
                                setServiceId(serviceId);
                                form.setFieldsValue({ ServiceId: serviceId }); // Đúng giá trị mới
                            }}
                            serviceId={serviceId}
                        />                        <Input type="hidden" name="ServiceId" />
                    </Col>
                    <Col span={4}>
                        <ImageInput label='Hình ảnh' imageUrl={imageUrl || require(`../../../assets/${catalogData?.image}`)} handleImageUpload={handleImageUpload} style={{ fontWeight: 500, margin: 3, height: 'auto', width: '120px' }} />
                    </Col>
                </Row>
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};
