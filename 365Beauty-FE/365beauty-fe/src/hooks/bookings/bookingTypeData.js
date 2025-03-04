import { useState, useEffect } from 'react';
import { getAllBookingTypes } from '../../apis/bookings/bookingType';

const useBookingTypeData = () => {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(false);

    const fetchData = async () => {
        setLoading(true);
        try {
            const response = await getAllBookingTypes();
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

export default useBookingTypeData;