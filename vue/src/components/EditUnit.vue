<template>
  <div class="container-sm">
    <h1 class="text-center">Edit Unit Details</h1>
    <form @submit.prevent="updateUnit()">
      <div class="field">
        <label for="unitNumber">Location Name</label>
        <select
          class="form-control"
          v-model="unitDetails.locationName"
          required
        >
          <option>Village Mini Storage South</option>
          <option>Village Mini Storage North</option>
          <option>Millersport Storage</option>
          <option>Stow-Away</option>
          <option>204 Self-Storage</option>
          <option>Pickaway Self-Storage</option>
        </select>
      </div>
      <div class="field">
        <label for="unitNumber">Unit Number</label>
        <input
          type="text"
          class="form-control"
          v-model.number="unitDetails.unitNumber"
        />
      </div>
      <div class="field">
        <label for="unitSize">Unit Size</label>
        <input
          type="text"
          class="form-control"
          v-model="unitDetails.unitSize"
        />
      </div>
      <div class="field">
        <label for="unitPictures">Inventory Pictures</label>
        <input
          type="text"
          class="form-control"
          v-model="unitDetails.pictures"
        />
      </div>
      <div class="form-group">
        <label for="notes">Notes</label>
        <input
          type="text"
          class="form-control"
          id="notes"
          v-model="unitDetails.notes"
        />
      </div>
      <div class="form-group">
        <label for="facilityAddress">Facility Address</label>
        <select
          class="form-control"
          id="facilityAddress"
          v-model.trim="unitDetails.facilityAddress"
          required
        >
          <option>1001 S Main St. Baltimore, OH 43105</option>
          <option>67290 Lancaster St. Millersport, OH 43046</option>
          <option>806 E. Findlay St. Carey, OH 43316</option>
          <option>State Route 182/531 Raybestos Upper Sandusky, OH 43351</option>
          <option>1815 E. Mansfield St. Bucyrus, OH 44820</option>
          <option>State Route 235 Ada, OH 45810</option>
          <option>1379 State Route 68 N Dunkirk, OH 45836</option>
          <option>13450 State Route 68 S Kenton, OH 43326</option>
          <option>1143 County Rd. 130 Bellefontaine, OH 43311</option>
          <option>1345 N. Main St. Urbana, OH 43078</option>
          <option>1471 Milford Rd. Marysville, OH 43040</option>
          <option>4750 Cottonville Rd. Jamestown, OH 45335</option>
          <option>10445 Blacklick-Eastern Rd. NW Pickerington 43147</option>
          <option>500 Hill Rd N, Pickerington, OH 43147</option>
          <option>80773 Lancaster-Kirkersville Rd NW, Baltimore, OH 43105</option>
        </select>
      </div>
      <div class="form-group">
        <label for="endDate">End Date</label>
        <input
          class="form-control"
          id="endDate"
          type="datetime-local"
          v-model="unitDetails.auctionEnd"
        />
      </div>
      <div class="form-group">
        <label for="highBid">High Bid</label>
        <input
          type="text"
          class="form-control"
          id="highBid"
          v-model.number="unitDetails.highBid"
        />
      </div>
      <div class="actions">
        <button type="submit" class="btn btn-custom">
          Save Changes to Unit
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import unitService from "../services/UnitService";

export default {
  props: ["unitId"],
  data() {
    return {
      unitDetails: undefined,
    };
  },
  methods: {
    updateUnit() {
      unitService
        .editUnit(this.unitDetails.unitId, this.unitDetails)
        .then((response) => {
          if (response.status === 200) {
            //this.$store.commit('UNIT_UPDATED', this.unit);
            if (this.$router.currentRoute.name !== "Units") {
              this.$router.push({
                name: "unit-details",
                params: { unitId: this.unitDetails.unitId }
              });
            }
          }
        });
    },
  },
  created() {
    this.unitDetails = this.$store.state.units.find(
      (u) => u.unitId == this.$route.params.id
    );
  },
};
</script>

<style scoped>
.container-sm {
  border: black;
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
