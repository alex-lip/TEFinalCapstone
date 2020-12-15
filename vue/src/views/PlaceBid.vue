<template>
  <div class="container-sm">
    <UnitCard v-bind:unit="unitDetails"> </UnitCard>

    <!-- TODO: Need to input some boolean check to verify the amount entered is 
    higher than the current high bid, and connect form to add bid to log and change 
    high bid value on the unit.
    -->
    <form id="frmAddNewBid">
      <div class="cta">
        <label for="bidAmount"><p class="ctaText">Place your bid: </p></label>
        <input
          type="number"
          name="bidAmount"
          v-model.trim.number="newBid.bidAmount"
          min="unitDetails.highBid + 1"
        />
        <br>
        <!-- TODO: LINK TO USER'S BID HISTORY!!!!!! -->
        <router-link :to="{ name: 'users-bids' }">
          <!-- params: { id: user.userId } -->
          <button
            form="frmAddNewBid"
            type="submit"
            class="btn btn-custom-submit-bid"
            v-on:click.prevent="addNewBid()"
          >
            Submit Bid
          </button>
        </router-link>
        <div v-if="bidError">
          Please Enter an amount greater than the current high bid!
        </div><br>

        <router-link v-bind:to="{ name: 'units' }">
          <button class="btn btn-light">
            Return to List of Units
          </button>
        </router-link>
      </div>
    </form>
  </div>
</template>

<script>
import UnitCard from "../components/UnitCard";
import bidService from "../services/BidService.js";
import unitService from "../services/UnitService.js";

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

    // Set the bidAmount to be equal to the unitDetails's bid amount.
    this.newBid.bidAmount = this.unitDetails.highBid;
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
        console.log("Needs to be greater.");
      } else {
        this.newBid.unitId = this.unitDetails.unitId;
        this.newBid.userId = this.user.userId;
        this.newBid.bidPlaced = new Date();

        bidService.createNewBid(this.newBid);

        this.unitDetails.highBid = this.newBid.bidAmount;
        unitService.editUnit(this.unitDetails.unitId, this.unitDetails);

        this.getUnits();
      }
    },

    checkBidAmount(bidAmount) {
      if (bidAmount <= this.unitDetails.highBid) {
        this.bidError = true;
      } else {
        this.bidError = false;
      }
    },

    getUnits() {
      unitService.getAllUnits().then((response) => {
        this.$store.commit("SET_UNITS", response.data);
      });
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

#frmAddNewBid {
  padding: 25px;
  margin-top: 15px;
  margin-bottom: 35px;
  border: 10px;
  background-color: rgb(238, 238, 238); /*This background should better stand out */
  box-shadow: 5px 5px 5px rgb(209, 209, 209);
  border-radius: 5px;
}

.cta {
  font-size: 1.5rem;
  font-weight: 500;
}

.ctaText {
  padding-right: 10px;
  font-size: 2.0rem;
}

.btn-custom-submit-bid {
  background:  #3ac03a; 
  border-radius: 10px;
  color: white;
  font-weight: 600;
  font-size: 18px;
  margin: 4px 4px 20px 4px;
  width: 400px;
  padding: 10px;
  
}

.btn-custom-submit-bid:hover {
  transform: translateY(2px);
}

.btn-custom-submit-bid:after {
  color: #28A745;
  background-color: white;
  font-weight: 600;
  font-size: 18px;
  margin: 4px;
}
</style>
