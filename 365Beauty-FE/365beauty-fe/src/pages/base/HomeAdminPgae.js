import React, { useState } from "react";
import { Card, Col, Row, Statistic } from "antd";
import { BarChart, Bar, XAxis, YAxis, Tooltip, ResponsiveContainer } from "recharts";
import { useServiceCatalogWithCountData } from "../../hooks/services/ServiceCatalogData";

const HomeAdminPgae = () => {
    const [userCount, setUserCount] = useState(10000);
    const [clinicCount, setClinicCount] = useState(100);
    const serviceCount = useServiceCatalogWithCountData();

    return (
        <div style={{ padding: '5px 15px', backgroundColor: "#f0f2f5" }}>
            <Row gutter={[16, 16]}>
                <Col span={12}>
                    <Card hoverable style={{ borderRadius: 12, boxShadow: "0 2px 8px rgba(0, 0, 0, 0.15)" }}>
                        <Statistic title={<span style={{ fontSize: '18px' }}>Số tài khoản người dùng</span>} value={userCount} />
                    </Card>
                </Col>
                <Col span={12}>
                    <Card hoverable style={{ borderRadius: 12, boxShadow: "0 2px 8px rgba(0, 0, 0, 0.15)" }}>
                        <Statistic title={<span style={{ fontSize: '18px' }}>Số thẩm mỹ viện</span>} value={clinicCount} />
                    </Card>
                </Col>
            </Row>
            <Card style={{ marginTop: 24, borderRadius: 12, boxShadow: "0 2px 8px rgba(0, 0, 0, 0.15)" }}>
                <h3 style={{ textAlign: "center", fontSize: '20px', fontWeight: 500 }}>Lượt sử dụng dịch vụ</h3>
                <ResponsiveContainer width="100%" height={370}>
                    <BarChart data={serviceCount}>
                        <XAxis dataKey="name" />
                        <YAxis />
                        <Tooltip />
                        <Bar dataKey="count" fill="#c41c8b" barSize={50} />
                    </BarChart>
                </ResponsiveContainer>
            </Card>
        </div>
    );
};

export default HomeAdminPgae;
