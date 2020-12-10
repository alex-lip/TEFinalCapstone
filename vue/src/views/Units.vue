<template>
  <div class="units">
    <h1 id = title>Storage Auctions</h1>
    <p></p>
    <h3 id = title>Full Listing of all units avaiable for auction</h3>
    <h3 id = title>Click on the individual auction numbers to see further details and/or place a bid</h3>
    <router-link v-bind:to="{name: 'add-unit'}">
    <button class="btnAddUnit">Add Unit</button><!--TODO: hide button for nonAdmin users-->
    </router-link>
    <p></p>
    <table id="tblUnits">
      <thead>
        <tr>
          <th>Auction Number</th>
          <th>Location Name</th>
          <th>Unit Number</th>
          <th>Unit Size</th>
          <th>High Bid</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
          </td>
          <td>
            <input
              type="text"
              id="locationNameFilter"
              v-model="filter.locationName"
            />
          </td>
          <td>
            <input
              type="text"
              id="unitNumberFilter"
              v-model="filter.unitNumber"
            />
          </td>
          <td>
            <input type="text" id="unitSizeFilter" v-model="filter.unitSize" />
          </td>
          <td>
            <input type="text" id="highBidFilter" v-model="filter.highBid" />
          </td>
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
          <td>{{ unit.highBid }}</td>
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
        filteredUnits = filteredUnits.filter((unit) =>
          unit.unitNumber
            .toLowerCase()
            .includes(this.filter.unitNumber.toLowerCase())
        );
      }
      if (this.filter.unitSize != "") {
        filteredUnits = filteredUnits.filter((unit) =>
          unit.unitSize
            .toLowerCase()
            .includes(this.filter.unitSize.toLowerCase())
        );
      }
      if (this.filter.highBid != "") {
        filteredUnits = filteredUnits.filter((unit) =>
          unit.highBid.toLowerCase().includes(this.filter.highBid.toLowerCase())
        );
      }
      return filteredUnits;
    },
  },
};
</script>

<style>
#tblUnits {
  margin-left: auto;
  margin-right: auto;
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

table,
th,
td {
  border: 1px solid black;
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
