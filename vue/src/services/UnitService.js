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
    return axios.delete(`/units/${unitId}`, unitId);
  },

  sendWinnerEmail(id, message) {
    const payload = { id: id, message: message}
    return axios.post("/units/contactWinner/", payload)
  }
  
};
