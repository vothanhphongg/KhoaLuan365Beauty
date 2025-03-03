import { useState, useEffect } from 'react';
import { getAllUserAccount } from '../../apis/users/userAccount';

export const useUserAccountData = () => {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            const response = await getAllUserAccount();
            setData(response.data);
        };
        fetchData();
    }, []);

    return data;
};