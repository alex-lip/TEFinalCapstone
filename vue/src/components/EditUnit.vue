<template>
  <form @submit.prevent="updateUnit()">
    <div class="field">
      <label for="unitNumber">Location Name</label>
      <textarea class="form-control" v-model="this.unitDetails.locationName" />
    </div>
    <div class="field">
      <label for="unitNumber">Unit Number</label>
      <textarea class="form-control" v-model="this.unitDetails.unitNumber" />
    </div>
    <div class="field">
      <label for="unitSize">Unit Size</label>
      <textarea class="form-control" v-model="this.unitDetails.unitSize" />
    </div>
    <div class="field">
      <label for="unitPictures">Inventory Pictures</label>
      <textarea class="form-control" v-model="this.unitDetails.picturesUnitNumber" />
    </div>
    <div class="form-group">
      <label for="notes">Notes</label>
      <textarea class="form-control" id="notes" v-model="this.unitDetails.notes" />
    </div>
    <div class="form-group">
      <label for="facilityAddress">Facility Address</label>
      <textarea
        class="form-control"
        id="facilityAddress"
        v-model="this.unitDetails.facilityAddress"
      />
    </div>
    <div class="form-group">
      <label for="endDate">End Date</label>
      <textarea class="form-control" id="endDate" v-model="this.unitDetails.auctionEnd" />
    </div>
    <div class="form-group">
      <label for="highBid">High Bid</label>
      <textarea
        class="form-control"
        id="highBid"
        v-model.number="this.unitDetails.highBid"
      />
    </div>
    <div class="actions">
        <button type="submit">Save Changes to Unit</button>
    </div>
  </form>
</template>

<script>
import unitService from "../services/UnitService";

export default {
  props: ["unitId"],
  data() {
    return {
      unitDetails: undefined,
      //locationName: "",
      //unitNumber: 0,
      //unitSize: "",
      //unitPictures: "",
      //unitNotes: "",
      //facilityAddress: "",
      //highBid: 0,
      //endDate: ''
    };
  },
  methods: {
    
    updateUnit() {
      /*const unit = {
        locationName: this.locationName,
        unitNumber: this.unitNumber,
        unitSize: this.unitSize,
        unitPictures: this.unitPictures,
        unitNotes: this.unitNotes,
        facilityAddress: this.facilityAddress,
        highBid: this.highBid,
        endDate: this.endDate
      };*/
      unitService.editUnit(this.unitDetails.unitId, this.unitDetails).then((response) => {
        if (response.status === 200) {
          //this.$store.commit('UNIT_UPDATED', this.unit);
          if (this.$router.currentRoute.name !== "Units") {
            this.$router.push({ name: "Units" });
          }
        }
      });
    },
  },
   created() {
    this.unitDetails = this.$store.state.units.find(
      (u) => u.unitId == this.$route.params.id
    );
    if (!this.unitDetails) {
      this.unitDetails = this.$store.state.units.find(
        (u) => u.unitId == this.$route.params.id
      );
    }
  },
};
</script>

<style></style>
