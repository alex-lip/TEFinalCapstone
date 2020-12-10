import axios from "axios";

export default {
  getAllUnits() {
    return axios.get("/units");
  },
  createNewUnit(newUnit) {
    return axios.post("/units", newUnit);
  },
  editUnit(unitId, updatedUnit) {
    return axios.put("/units/" + unitId, updatedUnit);
  },
  deleteUnit(unitId) {
    console.log("deleting/" + unitId);
    return axios.delete(`/units/${unitId}`);
  },
  //  EXAMPLE TO USE
  //   login(user) {
  //     return axios.post('{PATH}', {OBJECT_TO_POST})
  //   },

  //   register(user) {
  //     return axios.post('{PATH}', {OBJECT_TO_POST})
  //   }
};
