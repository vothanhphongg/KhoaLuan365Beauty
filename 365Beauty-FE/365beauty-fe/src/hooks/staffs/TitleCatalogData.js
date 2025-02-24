import { useState, useEffect } from 'react';
import { getAllTitleCatalogs } from '../../apis/staffs/titleCatalog';

const TitleCatalogData = () => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);

    const fetchData = async () => {
        setLoading(true);
        try {
            const response = await getAllTitleCatalogs();
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

export default TitleCatalogData;