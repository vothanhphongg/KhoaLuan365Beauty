import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const createStaffCatalog = (staffCatalog) => {
    return axios.post(END_POINT.commandStaffCatalog, staffCatalog);
}

export const updateOccupationCatalog = (occupationCatalog) => {
    return axios.put(END_POINT.commandOccupationCatalog, occupationCatalog);
}

export const deleteOccupationCatalog = (id) => {
    return axios.delete(`${END_POINT.commandOccupationCatalog}/${id}`);
}

export const getAllOccupationCatalogs = () => {
    return axios.get(END_POINT.queryOccupationCatalog);
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