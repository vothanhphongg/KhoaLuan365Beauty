import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const createUserRating = (userRating) => {
    return axios.post(END_POINT.commandUserRating, userRating);
}

export const getAllUserRating = (salonServiceId) => {
    return axios.get(`${END_POINT.queryUserRating}/${salonServiceId}`);
};