import axios from "axios";

const _axios = axios.create({
  baseURL: 'http://localhost:5131/',
  timeout: 1000,
  headers: { 'Content-Type': 'application/json' },
})

export default _axios