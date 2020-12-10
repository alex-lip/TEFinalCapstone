<template>
  <form @submit.prevent="updateUnit()">
    <div class="field">
      <label for="unitNumber">Location Name</label>
      <input type="text" v-model="locationName" />
    </div>
    <div class="field">
      <label for="unitNumber">Unit Number</label>
      <input type="text" v-model="unitNumber" />
    </div>
    <div class="field">
      <label for="unitNumber">Unit Size</label>
      <input type="text" v-model="unitSize" />
    </div>
    <div class="field">
      <label for="unitNumber">Inventory Pictures</label>
      <input type="text" v-model="unitPictures" />
    </div>
    <!--<div class="field">
      <label for="unitNumber">Unit Notes</label>
      <input type="text" v-model="unit.unitNotes" />
    </div>-->
    <div class="actions">
      <router-link v-bind:to="{ name: 'units' }">
        <button type="submit">Save Changes to Unit</button>
      </router-link>
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
      unitNumber: "",
      unitSize: "",
      unitPictures: "",
    };
  },
  methods: {
    updateUnit() {
      const unit = {
        id: this.unitId,
        locationName: this.locationName,
        unitNumber: this.unitNumber,
        unitSize: this.unitSize,
        unitPictures: this.unitPictures,
      };
      unitService.editUnit(this.unitId, unit).then((response) => {
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
