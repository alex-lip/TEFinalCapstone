<template>
  <div>
    <UnitCard v-bind:unit="unitDetails"> </UnitCard>

    <!-- TODO: Need to input some boolean check to verify the amount entered is 
    higher than the current high bid, and connect form to add bid to log and change 
    high bid value on the unit.
    -->
    <form id="frmAddNewBid">
      <div class="field">
        <label for="bidAmount">Please enter your bid: </label>
        <input
          type="number"
          name="bidAmount"
          v-model.trim.number="newBid.bidAmount"
        />

        <!-- TODO: LINK TO USER'S BID HISTORY!!!!!! -->
        <router-link :to="{ name: 'users-bids' }">
          <!-- params: { id: user.userId } -->
          <button
            type="submit"
            class="btnSubmit"
            v-on:click.prevent="addNewBid()"
          >
            Submit Bid
          </button>
        </router-link>
      <div v-if="bidError">Please Enter an amount greater than the current high bid!</div>
      </div>
    </form>
  </div>
</template>

<script>
import UnitCard from "../components/UnitCard";
import bidService from "../services/BidService.js";

export default {
  components: {
    UnitCard,
  },

  props: {
    unitId: Number,
  },

  data() {
    return {
      bidError: false,
      unitDetails: undefined,

      userRole: this.$store.state.user.role,

      user: this.$store.state.user,

      newBid: {
        unitId: 0,
        userId: 0,
        bidAmount: 0,
        bidPlaced: "",
      },
    };
  },

  created() {
    // Populate 'unitDetails' data
    this.unitDetails = this.$store.state.units.find(
      (u) => u.unitId == this.$route.params.id
    );

    // Populate our bids in $store.
    this.getBids();
  },

  computed: {},

  methods: {
    getBids() {
      bidService.getAllBids().then((response) => {
        this.$store.commit("SET_BIDS", response.data);
      });
    },

    addNewBid() {
      this.checkBidAmount(this.newBid.bidAmount);

      if (this.bidError === true) {
        console.log("Needs to be greater.")
      } else {
        this.newBid.unitId = this.unitDetails.unitId;
        this.newBid.userId = this.user.userId;
        this.newBid.bidPlaced = new Date();

        bidService.createNewBid(this.newBid);
      }
    },

    checkBidAmount(bidAmount) {
      if (bidAmount <= this.unitDetails.highBid) {
        this.bidError = true;
      } else {
        this.bidError = false;
      }
    },
  },
};
</script>

<style>
.btnPlaceBid {
  background-color: #3366ff;
  border: 3px solid white;
  border-radius: 12px;
  color: white;
  padding: 10px 25px;
  text-align: center;
  display: inline-block;
  font-size: 24px;
}
.btnNoBid {
  background-color: #3366ff;
  border: 3px solid white;
  border-radius: 12px;
  color: white;
  padding: 10px 25px;
  text-align: center;
  display: inline-block;
  font-size: 24px;
}
.btnSubmit {
  background-color: #3366ff;
  border: 3px solid white;
  border-radius: 12px;
  color: white;
  text-align: center;
  display: inline-block;
}
</style>
