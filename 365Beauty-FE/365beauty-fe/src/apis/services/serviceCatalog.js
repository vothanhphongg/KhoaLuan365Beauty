import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const createServiceCatalog = (serviceCatalog) => {
    console.log(serviceCatalog);
    return axios.post(END_POINT.commandServiceCatalog, serviceCatalog);
}

export const updateServiceCatalog = (serviceCatalog) => {
    return axios.put(END_POINT.commandServiceCatalog, serviceCatalog);
}

export const lockOrUnLockServiceCatalog = (id) => {
    return axios.delete(`${END_POINT.commandServiceCatalog}/${id}`);
}

export const getAllServiceCatalogs = (IsActived) => {
    return axios.get(END_POINT.queryServiceCatalog, {
        params: { isActived: IsActived }
    });
}
export const getDetailServiceCatalogs = (id) => {
    return axios.get(`${END_POINT.queryServiceCatalog}/${id}`);
}

export const getAllServiceCatalogWithCounts = () => {
    return axios.get(END_POINT.queryServiceCatalog + '/count');
}