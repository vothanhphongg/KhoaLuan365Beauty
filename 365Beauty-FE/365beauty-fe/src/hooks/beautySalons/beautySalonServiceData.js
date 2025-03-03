import { useState, useEffect } from 'react';
import { getAllBeautySalonServiceBySalonId, getAllBeautySalonServiceByServiceId, getAllBeautySalonServiceWithPrice } from '../../apis/beautySalons/beautySalonService';

export const useBeautySalonServiceWithPriceData = () => {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const response = await getAllBeautySalonServiceWithPrice();
            setData(response.data);

        };
        fetchData();
    }, []);

    return data;
};

export const useBeautySalonServiceBySalonIdData = ({ salonId: id, isActived: isActived }) => {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const response = await getAllBeautySalonServiceBySalonId(({ salonId: id, isActived: isActived }));
            setData(response.data);

        };
        fetchData();
    }, []);

    return data;
};

export const useBeautySalonServiceByServiceIdData = (serviceId) => {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const response = await getAllBeautySalonServiceByServiceId(serviceId);
            setData(response.data);
        };
        fetchData();
    }, []);

    return data;
};
