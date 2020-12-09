import axios from "axios";

const http = axios.create({
  baseURL: "http://localhost:8081"
});

export default {
  getAllUnits() {
    return axios.get('/units');
  },
  createNewUnit(newUnit){
    return http.post('/units', newUnit);
},
editTopic(unitId, updatedUnit){
  return http.put('/units/' + unitId, updatedUnit);
},
deleteTopic(unitId){
  console.log('deleting/' + unitId);
  return http.delete(`/units/${unitId}`);
}
  //  EXAMPLE TO USE
  //   login(user) {
  //     return axios.post('{PATH}', {OBJECT_TO_POST})
  //   },

  //   register(user) {
  //     return axios.post('{PATH}', {OBJECT_TO_POST})
  //   }
};
