import axios from "axios";

const commonInstance = axios.create({
    timeout: 10000,
});

export default commonInstance;