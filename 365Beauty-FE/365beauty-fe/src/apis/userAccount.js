import axios from "./axios_customize";
import { END_POINT } from "./endpoint";

export const createUserAccountAPI = (userAccount) => {
    return axios.post(END_POINT.userAccount, userAccount);
}