import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

export const createTime = (Time) => {
    return axios.post(END_POINT.commandTime, Time);
}

export const updateTime = (Time) => {
    return axios.put(END_POINT.commandTime, Time);
}

export const deleteTime = (id) => {
    return axios.delete(`${END_POINT.commandTime}/${id}`);
}

export const getAllTimes = () => {
    return axios.get(END_POINT.queryTime);
}

export const getDetailTime = (id) => {
    return axios.get(`${END_POINT.queryTime}/${id}`);
}