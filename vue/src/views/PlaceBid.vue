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
          v-model.trim.number="unitDetails.highBid"
        />
        <button
          type="submit"
          class="btnSubmit"
          v-on:click.prevent="addNewBid()"
        >
          Submit Bid
        </button>
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
      bidAmount: 0,
      bidError: false,
      unitDetails: undefined,

      userRole: this.$store.state.user.role,
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
