<template>
  <div class="units">
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
          <td></td>
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
body {
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
</style>
