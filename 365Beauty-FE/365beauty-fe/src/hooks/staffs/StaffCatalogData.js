import { useState, useEffect } from 'react';
import { getAllStaffCatalogBySalonIds } from '../../apis/staffs/staffCatalog';

export const useStaffCatalogBySalonIdData = ({ salonId: id, isActived: isActived }) => {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await getAllStaffCatalogBySalonIds(({ salonId: id, isActived: isActived }));
                setData(response.data);
            } catch (error) {
                console.error('Error fetching data:', error);
            } finally {
                setLoading(false);
            }
        };
        fetchData();
    }, []);

    return data;
};
