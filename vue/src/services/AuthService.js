import axios from "axios";

export default {
  login(user) {
    return axios.post("/login", user);
  },

  register(user) {
    return axios.post("/login/register", user);
  },

  verification(username, verificationCode) {
    const payload = { username: username, verificationCode: verificationCode}
    return axios.post('login/verification', payload)
  }
}
