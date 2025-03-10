import React, { useState, useEffect } from 'react';
import { Modal, Form, Button, Row, Col } from 'antd';
import '../../../styles/component.css';
import { ImageInput } from '../../Image';
import { Input, TextAreaInput } from '../../Input';
import OccupationCatalogSelect from '../../selects/OccupationCatalogSelect';
import LocalizationSelect from '../../selects/LocalizationSelect';
import DegreeCatalogSelect from '../../selects/DegreeCatalogSelect';
import TitleCatalogSelect from '../../selects/TitleCatalogSelect';
import { DateTimePicker } from '../../DateTimePicker';
import { RadioButtonGender } from '../../RadioButton';
import { ServiceCatalogSelectMutiple } from '../../selects/ServiceCatalogSelect';
import moment from 'moment';

export const CreateStaffCatalogForm = ({ open, onCancel, onFinish, form, imageUrl, handleImageUpload, error }) => {
    const [wardId, setWardId] = useState(null);
    const [occId, setOccId] = useState(null);
    const [titleId, settitleId] = useState(null);
    const [degId, setdegId] = useState(null)
    const [serviceIds, setserviceIds] = useState([]);
    useEffect(() => {
        if (wardId) {
            form.setFieldsValue({ WardId: wardId });
        }
        if (occId) {
            form.setFieldsValue({ OccId: occId });
        }
        if (titleId) {
            form.setFieldsValue({ TitleId: titleId });
        }
        if (degId) {
            form.setFieldsValue({ DegId: degId });
        }
        if (serviceIds) {
            form.setFieldsValue({ ServiceId: serviceIds });
        }
    }, [wardId, occId, titleId, degId, serviceIds, form]);

    return (
        <Modal title={<div className="modal-title">THÊM MỚI NHÂN VIÊN THẨM MỸ VIỆN</div>} open={open} onCancel={onCancel} footer={null} width={1000} style={{ top: '20px' }}
        >
            <Form form={form} onFinish={onFinish} layout="vertical">

                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Mã nhân viên" name="Code" placeholder="Nhập mã nhân viên" errorMessage={error.Code} />
                    </Col>
                    <Col span={12}>
                        <Input label="Tên nhân viên" name="Name" placeholder="Nhập tên nhân viên" errorMessage={error.FullName} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Email" name="Email" placeholder="Nhập email" errorMessage={error.Email} />
                    </Col>
                    <Col span={12}>
                        <Input label="Số điện thoại" name="Tel" placeholder="Nhập số điện thoại" errorMessage={error.Tel} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={8}>
                        <Input label="Căn cước công dân" name="IdCard" placeholder="Nhập căn cước công dân" errorMessage={error.IdCard} />
                    </Col>
                    <Col span={8}>
                        <DateTimePicker name="DateOfBirth" />
                    </Col>
                    <Col span={8}>
                        <RadioButtonGender name="Gender" />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={6}>
                        <DegreeCatalogSelect onDegreeSelect={(degId) => setdegId(degId)} />
                        <Input type="hidden" name="DegId" />
                    </Col>
                    <Col span={6}>
                        <TitleCatalogSelect onTitleSelect={(titleId) => settitleId(titleId)} />
                        <Input type="hidden" name="TitleId" />
                    </Col>
                    <Col span={6}>
                        <OccupationCatalogSelect onOccupationSelect={(occId) => setOccId(occId)} />
                        <Input type="hidden" name="OccId" />
                    </Col>
                    <Col span={6}>
                        <ServiceCatalogSelectMutiple onServiceSelect={(serviceIds) => setserviceIds(serviceIds)} />
                        <Input type="hidden" name="ServiceId" />
                    </Col>
                </Row>
                <Row gutter={16} style={{ marginTop: '-40px', marginBottom: '-20px' }}>
                    <Col span={18}>
                        <LocalizationSelect onWardSelect={(wardId) => setWardId(wardId)} />
                        <Input type="hidden" name="WardId" />
                    </Col>
                    <Col span={6}>
                        <Input label="Địa chỉ" name="Address" placeholder="Nhập địa chỉ" errorMessage={error.Address} />
                    </Col>
                </Row>
                <TextAreaInput label="Giới thiệu về nhân viên" name="Introduction" placeholder="Nhập giới thiệu về nhân viên" />
                <ImageInput label="Ảnh đại diện" imageUrl={imageUrl} handleImageUpload={handleImageUpload} style={{ fontWeight: 500, margin: 3, height: 'auto', width: '200px' }} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};

export const UpdateStaffCatalogForm = ({ open, editingRecord, onCancel, onFinish, form, imageUrl, handleImageUpload, error, catalogData }) => {
    const [wardId, setWardId] = useState(null);
    const [degId, setDegId] = useState(null);
    const [titleId, setTitleId] = useState(null);
    const [occId, setOccId] = useState(null);
    const [serviceIds, setServiceIds] = useState([]);
    const [gender, setGender] = useState(null);
    const [dateOfBirth, setDateOfBirth] = useState(null);

    useEffect(() => {
        if (catalogData) {
            form.setFieldsValue({
                Name: catalogData.fullName,
                Code: catalogData.code,
                Email: catalogData.email,
                Tel: catalogData.tel,
                IdCard: catalogData.idCard,
                DateOfBirth: moment(catalogData.dateOfBirth),
                Gender: catalogData.gender,
                Address: catalogData.address,
                Description: catalogData.description,
                WardId: catalogData.wardId,
                DegId: catalogData.degreeId,
                TitleId: catalogData.titleId,
                OccId: catalogData.occupationId,
                ServiceId: catalogData.serviceCatalogs.map(service => service.id) || [],
                Introduction: catalogData.introduction,
            });
            setWardId(catalogData.wardId);
            setDegId(catalogData.degreeId);
            setTitleId(catalogData.titleId);
            setOccId(catalogData.occupationId);
            setServiceIds(catalogData.serviceCatalogs.map(service => service.id) || []);
            setGender(catalogData.gender);
            setDateOfBirth(catalogData.dateOfBirth ? new Date(catalogData.dateOfBirth) : null);
        }
    }, [open, editingRecord, catalogData, form]);

    if (!catalogData) {
        return null;
    }
    return (
        <Modal title={<div className="modal-title">CẬP NHẬT NHÂN VIÊN THẨM MỸ VIỆN</div>} open={open} onCancel={onCancel} footer={null} width={1000} style={{ top: '20px' }}>
            <Form form={form} onFinish={onFinish} layout="vertical">
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Mã nhân viên" name="Code" placeholder="Nhập mã nhân viên" errorMessage={error.Code} />
                    </Col>
                    <Col span={12}>
                        <Input label="Tên nhân viên" name="Name" placeholder="Nhập tên nhân viên" errorMessage={error.FullName} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={12}>
                        <Input label="Email" name="Email" placeholder="Nhập email" errorMessage={error.Email} />
                    </Col>
                    <Col span={12}>
                        <Input label="Số điện thoại" name="Tel" placeholder="Nhập số điện thoại" errorMessage={error.Tel} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={8}>
                        <Input label="Căn cước công dân" name="IdCard" placeholder="Nhập căn cước công dân" errorMessage={error.IdCard} />
                    </Col>
                    <Col span={8}>
                        <DateTimePicker name="DateOfBirth" value={dateOfBirth} onChange={(date) => setDateOfBirth(date)} />
                    </Col>
                    <Col span={8}>
                        <RadioButtonGender name="Gender" value={gender} onChange={(value) => setGender(value)} />
                    </Col>
                </Row>
                <Row gutter={16}>
                    <Col span={6}>
                        <DegreeCatalogSelect DegreeId={degId} onDegreeSelect={(degId) => {
                            setDegId(degId);
                            form.setFieldsValue({ DegId: degId });
                        }} />
                    </Col>
                    <Col span={6}>
                        <TitleCatalogSelect TitleId={titleId} onTitleSelect={(titleId) => {
                            setTitleId(titleId);
                            form.setFieldsValue({ TitleId: titleId });
                        }} />
                    </Col>
                    <Col span={6}>
                        <OccupationCatalogSelect occupationId={occId} onOccupationSelect={(occId) => {
                            setOccId(occId);
                            form.setFieldsValue({ OccId: occId });
                        }} />
                    </Col>
                    <Col span={6}>
                        <ServiceCatalogSelectMutiple
                            onServiceSelect={(serviceIds) => setServiceIds(serviceIds)}
                            serviceId={serviceIds}
                        />
                        <Input type="hidden" name="ServiceId" />
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
                <TextAreaInput label="Giới thiệu về nhân viên" name="Introduction" placeholder="Nhập giới thiệu về nhân viên" />
                <ImageInput label="Ảnh đại diện" imageUrl={imageUrl || require(`../../../assets/${catalogData?.img}`)} handleImageUpload={handleImageUpload} style={{ fontWeight: 500, margin: 3, height: 'auto', width: '200px' }} />
                <Button type="primary" style={{ margin: '10px 10px 0px 5px' }} htmlType="submit">Lưu</Button>
                <Button onClick={onCancel}>Hủy</Button>
            </Form>
        </Modal>
    );
};
