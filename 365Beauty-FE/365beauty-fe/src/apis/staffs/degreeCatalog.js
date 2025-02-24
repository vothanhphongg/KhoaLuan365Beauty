import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const createDegreeCatalog = (degreeCatalog) => {
    return axios.post(END_POINT.commandDegreeCatalog, degreeCatalog);
}

export const updateDegreeCatalog = (degreeCatalog) => {
    return axios.put(END_POINT.commandDegreeCatalog, degreeCatalog);
}

export const deleteDegreeCatalog = (id) => {
    return axios.delete(`${END_POINT.commandDegreeCatalog}/${id}`);
}

export const getAllDegreeCatalogs = () => {
    return axios.get(END_POINT.queryDegreeCatalog);
}