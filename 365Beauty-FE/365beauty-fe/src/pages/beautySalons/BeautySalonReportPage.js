import React from "react";
import { useSpring, animated } from "@react-spring/web";
import { useParams } from 'react-router-dom';
import { Card, Col, Row, Statistic } from "antd";
import { BarChart, Bar, XAxis, YAxis, Tooltip, ResponsiveContainer } from "recharts";
import { useBountUserBookingBySalonIdData } from "../../hooks/users/UserBookingData";

const BeautySalonReportPage = () => {
    const { id } = useParams();
    const serviceCount = useBountUserBookingBySalonIdData(id);
    const total = serviceCount?.reduce((acc, item) => {
        acc.count += item.count;
        acc.amount += item.amount;
        return acc;
    }, { count: 0, amount: 0 });

    console.log(total.count);  // Tổng số lượt đặt
    console.log(total.amount); // Tổng doanh thu

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
                        <Statistic title={<span style={{ fontSize: '18px' }}>Tổng lượt đặt lịch trong tháng</span>} valueRender={() => <AnimatedStatistic value={total.count} />} />
                    </Card>
                </Col>
                <Col span={12}>
                    <Card hoverable style={{ borderRadius: 12, boxShadow: "0 2px 8px rgba(0, 0, 0, 0.15)" }}>
                        <Statistic
                            title={<span style={{ fontSize: '18px' }}>Tổng doanh thu trong tháng</span>}
                            value={total?.amount ?? 0}
                            formatter={val => `${val.toLocaleString('vi-VN')} đ`}
                        />
                    </Card>
                </Col>
            </Row>
            <Card style={{ marginTop: 24, borderRadius: 12, boxShadow: "0 2px 8px rgba(0, 0, 0, 0.15)" }}>
                <h3 style={{ textAlign: "center", fontSize: '20px', fontWeight: 500 }}>Lượt sử dụng dịch vụ</h3>
                <ResponsiveContainer width="100%" height={370}>
                    <BarChart data={serviceCount}>
                        <XAxis
                            dataKey="name"
                            tick={{ textAnchor: 'middle' }}
                            tickFormatter={(value) =>
                                value.length > 10 ? `${value.substring(0, 10)}...` : value
                            }
                        />
                        <YAxis />
                        <Tooltip />
                        <Bar dataKey="count" fill="#c41c8b" barSize={50} />
                    </BarChart>
                </ResponsiveContainer>

            </Card>
        </div>
    );
};

export default BeautySalonReportPage;
