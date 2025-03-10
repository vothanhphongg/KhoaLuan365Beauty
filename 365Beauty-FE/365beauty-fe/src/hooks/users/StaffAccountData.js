import { useState, useEffect } from 'react';
import { getAllStaffAccount } from '../../apis/users/userAccount';

export const useStaffAccountData = (reload) => {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const response = await getAllStaffAccount();
            setData(response.data);
        };
        fetchData();
    }, [reload]);

    return data;
};