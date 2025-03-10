import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const StaffCatalogEndPoint = {
    actived: '/actived',
    all: '/all'
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

export const getAllStaffCatalogBySalonIds = (salonId) => {
    return axios.get(`${END_POINT.queryStaffCatalog + StaffCatalogEndPoint.all}/${salonId}`);
}

export const getAllStaffCatalogByBeautySalonServiceId = (staff) => {
    console.log(staff)
    return axios.get(END_POINT.queryStaffCatalog + StaffCatalogEndPoint.actived, {
        params:
        {
            beautySalonServiceId: staff.salonServiceId,
            bookingDate: staff.bookingDate,
            timeId: staff.timeId
        }
    });
}

export const getDetailStaffCatalog = (id) => {
    return axios.get(`${END_POINT.queryStaffCatalog}/${id}`);
}