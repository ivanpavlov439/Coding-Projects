import axios from "axios";

// Creating an instance of axios pointing to DB
const instance = axios.create({
  baseURL: "https://burger-builder-67e04.firebaseio.com/",
});

export default instance;
