import React from "react";
import { Layout, Flex } from "antd";
import { Logo365Beauty } from "../../components/Text";
import '../../styles/component.css';
import '../../styles/BeautyFooter.css'
const { Footer } = Layout;

const BeautyFooter = () => {
    return (
        <Footer className="footer">
            <Flex style={{ justifyContent: 'space-between' }}>
                <div>
                    <Flex style={{ width: '20%' }}>
                        <Logo365Beauty />
                    </Flex>
                    <h3>CÔNG TY CỔ PHẦN HỆ SINH THÁI 365</h3>
                    <p>Giấy chứng nhận ĐKKD số 0318326356 do Sở Kế hoạch và Đầu tư TP.HCM cấp ngày 04/03/2024</p>
                    <p> Địa chỉ: P.903, Tầng 9, Tòa nhà Diamond Plaza, 34 Lê Duẩn, P.Bến Nghé, Q.1, TP.HCM</p>
                    <p>Chịu trách nhiệm nội dung: Ông Trương Minh Tuấn</p>
                    <span>Phản ánh chất lượng: 0338 378 879 </span>
                    <span>Email: info@365ejsc.com</span>
                </div>
                <div>
                    <h3>VỀ 365BEAUTY</h3>
                    <p> Về chúng tôi</p>
                    <p>Trung tâm đối tác</p>
                    <p>Quảng cáo</p>
                    <p>Liên hệ hợp tác</p>
                    <p>Đóng góp ý kiến</p>
                </div>
                <div>
                    <h3>DỊCH VỤ</h3>
                    <p>Đặt lịch chăm sóc da</p>
                    <p>Đặt lịch tạo kiểu tóc</p>
                    <p>Đặt lịch trang điểm</p>
                    <p>Đặt lịch làm móng</p>
                    <p>Đặt lịch phun xăm</p>
                </div>
                <div>
                    <h3>HỖ TRỢ</h3>
                    <p>Điều Khoản Sử Dụng</p>
                    <p>Chính sách biên tập</p>
                    <p>Chính Sách Bảo Mật</p>
                    <p>Chính sách giải quyết khiếu nại</p>
                    <p>Hỗ trợ khách hàng: info@365ejsc.com</p>
                </div>
            </Flex>
        </Footer>
    );
};

export default BeautyFooter;
