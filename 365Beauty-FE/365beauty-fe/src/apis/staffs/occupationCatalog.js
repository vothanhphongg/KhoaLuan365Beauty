import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const createOccupationCatalog = (occupationCatalog) => {
    return axios.post(END_POINT.commandOccupationCatalog, occupationCatalog);
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

export const getDetailOccupationCatalog = (id) => {
    return axios.get(`${END_POINT.queryOccupationCatalog}/${id}`);
}