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
          <!-- <th>User Email</th> -->
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
              type="text"
              id="bidPlacedFilter"
              placeholder="Date of Bid"
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
              type="text"
              id="auctionEndFilter"
              placeholder="Auction End"
              v-model="filter.auctionEnd"
            />
          </td>
          <td>
            <!-- Dropdown to check if the auction is ongoing or has ended -->
          </td>
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
      let currentDateTime = Date.now();
      if (givenDate < currentDateTime) {
        return true;
      } else {
        return false;
      }
    }
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
        filteredBids = filteredBids.filter(
          (bid) => bid.bidPlaced <= this.filter.bidPlaced //TODO: Not sure how to code a filter to take a datetime, or how to code for filters out date before the entered value
        );
      }
      if (this.filter.highBid != "") {
        filteredBids = filteredBids.filter(
          (bid) => bid.highBid >= this.filter.highBid //TODO: Not sure which direction to set up the filter here, all amounts higher or lower than the input value?
        );
      }
      if (this.filter.auctionEnd != "") {
        filteredBids = filteredBids.filter(
          (bid) => bid.auctionEnd <= this.filter.auctionEnd //TODO: Not sure how to code a filter to take a datetime, or how to code for filters out date before the entered value
        );
      }
      //TODO:Will need to add filters for unit high bids and auction end dates once data is added to table
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
