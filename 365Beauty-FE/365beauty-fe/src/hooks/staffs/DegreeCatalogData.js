import { useState, useEffect } from 'react';
import { getAllDegreeCatalogs } from '../../apis/staffs/degreeCatalog';

const DegreeCatalogData = () => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);

    const fetchData = async () => {
        setLoading(true);
        try {
            const response = await getAllDegreeCatalogs();
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

export default DegreeCatalogData;