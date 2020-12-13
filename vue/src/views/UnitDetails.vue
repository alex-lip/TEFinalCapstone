<template>
  <div>
    <UnitCard v-bind:unit="unitDetails"> </UnitCard>

    <button class="btn-custom" v-on:click="showBidForm = !showBidForm">
      Bid on Unit
    </button>

    <!-- TODO: Need to input some boolean check to verify the amount entered is 
    higher than the current high bid, and connect form to add bid to log and change 
    high bid value on the unit.
    -->
    <form id="frmAddNewBid" v-show="showBidForm">
      <div class="field">
        <label for="bidAmount">Please enter your bid: </label>
        <input type="text" name="bidAmount" />  
        <!-- v-model.trim="bid.bidAmount" -->
      </div>
    </form>

    <router-link v-bind:to="{ name: 'units' }">
      <button class="btn-custom-outline">
        Return to List of Units
      </button>
    </router-link>

    <p />

    <router-link
      v-if="userRole == 'admin'"
      :to="{ name: 'edit-unit', params: { id: this.unitDetails.unitId } }"
    >
      <button class="btnEditUnit">Edit Unit</button>
    </router-link>

    <button
      class="btnDeleteUnit"
      v-if="userRole == 'admin'"
      v-on:click.prevent="deleteUnit()"
    >
      Delete Unit
    </button>

    <button v-if="userRole == 'admin'" v-on:click="userRole = !userRole">
      User View
    </button>
  </div>
</template>

<script>
import unitService from "../services/UnitService";
import UnitCard from "../components/UnitCard";

export default {
  name: "unit-details",

  components: {
    UnitCard,
  },

  props: {
    unitId: Number,
  },

  data() {
    return {
      showBidForm: false,
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
  },

  computed: {},

  methods: {
    deleteUnit() {
      // use filter to grab from state
      const confirmed = confirm(
        "Are you sure you want to delete this unit? This cannot be undone"
      );

      if (confirmed) {
        unitService.deleteUnit(this.unitDetails.unitId).then((response) => {
          console.debug("Unit deleted", response);

          if (response.status === 204) {
            // Call out to our web service and have it make the delete
            // this.$store.commit("UNIT_DELETED", this.unit);
            this.$router.push({ name: "units" });
          }
        });
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
</style>
