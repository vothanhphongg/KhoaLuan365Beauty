import { useState, useEffect } from 'react';
import { getAllOccupationCatalogs } from '../../apis/staffs/occupationCatalog';

const useOccupationCatalogData = () => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);

    const fetchData = async () => {
        setLoading(true);
        try {
            const response = await getAllOccupationCatalogs();
            setData(response.data);
        } catch (error) {
            console.error('Error fetching data:', error);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    return { data, loading, fetchData };
};

export default useOccupationCatalogData;