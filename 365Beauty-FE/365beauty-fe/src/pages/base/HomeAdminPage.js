import React from "react";
import { useSpring, animated } from "@react-spring/web";
import { Card, Col, Row, Statistic } from "antd";
import { BarChart, Bar, XAxis, YAxis, Tooltip, ResponsiveContainer } from "recharts";
import useBeautySalonCatalogData from "../../hooks/beautySalons/beautySalonCatalogData";
import { useUserAccountData } from "../../hooks/users/UserAccountData";
import { useBountUserBookingData } from "../../hooks/users/UserBookingData";

const HomeAdminPage = () => {
    const userAccount = useUserAccountData();
    const { data: salons } = useBeautySalonCatalogData();
    const serviceCount = useBountUserBookingData();
    console.log(serviceCount)
    const salonCount = salons?.length || 0;
    const AnimatedStatistic = ({ value }) => {
        const { number } = useSpring({
            from: { number: 0 },
            to: { number: value },
            config: { duration: 1000 }
        });
        return (
            <animated.span>
                {number.to((n) => Math.floor(n))}
            </animated.span>
        );
    };
    return (
        <div style={{ padding: '5px 15px', backgroundColor: "#f0f2f5" }}>
            <Row gutter={[16, 16]}>
                <Col span={12}>
                    <Card hoverable style={{ borderRadius: 12, boxShadow: "0 2px 8px rgba(0, 0, 0, 0.15)" }}>
                        <Statistic title={<span style={{ fontSize: '18px' }}>Số tài khoản người dùng</span>} valueRender={() => <AnimatedStatistic value={userAccount?.length ?? 0} />} />
                    </Card>
                </Col>
                <Col span={12}>
                    <Card hoverable style={{ borderRadius: 12, boxShadow: "0 2px 8px rgba(0, 0, 0, 0.15)" }}>
                        <Statistic title={<span style={{ fontSize: '18px' }}>Số thẩm mỹ viện</span>} valueRender={() => <AnimatedStatistic value={salonCount} />} />
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

export default HomeAdminPage;
