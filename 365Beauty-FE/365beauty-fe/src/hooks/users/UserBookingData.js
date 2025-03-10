import { useState, useEffect } from 'react';
import { getAllUserBookingActivedByUserId } from '../../apis/users/userBooking';

export const useUserBookingActivedData = (userId, isActived) => {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await getAllUserBookingActivedByUserId({ userId, isActived });
                setData(response.data);
            } catch (error) {
                console.error("Lỗi khi lấy dữ liệu:", error);
            }
        };

        if (userId) {
            fetchData();
        }
    }, [userId, isActived]);

    return data;
};
