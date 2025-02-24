import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const createTitleCatalog = (titleCatalog) => {
    return axios.post(END_POINT.commandTitleCatalog, titleCatalog);
}

export const updateTitleCatalog = (titleCatalog) => {
    return axios.put(END_POINT.commandTitleCatalog, titleCatalog);
}

export const deleteTitleCatalog = (id) => {
    return axios.delete(`${END_POINT.commandTitleCatalog}/${id}`);
}

export const getAllTitleCatalogs = () => {
    return axios.get(END_POINT.queryTitleCatalog);
}