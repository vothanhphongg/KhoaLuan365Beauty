import React, { useState, useEffect } from "react";
import { Form, Select } from "antd";
import useDegreeCatalogData from "../../hooks/staffs/DegreeCatalogData";
import { getDetailDegreeCatalog } from "../../apis/staffs/degreeCatalog";

const { Option } = Select;

const DegreeCatalogSelect = ({ onDegreeSelect, DegreeId }) => {
    const [selectedDegree, setSelectedDegree] = useState(DegreeId || null);
    const { data, loading, fetchData } = useDegreeCatalogData();
    const [detailLoading, setDetailLoading] = useState(false);

    // Fetch danh sách dịch vụ khi component mount
    useEffect(() => {
        fetchData(1);
    }, []);

    useEffect(() => {
        console.log(DegreeId);
        if (!DegreeId) return;

        const fetchDegreeDetails = async () => {
            setDetailLoading(true);
            try {
                const response = await getDetailDegreeCatalog(DegreeId);
                console.log(response.data);
                setSelectedDegree(response.data.id);
            } catch (error) {
                console.error("Lỗi khi lấy chi tiết dịch vụ:", error);
            } finally {
                setDetailLoading(false);
            }
        };

        fetchDegreeDetails();
    }, [DegreeId]);

    // Khi chọn dịch vụ -> Cập nhật state & gọi callback
    const handleDegreeChange = (DegreeId) => {
        setSelectedDegree(DegreeId);
        onDegreeSelect(DegreeId);

    };

    return (
        <Form.Item label="Chọn học vị" style={{ fontWeight: 500, margin: 3 }}>
            <Select
                placeholder="Chọn học vị"
                loading={loading || detailLoading}
                onChange={handleDegreeChange}
                value={selectedDegree}
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

export default DegreeCatalogSelect;
