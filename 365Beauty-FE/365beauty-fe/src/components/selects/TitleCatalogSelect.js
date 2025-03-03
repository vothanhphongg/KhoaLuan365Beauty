import React, { useState, useEffect } from "react";
import { Form, Select } from "antd";
import useTitleCatalogData from "../../hooks/staffs/TitleCatalogData";
import { getDetailTitleCatalog } from "../../apis/staffs/titleCatalog";

const { Option } = Select;

const TitleCatalogSelect = ({ onTitleSelect, TitleId }) => {
    const [selectedTitle, setSelectedTitle] = useState(TitleId || null);
    const { data, loading, fetchData } = useTitleCatalogData();
    const [detailLoading, setDetailLoading] = useState(false);

    // Fetch danh sách dịch vụ khi component mount
    useEffect(() => {
        fetchData(1);
    }, []);

    useEffect(() => {
        console.log(TitleId);
        if (!TitleId) return;

        const fetchTitleDetails = async () => {
            setDetailLoading(true);
            try {
                const response = await getDetailTitleCatalog(TitleId);
                console.log(response.data);
                setSelectedTitle(response.data.id);
            } catch (error) {
                console.error("Lỗi khi lấy chi tiết dịch vụ:", error);
            } finally {
                setDetailLoading(false);
            }
        };

        fetchTitleDetails();
    }, [TitleId]);

    // Khi chọn dịch vụ -> Cập nhật state & gọi callback
    const handleTitleChange = (TitleId) => {
        setSelectedTitle(TitleId);
        onTitleSelect(TitleId);

    };

    return (
        <Form.Item label="Chọn học hàm" style={{ fontWeight: 500, margin: 3 }}>
            <Select
                placeholder="Chọn học hàm"
                loading={loading || detailLoading}
                onChange={handleTitleChange}
                value={selectedTitle}
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

export default TitleCatalogSelect;
