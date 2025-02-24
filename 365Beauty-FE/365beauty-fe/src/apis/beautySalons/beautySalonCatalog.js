import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const BeautySalonCatalogEndPoint = {
    actived: '/activedBeautySalons'
}

export const createBeautySalonCatalog = (salon) => {
    return axios.post(END_POINT.commandBeautySalonCatalog, salon);
}

export const updateBeautySalonCatalog = (salon) => {
    return axios.put(END_POINT.commandBeautySalonCatalog, salon);
}

export const lockOrUnLockBeautySalonCatalog = (id) => {
    return axios.delete(`${END_POINT.commandBeautySalonCatalog}/${id}`);
}

export const getAllBeautySalonCatalogs = (IsActived) => {
    return axios.get(END_POINT.queryBeautySalonCatalog, {
        params: { isActived: IsActived }
    });
}