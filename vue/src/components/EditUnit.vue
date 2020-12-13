<template>
  <div class="container-sm">
    <h1 class="text-center">Edit Unit Details</h1>
    <form @submit.prevent="updateUnit()">
      <div class="field">
        <label for="unitNumber">Location Name</label>
        <input
          type="text"
          class="form-control"
          v-model="unitDetails.locationName"
        />
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
        <input
          type="text"
          class="form-control"
          id="facilityAddress"
          v-model="unitDetails.facilityAddress"
        />
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

<style>
.container-sm {
  border: black;
  background-color: rgb(255, 248, 248);
  padding-bottom: 50px;
  font-size: 14pt;
  font-weight: 600;
  text-align: left;
}

.text-center {
  text-align: center;
}
</style>
