import React, { useState, useEffect } from "react";
import { Form, Select, Row, Col } from "antd";
import { getAllDistrictsByProvinceId, getAllProvinces, getAllWardsByDistrictId, getDetailWards } from "../../apis/localizations/localization";

const { Option } = Select;

const LocalizationSelect = ({ onWardSelect, wardId }) => {
    const [provinces, setProvinces] = useState([]);
    const [districts, setDistricts] = useState([]);
    const [wards, setWards] = useState([]);
    const [loading, setLoading] = useState(false);

    const [selectedProvince, setSelectedProvince] = useState(null);
    const [selectedDistrict, setSelectedDistrict] = useState(null);
    const [selectedWard, setSelectedWard] = useState(null);

    // Fetch danh sách tỉnh
    useEffect(() => {
        const fetchProvinces = async () => {
            setLoading(true);
            try {
                const response = await getAllProvinces();
                setProvinces(response.data);
            } catch (error) {
                console.error('Lỗi khi lấy danh sách tỉnh:', error);
            } finally {
                setLoading(false);
            }
        };

        fetchProvinces();
    }, []);

    // Nếu có `wardId`, lấy thông tin chi tiết của xã để set giá trị cho các dropdown
    useEffect(() => {
        if (!wardId) return;
        console.log(wardId);
        const fetchWardDetails = async () => {
            setLoading(true);
            try {
                const response = await getDetailWards(wardId);
                const { provinceId, districtName, wardId: selectedWardId } = response.data;

                setSelectedProvince(provinceId);
                setSelectedWard(selectedWardId);

                // Lấy danh sách huyện theo tỉnh đã chọn
                const districtResponse = await getAllDistrictsByProvinceId(provinceId);
                setDistricts(districtResponse.data);

                // Tìm huyện theo `districtName`
                const selectedDistrictObj = districtResponse.data.find(d => d.name === districtName);
                if (selectedDistrictObj) {
                    setSelectedDistrict(selectedDistrictObj.id);

                    // Lấy danh sách xã theo huyện đã chọn
                    const wardsResponse = await getAllWardsByDistrictId(selectedDistrictObj.id);
                    setWards(wardsResponse.data);
                }
            } catch (error) {
                console.error("Lỗi khi lấy chi tiết xã:", error);
            } finally {
                setLoading(false);
            }
        };

        fetchWardDetails();
    }, [wardId]);

    // Khi chọn tỉnh -> Fetch danh sách huyện
    const handleProvinceChange = async (provinceId) => {
        setSelectedProvince(provinceId);
        setSelectedDistrict(null);
        setSelectedWard(null);
        setWards([]);
        setLoading(true);
        try {
            const response = await getAllDistrictsByProvinceId(provinceId);
            setDistricts(response.data);
        } catch (error) {
            console.error('Lỗi khi lấy danh sách huyện:', error);
        } finally {
            setLoading(false);
        }
    };

    // Khi chọn huyện -> Fetch danh sách xã
    const handleDistrictChange = async (districtId) => {
        setSelectedDistrict(districtId);
        setSelectedWard(null);
        setLoading(true);
        try {
            const response = await getAllWardsByDistrictId(districtId);
            setWards(response.data);
        } catch (error) {
            console.error('Lỗi khi lấy danh sách xã:', error);
        } finally {
            setLoading(false);
        }
    };

    // Khi chọn xã -> Gửi `wardId` lên form chính
    const handleWardChange = (wardId) => {
        setSelectedWard(wardId);
        onWardSelect(wardId);
    };

    return (
        <Form.Item label="Chọn địa điểm" style={{ fontWeight: 500, margin: 3 }}>
            {/* Chọn Tỉnh */}
            <Row gutter={16}>
                <Col span={8}>
                    <Select
                        placeholder="Chọn tỉnh"
                        loading={loading}
                        onChange={handleProvinceChange}
                        value={selectedProvince}
                        allowClear
                    >
                        {provinces.map((province) => (
                            <Option key={province.id} value={province.id}>
                                {province.name}
                            </Option>
                        ))}
                    </Select>
                </Col>
                <Col span={8}>
                    <Select
                        placeholder="Chọn huyện"
                        loading={loading}
                        onChange={handleDistrictChange}
                        value={selectedDistrict}
                        allowClear
                        disabled={!selectedProvince}
                    >
                        {districts.map((district) => (
                            <Option key={district.id} value={district.id}>
                                {district.name}
                            </Option>
                        ))}
                    </Select>
                </Col>
                <Col span={8}>
                    <Select
                        placeholder="Chọn xã"
                        loading={loading}
                        onChange={handleWardChange}
                        value={selectedWard}
                        allowClear
                        disabled={!selectedDistrict}
                    >
                        {wards.map((ward) => (
                            <Option key={ward.id} value={ward.id}>
                                {ward.name}
                            </Option>
                        ))}
                    </Select>
                </Col>
            </Row>
        </Form.Item>
    );
};

export default LocalizationSelect;