import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const UserAccountEndPoint = {
    register: 'register',
    login: 'login'
}

export const registerUserAccountAPI = (userAccount) => {
    return axios.post(END_POINT.commandUserAccount + UserAccountEndPoint.register, userAccount);
}
export const loginUserAccountAPI = (userAccount) => {
    return axios.post(END_POINT.commandUserAccount + UserAccountEndPoint.login, userAccount);
}