import { useState, useEffect } from 'react';
import { getAllStaffCatalogBySalonIds } from '../../apis/staffs/staffCatalog';
import { getAllBeautySalonServiceByServiceId } from '../../apis/beautySalons/beautySalonService';

export const useStaffCatalogBySalonIdData = (salonId) => {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await getAllStaffCatalogBySalonIds(salonId);
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

export const useStaffCatalogByBeautySalonServiceIdData = ({ beautySalonServiceId: beautySalonServiceId, bookingDate: bookingDate, timeId: timeId }) => {
    const [data, setData] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await getAllBeautySalonServiceByServiceId(({ beautySalonServiceId: beautySalonServiceId, bookingDate: bookingDate, timeId: timeId }));
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