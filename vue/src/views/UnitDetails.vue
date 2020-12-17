<template>
  <div class="container">
    <UnitCard v-bind:unit="unitDetails"> </UnitCard>

    <!-- TODO: Need to input some boolean check to verify the amount entered is 
    higher than the current high bid, and connect form to add bid to log and change 
    high bid value on the unit.
    -->
    <router-link
      v-if="!auctionEnded(unitDetails.auctionEnd)"
      :to="{ name: 'place-bid', params: { id: this.unitDetails.unitId } }"
    >
      <button class="btn btn-custom-units-bid">Place Bid</button>
    </router-link>

    <br />

    <router-link v-bind:to="{ name: 'units' }">
      <button class="btn btn-light">
        Return to List of Units
      </button>
    </router-link>

    <p />

    <router-link
      v-if="userRole == 'admin'"
      :to="{ name: 'edit-unit', params: { id: this.unitDetails.unitId } }"
    >
      <button class="btn btn-primary">Edit Unit</button>
    </router-link>

    <router-link
      v-if="userRole == 'admin'"
      :to="{
        name: 'contact-winner',
        params: { username: highBidDetails.username },
      }"
    >
      <button
        class="btn btn-primary"
        data-toggle="modal"
        data-target="#exampleModal"
      >
        Email Winner
      </button>
    </router-link>

    <button
      class="btn btn-primary"
      v-if="userRole == 'admin'"
      v-on:click.prevent="deleteUnit()"
    >
      Delete Unit
    </button>

    <button
      class="btn btn-primary"
      v-if="userRole == 'admin'"
      v-on:click="userRole = !userRole"
    >
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
      unitDetails: undefined,

      userRole: this.$store.state.user.role,

      // message: {
      //   messageBody: "",
      // },

      highBidDetails: undefined,
    };
  },

  created() {
    // Populate 'unitDetails' data
    this.unitDetails = this.$store.state.units.find(
      (u) => u.unitId == this.$route.params.id
    );

    // Populate 'HighBidDetails'
    this.highBidDetails = this.$store.state.bids.find(
      (bid) => bid.bidAmount === this.unitDetails.highBid
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

    AddNewBid() {
      //TODO: populate method to add to list of bids
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
};
</script>

<style>
.btn-primary {
  margin: 3px;
}
.btn-custom-units-bid {
  background: linear-gradient(
    110deg,
    rgb(248, 103, 6) 28%,
    rgb(255, 189, 68) 100%
  );
  color: white;
  font-weight: 600;
  font-size: 18px;
  margin: 4px;
  width: 400px;
  padding: 10px;
}

.btn-custom-units-bid:hover {
  transform: translateY(2px);
}

.btn-custom-units-outline:after {
  color: linear-gradient(110deg, rgb(248, 103, 6) 28%, rgb(255, 189, 68) 100%);
  background-color: white;
  font-weight: 600;
  font-size: 18px;
  margin: 4px;
}

.emailCc {
  font-size: 14px;
  text-align: right;
  padding-right: 20px;
}

.emailContent {
  text-align: left;
  padding: 10px;
  background-color: rgb(238, 238, 238);
  box-shadow: 5px 5px 5px rgb(209, 209, 209);
  border-radius: 5px;
}

.emailBody {
  font-size: 16px;
  font-weight: 500;
  margin: 5px;
}

/*
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
*/
</style>
