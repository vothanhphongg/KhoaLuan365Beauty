import { useState, useEffect } from 'react';
import { getAllServiceCatalogs } from '../../apis/services/serviceCatalog';
import { getCountUserBooking } from '../../apis/users/userBooking';

export const useServiceCatalogData = () => {
    const [data, setData] = useState([]);
    const [isActived, setIsActived] = useState(1);
    const [loading, setLoading] = useState(false);

    const fetchData = async (isActived) => {
        setLoading(true);
        try {
            const response = await getAllServiceCatalogs(isActived);
            setData(response.data);
        } catch (error) {
            console.error('Error fetching data:', error);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchData(isActived);
    }, [isActived]);

    const toggleIsActived = () => {
        setIsActived((prev) => (prev === 1 ? 0 : 1));
    };

    return { data, isActived, loading, toggleIsActived, fetchData };
};

export const useServiceCatalogWithCountData = () => {
    const [data, setData] = useState([]);

    const fetchData = async () => {
        const response = await getCountUserBooking();
        setData(response.data);
    };

    useEffect(() => {
        fetchData();
    }, []);


    return data;
};
