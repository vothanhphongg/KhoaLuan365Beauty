import { useState, useEffect } from 'react';
import { getAllStaffCatalogBySalonServiceId } from '../../apis/staffs/staffCatalog';

const useBookingStaffData = (salonServiceId, bookingDate, timeId) => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);

    const fetchData = async () => {
        setLoading(true);
        try {
            const response = await getAllStaffCatalogBySalonServiceId({
                salonServiceId,
                bookingDate,
                timeId
            });
            setData(response.data);
        } catch (error) {
            console.error('Error fetching data:', error);
        } finally {
            setLoading(false);
        }
    };

    useEffect(() => {
        fetchData();
    }, [bookingDate, timeId]);

    return { data, loading, fetchData };
};

export default useBookingStaffData;