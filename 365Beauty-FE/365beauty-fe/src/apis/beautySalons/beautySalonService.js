import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const BeautySalonServiceEndPoint = {
    bySalonId: '/bySalonId',
    byServiceId: '/byServiceId',
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

export const getAllBeautySalonServices = () => {
    return axios.get(END_POINT.queryBeautySalonService);
}

export const getDetailBeautySalonService = (id) => {
    return axios.get(`${END_POINT.queryBeautySalonService}/${id}`);

}

export const getAllBeautySalonServiceBySalonId = (salonService) => {
    return axios.get(END_POINT.queryBeautySalonService + BeautySalonServiceEndPoint.bySalonId, {
        params:
        {
            salonId: salonService.salonId,
            isActived: salonService.isActived
        }
    });
}

export const getAllBeautySalonServiceFullBySalonId = (salonId) => {
    return axios.get(`${END_POINT.queryBeautySalonService + BeautySalonServiceEndPoint.bySalonId}/${salonId}`);
}

export const getAllBeautySalonServiceByServiceId = (serviceId) => {
    return axios.get(`${END_POINT.queryBeautySalonService + BeautySalonServiceEndPoint.byServiceId}/${serviceId}`);
}