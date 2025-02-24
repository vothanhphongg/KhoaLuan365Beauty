import React, { useState, useEffect } from "react";
import { Form, Select } from "antd";
import useServiceCatalogData from "../../hooks/services/ServiceCatalogData";
import { getDetailServiceCatalogs } from "../../apis/services/serviceCatalog";

const { Option } = Select;

const ServiceCatalogSelect = ({ onServiceSelect, serviceId }) => {
    const [selectedService, setSelectedService] = useState(serviceId || null);
    const { data, loading, fetchData } = useServiceCatalogData();
    const [detailLoading, setDetailLoading] = useState(false);

    // Fetch danh sách dịch vụ khi component mount
    useEffect(() => {
        fetchData(1);
    }, []);

    // Fetch chi tiết dịch vụ khi `serviceId` thay đổi
    useEffect(() => {
        console.log(serviceId);
        if (!serviceId) return;

        const fetchServiceDetails = async () => {
            setDetailLoading(true);
            try {
                const response = await getDetailServiceCatalogs(serviceId);
                console.log(response.data);
                setSelectedService(response.data.id);
            } catch (error) {
                console.error("Lỗi khi lấy chi tiết dịch vụ:", error);
            } finally {
                setDetailLoading(false);
            }
        };

        fetchServiceDetails();
    }, [serviceId]);

    // Khi chọn dịch vụ -> Cập nhật state & gọi callback
    const handleServiceChange = (serviceId) => {
        setSelectedService(serviceId);
        onServiceSelect(serviceId);
        console.log(serviceId);
    };

    return (
        <Form.Item label="Chọn dịch vụ" style={{ fontWeight: 500, margin: 3 }}>
            <Select
                placeholder="Chọn dịch vụ"
                loading={loading || detailLoading}
                onChange={handleServiceChange}
                value={selectedService}
                allowClear
                style={{ width: "100%", marginBottom: 10 }}
                optionFilterProp="children"
                showSearch
            >
                {data.map((service) => (
                    <Option key={service.id} value={service.id}>
                        {service.name}
                    </Option>
                ))}
            </Select>
        </Form.Item>
    );
};

export default ServiceCatalogSelect;
