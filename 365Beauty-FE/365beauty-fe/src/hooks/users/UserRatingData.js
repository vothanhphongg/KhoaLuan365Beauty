import { useState, useEffect } from 'react';
import { getAllUserRating } from '../../apis/users/userRating';

export const useUserRatingData = (salonServiceId) => {
    const [data, setData] = useState([]);
    const fetchData = async () => {
        const response = await getAllUserRating(salonServiceId);
        setData(response.data);
    };
    useEffect(() => {
        fetchData();
    }, [salonServiceId]);

    return data;
};