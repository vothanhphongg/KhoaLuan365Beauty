import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const UserBookingEndPoint = {
    user: '/user',
    admin: '/admin',
    count: '/count',
    byUserId: '/byUserId',
    bySalonId: '/bySalonId',
    bySalonServiceId: '/bySalonServiceId'
}

export const createUserBooking = (userBooking) => {
    return axios.post(END_POINT.commandUserBooking, userBooking);
}

export const updateUserBookingByUser = (userBooking) => {
    console.log(userBooking)
    return axios.put(END_POINT.commandUserBooking + UserBookingEndPoint.user, userBooking);
}

export const updateUserBookingByAdmin = (userBooking) => {
    return axios.put(END_POINT.commandUserBooking + UserBookingEndPoint.admin, userBooking);
}

export const getDetailUserBooking = (id) => {
    return axios.get(`${END_POINT.queryUserBooking}/${id}`);
}

export const getAllUserBookingByUserId = ({ userId, isActived }) => {
    return axios.get(END_POINT.queryUserBooking + UserBookingEndPoint.byUserId, {
        params: { userId, isActived }
    });
};

export const getAllUserBookingBySalonId = ({ salonId, isActived }) => {
    return axios.get(END_POINT.queryUserBooking + UserBookingEndPoint.bySalonId, {
        params: { salonId, isActived }
    });
};

export const getCountUserBooking = () => {
    return axios.get(END_POINT.queryUserBooking + UserBookingEndPoint.count);
};

export const getCountUserBookingBySalonId = (salonId) => {
    return axios.get(`${END_POINT.queryUserBooking + UserBookingEndPoint.count + UserBookingEndPoint.bySalonId}/${salonId}`);
};

export const getCountUserBookingBySalonServiceId = (salonServiceId) => {
    return axios.get(`${END_POINT.queryUserBooking + UserBookingEndPoint.count + UserBookingEndPoint.bySalonServiceId}/${salonServiceId}`);
};
