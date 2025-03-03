import React, { useState, useEffect } from "react";
import { Form, Select } from "antd";
import useOccupationCatalogData from "../../hooks/staffs/OccupationCatalogData";
import { getDetailOccupationCatalog } from "../../apis/staffs/occupationCatalog";

const { Option } = Select;

const OccupationCatalogSelect = ({ onOccupationSelect, occupationId }) => {
    const [selectedOccupation, setSelectedOccupation] = useState(occupationId || null);
    const { data, loading, fetchData } = useOccupationCatalogData();
    const [detailLoading, setDetailLoading] = useState(false);

    // Fetch danh sách dịch vụ khi component mount
    useEffect(() => {
        fetchData(1);
    }, []);

    useEffect(() => {
        console.log(occupationId);
        if (!occupationId) return;

        const fetchOccupationDetails = async () => {
            setDetailLoading(true);
            try {
                const response = await getDetailOccupationCatalog(occupationId);
                console.log(response.data);
                setSelectedOccupation(response.data.id);
            } catch (error) {
                console.error("Lỗi khi lấy chi tiết dịch vụ:", error);
            } finally {
                setDetailLoading(false);
            }
        };

        fetchOccupationDetails();
    }, [occupationId]);

    // Khi chọn dịch vụ -> Cập nhật state & gọi callback
    const handleOccupationChange = (occupationId) => {
        setSelectedOccupation(occupationId);
        onOccupationSelect(occupationId);

    };

    return (
        <Form.Item label="Chọn nghề nghiệp" style={{ fontWeight: 500, margin: 3 }}>
            <Select
                placeholder="Chọn nghề nghiệp"
                loading={loading || detailLoading}
                onChange={handleOccupationChange}
                value={selectedOccupation}
                allowClear
                style={{ width: "100%", marginBottom: 5 }}
                optionFilterProp="children"
                showSearch
            >
                {data.map((occ) => (
                    <Option key={occ.id} value={occ.id}>
                        {occ.name}
                    </Option>
                ))}
            </Select>
        </Form.Item>
    );
};

export default OccupationCatalogSelect;
