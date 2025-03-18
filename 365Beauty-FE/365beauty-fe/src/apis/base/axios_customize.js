import axios from "axios";

const instance = axios.create({
    baseURL: "http://localhost:4000/api/",
});

// Thêm interceptor để tự động gắn token vào tất cả request
instance.interceptors.request.use(
    (config) => {
        const token = sessionStorage.getItem("userToken");
        if (token) {
            config.headers["Authorization"] = `Bearer ${token}`;
        }
        return config;
    },
    (error) => {
        return Promise.reject(error);
    }
);

// Xử lý response để chỉ lấy `response.data`
instance.interceptors.response.use(
    (response) => response.data,
    (error) => Promise.reject(error)
);

export default instance;
