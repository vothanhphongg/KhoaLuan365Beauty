import React, { useState, useEffect } from "react";
import { Flex, Form, Select } from "antd";
import useBookingStaffData from "../../hooks/bookings/bookingStaffData";

const { Option } = Select;

const BookingStaffSelect = ({ salonServiceId, bookingDate, timeId, staffId, staffName, onStaffChange }) => {
    const { data, loading, fetchData } = useBookingStaffData(salonServiceId, bookingDate, timeId);
    const [selectedStaff, setSelectedStaff] = useState(staffId || null);
    const [selectedStaffName, setSelectedStaffName] = useState(staffName || "");

    useEffect(() => {
        if (staffId && staffName) {
            setSelectedStaff(staffId);
            setSelectedStaffName(staffName);
        } else {
            setSelectedStaff(null);
            setSelectedStaffName(null);
        }
    }, [staffId, staffName, salonServiceId, bookingDate, timeId]); // Reset nếu có thay đổi

    const handleStaffChange = (id) => {
        const selected = data.find(staff => staff.id === id);
        setSelectedStaff(id);
        setSelectedStaffName(selected?.fullName || "");
        onStaffChange(id, selected?.fullName || ""); // Truyền giá trị mới về `catalogData`
    };

    return (
        <Form.Item>
            {selectedStaff && selectedStaffName ? (
                <p>Nhân viên: <span style={{ fontWeight: 400 }}>{selectedStaffName}</span></p>
            ) : (
                <Flex style={{ margin: '10px 0 -10px', alignItems: "center", gap: "10px" }}>
                    <p style={{ margin: 0, whiteSpace: "nowrap" }}>Chọn nhân viên:</p>
                    <Select
                        placeholder="Chọn nhân viên"
                        loading={loading}
                        onChange={handleStaffChange}
                        value={selectedStaff || undefined}
                        allowClear
                        optionFilterProp="children"
                        style={{ width: "50%" }}
                        showSearch
                    >
                        {data.map((staff) => (
                            <Option key={staff.id} value={staff.id}>
                                {staff.fullName}
                            </Option>
                        ))}
                    </Select>
                </Flex>
            )}
        </Form.Item>
    );
};

export default BookingStaffSelect;