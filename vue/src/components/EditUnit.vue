<template>
  <form v-on:submit.prevent>
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
      <label for="unitNumber">Iventory Pictures</label>
      <input type="text" v-model="unitPictures" />
    </div>
    <div class="field">
      <label for="unitNumber">Unit Notes</label>
      <input type="text" v-model="unitPictures" />
    </div>
    <div class="actions">
      <button type="submit" v-on:click="updateUnit()">Save Changes to Unit</button>
    </div>
  </form>
</template>

<script>
import unitService from "../services/UnitService";

export default {
  name: "create-unit",
  props: ["unitID"],
  data() {
    return {
      title: ""
    };
  },
  methods: {
    updateUnit() {
      const unit = { id: this.unitId };
        unitService
        .editUnit(this.unitId, unit)
        .then((response) => {
          if (response.status === 200){

        // Navigate away as needed
        if (this.$router.currentRoute.name !== "Units") {
          this.$router.push({ name: "Units" });
          }
         }
        });
    }
  },
  created() {
    unitService
      .get(this.unitId)
      .then(response => {
        this.$store.commit("SET_UNIT", response.data);
      })
      .catch(error => {
        if (error.response.status == 404) {
          this.$router.push("/not-found");
        }
      });
  }
};
</script>

<style>
</style>

