import React, { useState, useEffect } from 'react';
import { Modal, Form, Button, Row, Col, message, Input as InputItem } from 'antd';
import { PlusOutlined, DeleteOutlined } from '@ant-design/icons';
import '../../../styles/component.css';
import '../../../styles/BeautySalonConfirmPage.css'
import { ImageInput } from '../../Image';
import { ServiceCatalogSelect } from '../../selects/ServiceCatalogSelect';
import { Input, TextAreaInput } from '../../Input';
import { TimeSelectMutiple } from '../../selects/TimeSelect';
import BookingStaffSelect from '../../selects/BookingStaffSelect';

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

export const CreatePriceServiceForm = ({ open, onCancel, onFinish, form }) => {
    const [timeIds, setTimeIds] = useState([]);
    useEffect(() => {
        if (timeIds) {
            form.setFieldsValue({ TimeIds: timeIds });
        }
    }, [timeIds, form]);
    return (
        <Modal title={<div className="modal-title">TẠO GiÁ VÀ LỊCH DỊCH VỤ</div>} open={open} onCancel={onCancel} footer={null} width={600} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Giá cơ bản" name="basePrice" placeholder="Nhập giá cơ bản" />
                    </Col>
                    <Col span={12}>
                        <Input label="Giá dịch vụ" name="finalPrice" placeholder="Nhập giá dịch vụ" />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Số lượng đặt lịch" name="bookingCount" placeholder="Nhập số lượng đặt lịch" />
                    </Col>
                    <Col span={12}>
                        <TimeSelectMutiple onTimeSelect={(timeIds) => setTimeIds(timeIds)} />
                        <Input type="hidden" name="TimeIds" />
                    </Col>
                </Row>

                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};

export const UpdatePriceServiceForm = ({ open, onCancel, onFinish, form, catalogData }) => {
    const [timeIds, setTimeIds] = useState([]);

    // Cập nhật dữ liệu khi mở Modal
    useEffect(() => {
        if (catalogData) {
            form.setFieldsValue({
                basePrice: catalogData.basePrice || '',
                finalPrice: catalogData.finalPrice || '',
                bookingCount: catalogData.bookingCount || '',
                TimeIds: catalogData.bookingTimes || []  // Thêm TimeIds nếu có
            });
            setTimeIds(catalogData.bookingTimes || []);  // Cập nhật mảng timeIds
        }
    }, [open, catalogData, form]);

    if (!catalogData) {
        return null;
    }

    return (
        <Modal
            title={<div className="modal-title">CẬP NHẬT GIÁ VÀ LỊCH DỊCH VỤ</div>}
            open={open}
            onCancel={onCancel}
            footer={null}
            width={600}
            style={{ top: '20px' }}
        >
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Row gutter={16}>
                    <Col span={12}>
                        <Input
                            label="Giá cơ bản"
                            name="basePrice"
                            placeholder="Nhập giá cơ bản"
                        />
                    </Col>
                    <Col span={12}>
                        <Input
                            label="Giá dịch vụ"
                            name="finalPrice"
                            placeholder="Nhập giá dịch vụ"
                        />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12}>
                        <Input
                            label="Số lượng đặt lịch"
                            name="bookingCount"
                            placeholder="Nhập số lượng đặt lịch"
                        />
                    </Col>
                    <Col span={12}>
                        <TimeSelectMutiple
                            onTimeSelect={(timeIds) => setTimeIds(timeIds)}
                            timeId={timeIds}
                        />
                        <Input type="hidden" name="TimeIds" />
                    </Col>
                </Row>

                <Button
                    type="primary"
                    style={{ margin: '10px 10px 0px 5px' }}
                    htmlType="submit"
                >
                    Lưu
                </Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};

export const ConfirmUserBookingForm = ({ open, onCancel, onFinish, form, catalogData, setCatalogData }) => {
    const [selectedStaff, setSelectedStaff] = useState(null);

    const handleConfirm = () => {
        if (!catalogData.staffId) {
            message.warning("Vui lòng chọn nhân viên trước khi xác nhận!");
            return;
        }
        const updatedData = { ...catalogData, isActived: 1 };
        setCatalogData(updatedData);
        onFinish(updatedData);
    };

    const handleStaffChange = (id, name) => {
        setSelectedStaff(id);
        setCatalogData(prev => ({ ...prev, staffId: id, staffName: name }));
    };

    const handleComplete = () => {
        const updatedData = { ...catalogData, isActived: 2 };
        setCatalogData(updatedData);
        onFinish(updatedData);
    };

    const handleCancel = () => {
        const updatedData = { ...catalogData, isActived: 4 };
        setCatalogData(updatedData);
        onFinish(updatedData);
    };

    if (!catalogData) {
        return null;
    }
    return (
        <Modal
            title={<div className="modal-title">XÁC NHẬN ĐẶT LỊCH</div>}
            open={open}
            onCancel={onCancel}
            footer={null}
            width={700}
            style={{ top: '10px', padding: 20 }}
        >
            <Form form={form} onFinish={onFinish} layout="vertical">
                <p style={{ textAlign: 'end', fontSize: 16, fontWeight: 500 }}>
                    Ngày tạo lịch: {new Date(catalogData.createdDate).toLocaleDateString('vi-VN')}
                </p>
                <div className='container-form-confirm-avatar'>
                    <div className='form-confirm-avatar-image'>
                        <img src={require(`../../../assets/${catalogData.userAvatar ?? 'defaultAvatar.png'}`)} alt={catalogData.userName} />
                    </div>
                    <div className='form-confirm-avatar-info'>
                        <p>Tên người đặt lịch: <span style={{ fontWeight: 400 }}>{catalogData.userName}</span></p>
                        <p>Số điện thoại: <span style={{ fontWeight: 400 }}>{catalogData.userTel}</span></p>
                        <p>Email: <span style={{ fontWeight: 400 }}>{catalogData.userEmail}</span></p>
                    </div>
                </div>
                <div className='container-form-confirm-booking-info'>
                    <p>Dịch vụ: <span style={{ fontWeight: 400 }}>{catalogData.salonServiceName}</span></p>
                    <p>Ngày đặt lịch: <span style={{ fontWeight: 400 }}>{new Date(catalogData.bookingDate).toLocaleDateString('vi-VN')}</span></p>
                    <p>Thời gian: <span style={{ fontWeight: 400 }}>{catalogData.times}</span></p>
                    <BookingStaffSelect
                        salonServiceId={catalogData.salonServiceId}
                        bookingDate={catalogData.bookingDate}
                        timeId={catalogData.timeId}
                        staffId={catalogData.staffId}
                        staffName={catalogData.staffName}
                        onStaffChange={handleStaffChange}
                    />
                    <p>Loại đặt lịch: <span style={{ fontWeight: 400 }}>{catalogData.bookingTypeName}</span></p>
                    <p>Mô tả: <span style={{ fontWeight: 400 }}>{catalogData.description}</span></p>
                    <p>Giá dịch vụ: <span style={{ fontWeight: 400 }}>{catalogData.price.toLocaleString('vi-VN')}đ</span></p>
                </div>

                {/* Điều kiện hiển thị nút */}
                {catalogData.isActived === 0 && (
                    <>
                        <Button
                            type="primary"
                            onClick={handleConfirm}
                        >
                            Xác nhận
                        </Button>
                        <Button onClick={handleCancel}>Hủy lịch</Button>
                    </>
                )}
                {catalogData.isActived === 1 && (
                    <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} onClick={handleComplete}>
                        Hoàn thành
                    </Button>
                )}
            </Form>
        </Modal>
    );
};