import axios from "axios";

export default {
  getAllUnits() {
    return axios.get('/units');
  },
  //  EXAMPLE TO USE
  //   login(user) {
  //     return axios.post('{PATH}', {OBJECT_TO_POST})
  //   },

  //   register(user) {
  //     return axios.post('{PATH}', {OBJECT_TO_POST})
  //   }
};
