<template>
  <div class="units">
    <h1 id="title">Storage Auctions</h1>
    <p></p>
    <table id="tblUnits" class="table table-striped table-hover">
      <thead>
        <tr>
          <th>Bid Id Number</th>
          <th>Location Name</th>
          <th>Facility Address</th>
          <th>Unit Number</th>
          <th>Bid Amount</th>
          <th>Bid Placed On</th>
          <th>Unit High Bid</th>
          <th>End Date for Auction</th>
          <th>Status</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td style="text-align: left;">Filter</td>
          <td>
            <input
              type="text"
              id="locationNameFilter"
              placeholder="Location Name"
              v-model="filter.locationName"
            />
          </td>
          <td>
            <input
              type="text"
              id="facilityAddressFilter"
              placeholder="Facility Address"
              v-model="filter.facilityAddress"
            />
          </td>
          <td>
            <input
              type="text"
              id="unitNumberFilter"
              placeholder="Unit Number"
              v-model="filter.unitNumber"
            />
          </td>
          <td>
            <input
              type="text"
              id="bidAmountFilter"
              placeholder="Bid Amount"
              v-model.number="filter.bidAmount"
            />
          </td>
          <td>
            <input
              class="form-control"
              id="bidPlacedFilter"
              type="datetime-local"
              v-model="filter.bidPlaced"
            />
          </td>
          <td>
            <input
              type="text"
              id="highBidFilter"
              placeholder="High Bid"
              v-model="filter.highBid"
            />
          </td>
          <td>
            <input
              class="form-control"
              id="auctionEndFilter"
              type="datetime-local"
              v-model="filter.auctionEnd"
            />
          </td>
          <!--TODO: add filter for status of unit <td>
            <select
          class="form-control"
          id="status"
          v-model.trim="filter.status"
          required
        >
          <option>Ongoing</option>
          <option>Ended</option>
        </select>
          </td>-->
        </tr>
        <tr v-for="bid in filteredList" v-bind:key="bid.id">
          <td>{{ bid.bidId }}</td>
          <td>{{ bid.locationName }}</td>
          <td>{{ bid.facilityAddress }}</td>
          <td>{{ bid.unitNumber }}</td>
          <td>{{ bid.bidAmount }}</td>
          <td>{{ formattedDate(bid.bidPlaced) }}</td>
          <td>{{ bid.highBid }}</td>
          <td>{{ formattedDate(bid.auctionEnd) }}</td>
          <td v-if="auctionEnded(bid.auctionEnd)">Ended</td>
          <td v-else>Ongoing</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import bidService from "../services/BidService";
import moment from "moment";

export default {
  name: "users-bids",

  props: {
    userId: Number,
  },

  data() {
    return {
      filter: {
        id: null,
        locationName: "",
        facilityAddress: "",
        unitNumber: 0,
        bidAmount: 0,
        bidPlaced: "",
        username: "",
        highBid: 0,
        auctionEnd: "",
      },

      userRole: this.$store.state.user.role,
    };
  },

  methods: {
    // Methods to create, read, update, and delete...
    getBids() {
      bidService.getAllBids().then((response) => {
        this.$store.commit("SET_BIDS", response.data);
      });
    },

    formattedDate(givenDate) {
      return moment(givenDate).format("MMMM Do YYYY, h:mm A");
    },

    auctionEnded(givenDate) {
      let currentDateTime = new Date(Date.now());
      let convertedGivenDate = new Date(givenDate);
      if (convertedGivenDate < currentDateTime) {
        return true;
      } else {
        return false;
      }
    },
  },

  created() {
    this.getBids();
  },

  computed: {
    filteredList() {
      let filteredBids = this.$store.state.bids.filter(
        (b) => b.userId == this.$route.params.userId
      );

      if (this.filter.unitNumber != "") {
        filteredBids = filteredBids.filter(
          (bid) => bid.unitNumber === this.filter.unitNumber
        );
      }
      if (this.filter.bidAmount != "") {
        filteredBids = filteredBids.filter(
          (bid) => bid.bidAmount >= this.filter.bidAmount
        );
      }
      if (this.filter.bidPlaced != "") {
        filteredBids = filteredBids.filter((bid) =>
          moment(bid.bidPlaced).isSameOrAfter(this.filter.bidPlaced)
        );
      }
      if (this.filter.highBid != "") {
        filteredBids = filteredBids.filter(
          (bid) => bid.highBid >= this.filter.highBid
        );
      }
      if (this.filter.auctionEnd != "") {
        filteredBids = filteredBids.filter((bid) =>
          moment(bid.auctionEnd).isSameOrAfter(this.filter.auctionEnd)
        );
      }
      //if (this.filter.status != "") {
      //filteredBids = filteredBids.filter(
      //(bid) => bid.status == this.filter.status
      //);
      //}
      return filteredBids;
    },
  },
};
</script>

<style scoped>
#tblUnits {
  margin-left: auto;
  margin-right: auto;
}

body {
  font-family: system-ui;
  background: white;
  color: black;
  text-align: left;
}

table {
  width: 80%;
  background-color: white;
  color: black;
}

.unit-id {
  border-bottom: 1px solid black;
  text-align: center;
  padding-left: 75px;
  padding-right: 75px;
  padding-bottom: 4px;
}

#title {
  display: block;
  width: 50%;
  margin: auto;
  text-align: center;
  background-color: white;
}
</style>
