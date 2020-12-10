<template>
  <div>
    <UnitCard
      v-bind:unit="unitDetails"
    >
    </UnitCard>
    <router-link v-bind:to="{name: 'edit-unit'}">
    <button class="btnEditUnit">Edit Unit</button><!--TODO: need to code to link the form to edit the unit, EditUnit.vue/ and code so it is hidden to nonAdmin users-->
    </router-link>
    <button class="btnDeleteUnit" v-on:click="deleteUnit(unitDetails.unitId)">Delete Unit</button><!--TODO: need to code to link to the deleteUnit method in UnitDetails/ and code so it is hidden to nonAdmin users-->
  </div>
</template>

<script>
import unitService from "../services/UnitService";
import UnitCard from "../components/UnitCard";

export default {
  name: "unit-details",
  components: {
    UnitCard,
  },
  props:{
    unitId: Number
  },
  data() {
    return {
      unitDetails: undefined,
    };
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
  methods: {
    deleteUnit(id) {
      const confirmed = confirm(
        "Are you sure you want to delete this unit? This cannot be undone"
      );

      if (confirmed) {
        unitService.deleteUnit(id).then((response) => {
          console.debug("Unit deleted", response);

          if (response.status === 200) {
            //Call out to our web service and have it make the delete
            this.$store.commit("UNIT_DELETED", this.unit);
            this.$router.push({ name: "Units" });
          }
        });
      }
    },
  },
};
</script>

<style></style>
