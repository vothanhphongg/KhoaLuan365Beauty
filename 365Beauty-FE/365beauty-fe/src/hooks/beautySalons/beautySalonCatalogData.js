import { useState, useEffect, useCallback } from 'react';
import { getAllBeautySalonCatalogs } from '../../apis/beautySalons/beautySalonCatalog';

const useBeautySalonCatalogData = () => {
    const [data, setData] = useState([]);
    const [isActived, setIsActived] = useState(1);
    const [loading, setLoading] = useState(false);

    const fetchData = useCallback(async (isActived) => {
        setLoading(true);
        try {
            const response = await getAllBeautySalonCatalogs(isActived);
            setData(response.data);
        } catch (error) {
            console.error('Error fetching data:', error);
        } finally {
            setLoading(false);
        }
    }, []);

    useEffect(() => {
        fetchData(isActived);
    }, [fetchData, isActived]);

    const toggleIsActived = () => {
        setIsActived((prev) => (prev === 1 ? 0 : 1));
    };

    return { data, isActived, loading, toggleIsActived, fetchData };
};

export default useBeautySalonCatalogData;
