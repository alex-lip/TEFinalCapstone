import axios from "axios";

export default {
  login(user) {
    return axios.post("/login", user);
  },

  register(user) {
    return axios.post("/login/register", user);
  },

  verification(userId, verificationCode) {
    const payload = { userId: userId, verificationCode: verificationCode}
    return axios.post('login/verification', payload)
  }
}
