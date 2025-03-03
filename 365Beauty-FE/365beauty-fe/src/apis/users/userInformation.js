import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const GetDetailUserInformation = (userId) => {
    return axios.get(`${END_POINT.queryUserInformation}/${userId}`);
}