import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const StaffCatalogEndPoint = {
    bySalonId: '/bySalonId',
    bySalonServiceId: '/bySalonServiceId'
}

export const createStaffCatalog = (staffCatalog) => {
    return axios.post(END_POINT.commandStaffCatalog, staffCatalog);
}
export const upateStaffCatalog = (staffCatalog) => {
    return axios.put(END_POINT.commandStaffCatalog, staffCatalog);
}

export const lockOrUnLockStaffCatalog = (id) => {
    return axios.delete(`${END_POINT.commandStaffCatalog}/${id}`);
}

export const getDetailStaffCatalog = (id) => {
    return axios.get(`${END_POINT.queryStaffCatalog}/${id}`);
}

export const getAllStaffCatalogBySalonId = (salonId) => {
    return axios.get(`${END_POINT.queryStaffCatalog + StaffCatalogEndPoint.bySalonId}/${salonId}`);
}

export const getAllStaffCatalogBySalonServiceId = (staff) => {
    console.log(staff)
    return axios.get(END_POINT.queryStaffCatalog + StaffCatalogEndPoint.bySalonServiceId, {
        params:
        {
            beautySalonServiceId: staff.salonServiceId,
            bookingDate: staff.bookingDate,
            timeId: staff.timeId
        }
    });
}
