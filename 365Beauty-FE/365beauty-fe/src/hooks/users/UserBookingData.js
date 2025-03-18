import { useState, useEffect } from 'react';
import { getAllUserBookingBySalonId, getAllUserBookingByUserId, getCountUserBooking, getCountUserBookingBySalonId, getCountUserBookingBySalonServiceId } from '../../apis/users/userBooking';

export const useUserBookingActivedData = (userId, isActived) => {
    const [data, setData] = useState([]);

    const fetchData = async () => {
        try {
            const response = await getAllUserBookingByUserId({ userId, isActived });
            setData(response.data);
        } catch (error) {
            console.error("Lỗi khi lấy dữ liệu:", error);
        }
    };

    useEffect(() => {
        if (userId) {
            fetchData();
        }
    }, [userId, isActived]);

    return { data, reload: fetchData }; // Trả về data + hàm reload
};

export const useUserBookingBySalonIdData = (salonId, isActived) => {
    const [data, setData] = useState([]);

    const fetchData = async () => {
        try {
            const response = await getAllUserBookingBySalonId({ salonId, isActived });
            setData(response.data);
        } catch (error) {
            console.error("Lỗi khi lấy dữ liệu:", error);
        }
    };

    useEffect(() => {
        if (salonId) {
            fetchData();
        }
    }, [salonId, isActived]);

    return { data, reload: fetchData }; // Trả về data + hàm reload
};


export const useBountUserBookingData = () => {
    const [data, setData] = useState([]);
    const fetchData = async () => {
        try {
            const response = await getCountUserBooking();
            setData(response.data);
        } catch (error) {
            console.error("Lỗi khi lấy dữ liệu:", error);
        }
    };
    useEffect(() => {
        fetchData();
    }, []);

    return data; // Trả về data + hàm reload
};


export const useBountUserBookingBySalonIdData = (salonId) => {
    const [data, setData] = useState([]);
    const fetchData = async () => {
        try {
            const response = await getCountUserBookingBySalonId(salonId);
            setData(response.data);
        } catch (error) {
            console.error("Lỗi khi lấy dữ liệu:", error);
        }
    };
    useEffect(() => {
        fetchData();
    }, [salonId]);

    return data; // Trả về data + hàm reload
};

export const useBountUserBookingBySalonServiceIdData = (salonId) => {
    const [data, setData] = useState([]);
    const fetchData = async () => {
        try {
            const response = await getCountUserBookingBySalonServiceId(salonId);
            setData(response.data);
        } catch (error) {
            console.error("Lỗi khi lấy dữ liệu:", error);
        }
    };
    useEffect(() => {
        fetchData();
    }, [salonId]);

    return data; // Trả về data + hàm reload
};