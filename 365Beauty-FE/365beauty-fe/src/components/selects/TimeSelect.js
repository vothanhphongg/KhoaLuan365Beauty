import React, { useState, useEffect } from "react";
import { Form, Select } from "antd";
import { getDetailServiceCatalogs } from "../../apis/services/serviceCatalog";
import useTimeData from "../../hooks/bookings/timeData";
import { getDetailTime } from "../../apis/bookings/times";

const { Option } = Select;

export const TimeSelectMutiple = ({ onTimeSelect, timeId }) => {
    const [selectedTime, setSelectedTime] = useState([]); // 🛠 Lưu trữ mảng dịch vụ
    const { data, loading, fetchData } = useTimeData();
    const [detailLoading, setDetailLoading] = useState(false);

    // Fetch danh sách dịch vụ khi component mount
    useEffect(() => {
        fetchData();
    }, []);

    useEffect(() => {
        if (!timeId || timeId.length === 0) return;  // Nếu không có `timeId` thì không fetch

        const fetchTimeDetails = async () => {
            setDetailLoading(true);
            try {
                const responses = await Promise.all(timeId.map((id) => getDetailTime(id)));  // 🛠 Lấy chi tiết từng `timeId`
                const ids = responses.map((response) => response?.data?.id).filter(Boolean);  // 🛠 Lọc ra các ID hợp lệ
                setSelectedTime(ids);  // 🛠 Cập nhật mảng `selectedTime` nếu có dữ liệu
            } catch (error) {
                console.error("Lỗi khi lấy chi tiết thời gian:", error);
            } finally {
                setDetailLoading(false);
            }
        };

        fetchTimeDetails();
    }, [timeId]);

    // Khi chọn dịch vụ -> Cập nhật state & gọi callback
    const handleTimeChange = (timeId) => {
        setSelectedTime(timeId);         // 🛠 Lưu trữ mảng các dịch vụ đã chọn
        onTimeSelect(timeId);             // 🛠 Trả về mảng các `serviceId`
    };

    return (
        <Form.Item label="Chọn thời gian" style={{ fontWeight: 500, margin: 3 }}>
            <Select
                mode="multiple"                        // 🛠 Cho phép chọn nhiều dịch vụ
                placeholder="Chọn thời gian"
                loading={loading || detailLoading}
                onChange={handleTimeChange}
                value={selectedTime}               // 🛠 Sử dụng mảng `selectedServices`
                allowClear
                style={{ width: "100%", marginBottom: 10 }}
                optionFilterProp="children"
                showSearch
            >
                {data.map((time) => (
                    <Option key={time.id} value={time.id}>
                        {time.times}
                    </Option>
                ))}
            </Select>
        </Form.Item>
    );
};