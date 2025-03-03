import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const BeautySalonServiceEndPoint = {
    withPrice: '/withPrice',
    getAll: '/getAll',
}

export const getAllBeautySalonServiceBySalonId = (salonService) => {
    return axios.get(END_POINT.queryBeautySalonService, {
        params:
        {
            salonId: salonService.salonId,
            isActived: salonService.isActived
        }
    });
}

export const createBeautySalonService = (salonService) => {
    return axios.post(END_POINT.commandBeautySalonService, salonService);
}

export const updateBeautySalonService = (salonService) => {
    return axios.put(END_POINT.commandBeautySalonService, salonService);
}

export const lockOrUnLockBeautySalonService = (id) => {
    return axios.delete(`${END_POINT.commandBeautySalonService}/${id}`);
}

export const getAllBeautySalonServiceWithPrice = () => {
    return axios.get(END_POINT.queryBeautySalonService + BeautySalonServiceEndPoint.withPrice);

}

export const getDetailBeautySalonService = (id) => {
    return axios.get(`${END_POINT.queryBeautySalonService}/${id}`);

}

export const getAllBeautySalonServiceByServiceId = (serviceId) => {
    return axios.get(`${END_POINT.queryBeautySalonService + BeautySalonServiceEndPoint.getAll}/${serviceId}`);

}