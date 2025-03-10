import React, { useState, useEffect } from "react";
import { Form, Select } from "antd";
import { useServiceCatalogData } from "../../hooks/services/ServiceCatalogData";
import { getDetailServiceCatalogs } from "../../apis/services/serviceCatalog";

const { Option } = Select;

export const ServiceCatalogSelect = ({ onServiceSelect, serviceId }) => {
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

export const ServiceCatalogSelectMutiple = ({ onServiceSelect, serviceId }) => {
    const [selectedServices, setSelectedServices] = useState([]);
    const { data, loading, fetchData } = useServiceCatalogData();
    const [detailLoading, setDetailLoading] = useState(false);

    // Fetch danh sách dịch vụ khi component mount
    useEffect(() => {
        fetchData(1);
    }, []);

    // Fetch chi tiết dịch vụ khi `serviceId` thay đổi
    useEffect(() => {
        if (!serviceId || serviceId.length === 0) return;  // Nếu không có `serviceId` thì không fetch

        const fetchServiceDetails = async () => {
            setDetailLoading(true);
            try {
                const responses = await Promise.all(serviceId.map((id) => getDetailServiceCatalogs(id)));  // 🛠 Lấy chi tiết từng `serviceId`
                const ids = responses.map((response) => response?.data?.id).filter(Boolean);  // 🛠 Lọc ra các ID hợp lệ
                setSelectedServices(ids);  // 🛠 Cập nhật mảng `selectedServices` nếu có dữ liệu
            } catch (error) {
                console.error("Lỗi khi lấy chi tiết dịch vụ:", error);
            } finally {
                setDetailLoading(false);
            }
        };

        fetchServiceDetails();
    }, [serviceId]);

    // Khi chọn dịch vụ -> Cập nhật state & gọi callback
    const handleServiceChange = (serviceIds) => {
        setSelectedServices(serviceIds);
        onServiceSelect(serviceIds);
    };

    return (
        <Form.Item label="Chọn dịch vụ" style={{ fontWeight: 500, margin: 3 }}>
            <Select
                mode="multiple"
                placeholder="Chọn dịch vụ"
                loading={loading || detailLoading}
                onChange={handleServiceChange}
                value={selectedServices}
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