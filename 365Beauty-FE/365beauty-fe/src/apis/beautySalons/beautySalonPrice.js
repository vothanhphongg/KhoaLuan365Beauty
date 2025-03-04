import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const createPrice = (salonService) => {
    return axios.post(END_POINT.commandPrice, salonService);
}

export const updatePrice = (salonService) => {
    return axios.put(END_POINT.commandPrice, salonService);
}