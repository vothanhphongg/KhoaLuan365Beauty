import { useState, useEffect } from 'react';
import { getAllBeautySalonServiceWithPrice } from '../../apis/beautySalons/beautySalonService';

const useBeautySalonServiceData = () => {
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

export default useBeautySalonServiceData;
