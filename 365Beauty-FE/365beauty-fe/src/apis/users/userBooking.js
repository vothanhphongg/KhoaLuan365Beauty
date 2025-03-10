import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const UserBookingEndPoint = {
    salon: '/salon'
}

export const createUserBooking = (userBooking) => {
    return axios.post(END_POINT.commandUserBooking, userBooking);
}

export const getDetailUserBooking = (id) => {
    return axios.get(`${END_POINT.queryUserBooking}/${id}`);
}

export const getAllUserBookingActivedByUserId = ({ userId, isActived }) => {
    return axios.get(END_POINT.queryUserBooking, {
        params: { userId, isActived }
    });
};
