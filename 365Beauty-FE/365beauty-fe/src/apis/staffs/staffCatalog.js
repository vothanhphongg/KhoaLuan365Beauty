import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const createStaffCatalog = (staffCatalog) => {
    return axios.post(END_POINT.commandStaffCatalog, staffCatalog);
}

export const getAllStaffCatalogBySalonIds = (staff) => {
    return axios.get(END_POINT.queryStaffCatalog, {
        params:
        {
            salonId: staff.salonId,
            isActived: staff.isActived
        }
    });
}

export const getDetailStaffCatalog = (id) => {
    return axios.get(`${END_POINT.queryStaffCatalog}/${id}`);
}