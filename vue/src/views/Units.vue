<template>
  <div class="container-sm units">
    <h1 id="title">Storage Auctions</h1>
    <p></p>
    <h3 id="title">Full Listing of all units available for auction</h3>
    <h3 id="title">
      Click on the individual auction numbers to see further details and/or
      place a bid
    </h3>
    <router-link v-bind:to="{ name: 'add-unit' }">
      <button class="btn btn-primary" v-if="userRole == 'admin'">Add Unit</button>
    </router-link>
    <router-link v-bind:to="{ name: 'all-bids' }">
      <button class="btn btn-primary" v-if="userRole == 'admin'">View All Bids</button>
    </router-link>
    <button class="btn btn-primary" v-if="userRole == 'admin'" v-on:click="userRole = !userRole">
      User View
    </button>
    <p></p>
    <table class="table table-striped table-hover" id="tblUnits">
      <thead>
        <tr>
          <th scope="col">Auction Number</th>
          <th scope="col">Location Name</th>
          <th scope="col">Unit Number</th>
          <th scope="col">Unit Size</th>
          <th scope="col">High Bid</th>
          <th scope="col" id="viewDetails">Unit Details</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td >Filter</td>
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
              id="unitNumberFilter"
              placeholder="Unit Number"
              v-model.number="filter.unitNumber"
            />
          </td>
          <td>
            <input
              type="text"
              id="unitSizeFilter"
              placeholder="Unit Size"
              v-model="filter.unitSize"
            />
          </td>
          <td>
            <input
              type="text"
              id="highBidFilter"
              placeholder="High Bid"
              v-model.number="filter.highBid"
            />
          </td>
          <td></td>
        </tr>
        <tr v-for="unit in filteredList" v-bind:key="unit.id">
          <td>
            <!--link to route to specific unit and its details like time left and pictures-->
            <router-link
              class="unit-id"
              v-bind:to="{ name: 'unit-details', params: { id: unit.unitId } }"
            >
              {{ unit.unitId }}
            </router-link>
          </td>
          <td>{{ unit.locationName }}</td>
          <td>{{ unit.unitNumber }}</td>
          <td>{{ unit.unitSize }}</td>
          <td>${{ unit.highBid }}.00</td>
          <td>
            <!--link to route to specific unit and its details like time left and pictures-->
            <router-link
              class="unit-id"
              v-bind:to="{ name: 'unit-details', params: { id: unit.unitId } }">
            <button type="button" class="btn btn-custom-units">Details</button>
            </router-link>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import unitService from "../services/UnitService";

export default {
  name: "Units",

  data() {
    return {
      filter: {
        id: null,
        locationName: "",
        unitNumber: "",
        unitSize: "",
        highBid: "",
      },

      userRole: this.$store.state.user.role,
    };
  },

  methods: {
    // Methods to create, read, update, and delete...
    getUnits() {
      unitService.getAllUnits().then((response) => {
        this.$store.commit("SET_UNITS", response.data);
      });
    },
  },

  created() {
    // Populate the $store with all Available Units
    this.getUnits();
  },

  computed: {
    filteredList() {
      let filteredUnits = this.$store.state.units;
      if (this.filter.locationName != "") {
        filteredUnits = filteredUnits.filter((unit) =>
          unit.locationName
            .toLowerCase()
            .includes(this.filter.locationName.toLowerCase())
        );
      }
      if (this.filter.unitNumber != "") {
        filteredUnits = filteredUnits.filter(
          (unit) => unit.unitNumber === this.filter.unitNumber
        );
      }
      if (this.filter.unitSize != "") {
        filteredUnits = filteredUnits.filter((unit) =>
          unit.unitSize.startsWith(this.filter.unitSize)
        );
      }
      if (this.filter.highBid != "") {
        filteredUnits = filteredUnits.filter(
          (unit) => unit.highBid <= this.filter.highBid
        );
      }
      return filteredUnits;
    },
  },
};
</script>

<style scoped>
tr {
  font-size: 18px;
  font-weight: 500;
}

.btn-custom-units {
  background: linear-gradient(110deg, rgb(248, 103, 6) 28%, rgb(255, 189, 68) 100%);
  color: white;
  font-weight: 600;
  font-size: 18px;
  margin: 4px;
}

.btn-custom-units:hover {
  background: linear-gradient(170deg, rgb(248, 103, 6) 0%, rgb(255, 189, 68) 100%);
}

.btn-custom-units:active {
  background: linear-gradient(170deg, rgb(248, 103, 6) 100%, rgb(255, 189, 68) 100%);
  box-shadow: 0 5px rgb(255, 160, 52);
  transform: translateY(4px);
}

.btn-primary {
  margin: 3px;
}

</style>
