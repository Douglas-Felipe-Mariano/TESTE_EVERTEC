import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:5287/api"
});

export default api;