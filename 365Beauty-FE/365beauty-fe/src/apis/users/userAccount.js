import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const UserAccountEndPoint = {
    register: 'register',
    login: 'login',
    staffAccount: 'staffAccount'
}

export const registerUserAccount = (userAccount) => {
    return axios.post(END_POINT.commandUserAccount + UserAccountEndPoint.register, userAccount);
}
export const loginUserAccount = (userAccount) => {
    return axios.post(END_POINT.commandUserAccount + UserAccountEndPoint.login, userAccount);
}

export const createStaffAccount = (salonId) => {
    return axios.post(END_POINT.commandUserAccount + UserAccountEndPoint.staffAccount, salonId);
}

export const getAllUserAccount = () => {
    return axios.get(END_POINT.queryUserAccount);
}

export const getAllStaffAccount = () => {
    return axios.get(END_POINT.queryStaffAccount);
}