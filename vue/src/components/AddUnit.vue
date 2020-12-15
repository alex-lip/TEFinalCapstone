<template>
  <div class="container-sm">
    <h1 class="text-center">Add Unit</h1>
    <form @submit.prevent="saveUnit()">
      <div class="form-group">
        <label for="locationName">Location Name</label>
        <select
          class="form-control"
          id="locationName"
          v-model.trim="newUnit.locationName"
          required
        >
          <option>Village Mini Storage South</option>
          <option>Village Mini Storage North</option>
          <option>Millersport Storage</option>
          <option>Stow-Away</option>
          <option>204 Self-Storage</option>
          <option>Pickaway Self-Storage</option>
        </select>
        <!-- <input
          type="text"
          class="form-control"
          id="locationName"
          v-model.trim="newUnit.locationName"
          autocomplete="location"
          required
        /> -->
      </div>
      <div class="form-group">
        <label for="unitNumber">Unit Number</label>
        <input
          type="text"
          class="form-control"
          id="unitNumber"
          v-model.number="newUnit.unitNumber"
          autocomplete="number"
          required
        />
      </div>
      <div class="form-group">
        <label for="unitSize">Unit Size</label>
        <input
          type="text"
          class="form-control"
          id="unitSize"
          v-model.trim="newUnit.unitSize"
          autocomplete="size"
        />
      </div>
      <div class="form-group">
        <label for="pictures">Inventory Pictures</label>
        <input
          type="text"
          class="form-control"
          id="unitPicture"
          v-model.trim="newUnit.pictures"
          autocomplete="size"
        />
      </div>
      <div class="form-group">
        <label for="notes">Notes</label>
        <input
          type="text"
          class="form-control"
          id="notes"
          v-model.trim="newUnit.notes"
        />
      </div>
      <div class="form-group">
        <label for="facilityAddress">Facility Address</label>
        <select
          class="form-control"
          id="facilityAddress"
          v-model.trim="newUnit.facilityAddress"
          required
        >
          <option>1001 S Main St. Baltimore, OH 43105</option>
          <option>67290 Lancaster St. Millersport, OH 43046</option>
        </select>
        <!-- <input type="text"
          class="form-control"
          id="facilityAddress"
          v-model.trim="newUnit.facilityAddress"
        /> -->
      </div>
      <div class="form-group">
        <label for="auctionEnd">End Date</label>
        <input
          class="form-control"
          id="auctionEnd"
          type="datetime-local"
          v-model.trim="newUnit.auctionEnd"
        />
      </div>
      <div class="form-group">
        <label for="highBid">High Bid</label>
        <input
          type="text"
          class="form-control"
          id="highBid"
          v-model.number="newUnit.highBid"
        />
      </div>
      <button type="submit" class="btn btn-custom">Create</button>
    </form>
  </div>
</template>

<script>
import UnitService from "../services/UnitService.js";

export default {
  data() {
    return {
      errorMessage: "",

      newUnit: {
        locationName: "",
        unitNumber: 0,
        unitSize: "",
        pictures: "",
        notes: "",
        facilityAddress: "",
        auctionEnd: undefined,
        highBid: 0,
      },
    };
  },
  methods: {
    saveUnit() {
      UnitService.createNewUnit(this.newUnit)
        .then((/*response*/) => {
          // const newUnit = response.data;
          // this.$store.commit("UNIT_ADDED", newUnit);
          // this.$router.push({
          //   name: "UnitDetails",
          //   params: { unitId: newUnit.id },
          // });
          this.$router.push({
            name: "units",
          });
        })
        .catch((error) => {
          this.errorMessage = error.message;
        });
    },
  },
};
</script>

<style scoped>
.container-sm {
  border: black;
  background-color: rgb(238, 238, 238);
  box-shadow: 5px 5px 5px rgb(209, 209, 209);
  padding-bottom: 50px;
  margin-top: 15px;
  margin-bottom: 15px;
  font-size: 14pt;
  font-weight: 600;
  text-align: left;
}

.text-center {
  text-align: center;
}
</style>
