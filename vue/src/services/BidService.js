import axios from "axios";

export default {
  getAllBids() {
    return axios.get("/bids");
  },
  createNewBid(newBid) {
    return axios.post("/bids", newBid);
  },
}
