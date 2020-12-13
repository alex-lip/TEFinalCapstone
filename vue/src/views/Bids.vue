<template>
  <div class="units">
    <h1 id="title">Storage Auctions</h1>
    <p></p>
    <h3 id="title">Full listing of all bids, filter down by unit and user as needed</h3>
    <p></p>
    <table id="tblUnits">
      <thead>
        <tr>
          <th>Bid Id Number</th>
          <th>Location Name</th>
          <th>Facility Address</th>
          <th>Unit Number</th>
          <th>Bid Amount</th>
          <th>Bid Placed On</th>
          <th>User Email</th>
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
            <input type="text" id="bidPlacedFilter" placeholder="Date of Bid" v-model="filter.bidPlaced" />
          </td>
          <td>
            <input type="text" id="usernameFilter" placeholder="User Email" v-model.number="filter.username" />
          </td>
        </tr>
        <tr v-for="bid in filteredList" v-bind:key="bid.id">
          <td>{{ bid.bidId }}</td>
          <td>{{ bid.locationName }}</td>
          <td>{{ bid.facilityAddress }}</td>
          <td>{{ bid.unitNumber }}</td>
          <td>{{ bid.bidAmount }}</td>
          <td>{{ bid.bidPlaced }}</td>
          <td>{{ bid.username }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import bidService from "../services/BidService";

export default {
  name: "Bids",

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
  },

  created() {
    this.getBids();
  },

  computed: {
    filteredList() {
      let filteredBids = this.$store.state.bids;
      if (this.filter.unitNumber != "") {
        filteredBids = filteredBids.filter((bid) =>
          bid.unitNumber === this.filter.unitNumber
        );
      }
      if (this.filter.bidAmount != "") {
        filteredBids = filteredBids.filter((bid) =>
          bid.bidAmount >= this.filter.bidAmount
        );
      }
      if (this.filter.bidPlaced != "") {
        filteredBids = filteredBids.filter((bid) =>
          bid.bidPlaced <= this.filter.bidPlaced //TODO: Not sure how to code a filter to take a datetime, or how to code for filters out date before the entered value
        );
      }
      if (this.filter.username != "") {
        filteredBids = filteredBids.filter((bid) =>
          bid.username.startsWith(this.filter.username)
        );
      }
      return filteredBids;
    },
  },
};
</script>

<style>
#tblUnits {
  margin-left: auto;
  margin-right: auto;
  border: 1px solid black;
}

table,
th,
td {
  border: 1px solid black;
}
/* body {
  font-family: system-ui;
  background: #ff944d;
  color: black;
  text-align: left;
}

table {
  width: 80%;
  background-color: white;
  color: black;
}



.unit-id{
  border-bottom: 1px solid black;
  text-align: center;
  padding-left: 75px;
  padding-right: 75px;
  padding-bottom: 4px;
}

#title{
  display: block;
  width: 50%;
  margin: auto;
  text-align: center;
  background-color: white;
} */
</style>
