import axios from "../base/axios_customize";
import { END_POINT } from "../base/endpoint";

const LocalizationEndpoint = {
    provinces: '/provinces',
    districts: '/districts',
    wards: '/wards',
}

export const getAllProvinces = () => {
    return axios.get(END_POINT.queryLocalization + LocalizationEndpoint.provinces);
}

export const getAllDistrictsByProvinceId = (provinceId) => {
    return axios.get(END_POINT.queryLocalization + LocalizationEndpoint.districts, {
        params: { provinceId: provinceId }
    });
}

export const getAllWardsByDistrictId = (districtId) => {
    return axios.get(END_POINT.queryLocalization + LocalizationEndpoint.wards, {
        params: { districtId: districtId }
    });
}
export const getDetailWards = (wardId) => {
    return axios.get(`${END_POINT.queryLocalization + LocalizationEndpoint.wards}/${wardId}`);
}