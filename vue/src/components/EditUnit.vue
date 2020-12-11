<template>
  <form @submit.prevent="updateUnit()">
    <div class="field">
      <label for="unitNumber">Location Name</label>
      <textarea class="form-control" v-model="locationName" /><!--placeholder={{unit.locationName}}-->
    </div>
    <div class="field">
      <label for="unitNumber">Unit Number</label>
      <textarea class="form-control" v-model="unitNumber" /><!--placeholder={{unit.unitNumber}}-->
    </div>
    <div class="field">
      <label for="unitSize">Unit Size</label>
      <textarea class="form-control" v-model="unitSize" /><!--placeholder={{unit.unitSize}}-->
    </div>
    <div class="field">
      <label for="unitPictures">Inventory Pictures</label>
      <textarea class="form-control" v-model="unitPictures" /><!--placeholder={{unit.unitPictures}}-->
    </div>
    <div class="form-group">
      <label for="notes">Notes</label>
      <textarea class="form-control" id="notes" v-model="unitNotes" /><!--placeholder={{unit.unitNotes}}-->
    </div>
    <div class="form-group">
      <label for="facilityAddress">Facility Address</label><!--placeholder={{unit.facilityAddress}}-->
      <textarea
        class="form-control"
        id="facilityAddress"
        v-model="facilityAddress"
      />
    </div>
    <div class="form-group">
      <label for="endDate">End Date</label>
      <textarea class="form-control" id="endDate" v-model="endDate" /><!--placeholder={{unit.facilityAddress}} -->
    </div>
    <div class="form-group">
      <label for="highBid">High Bid</label><!--placeholder={{unit.highBid}}-->
      <textarea
        class="form-control"
        id="highBid"
        v-model.number="highBid"
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
  name: "create-unit",
  props: ["unitId"],
  data() {
    return {
      locationName: "",
      unitNumber: 0,
      unitSize: "",
      unitPictures: "",
      unitNotes: "",
      facilityAddress: "",
      highBid: 0,
      endDate: ''
    };
  },
  methods: {
    updateUnit() {
      const unit = {
        locationName: this.locationName,
        unitNumber: this.unitNumber,
        unitSize: this.unitSize,
        unitPictures: this.unitPictures,
        unitNotes: this.unitNotes,
        facilityAddress: this.facilityAddress,
        highBid: this.highBid,
        endDate: this.endDate
      };
      unitService.editUnit(this.$props.unitId, unit).then((response) => {
        if (response.status === 200) {
          //this.$store.commit('UNIT_UPDATED', this.unit);
          if (this.$router.currentRoute.name !== "Units") {
            this.$router.push({ name: "Units" });
          }
        }
      });
    },
  },
  // created() {
  //   unitService
  //     .get(this.unitId)
  //     .then((response) => {
  //       this.$store.commit("SET_UNIT", response.data);
  //     })
  //     .catch((error) => {
  //       if (error.response.status == 404) {
  //         this.$router.push("/not-found");
  //       }
  //     });
  // },
};
</script>

<style></style>
