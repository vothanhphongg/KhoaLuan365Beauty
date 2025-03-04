import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const createBookingType = (BookingType) => {
    return axios.post(END_POINT.commandBookingType, BookingType);
}

export const updateBookingType = (BookingType) => {
    return axios.put(END_POINT.commandBookingType, BookingType);
}

export const deleteBookingType = (id) => {
    return axios.delete(`${END_POINT.commandBookingType}/${id}`);
}

export const getAllBookingTypes = () => {
    return axios.get(END_POINT.queryBookingType);
}

export const getDetailBookingType = (id) => {
    return axios.get(`${END_POINT.queryBookingType}/${id}`);
}