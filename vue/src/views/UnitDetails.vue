<template>
  <div>
    <UnitCard v-bind:unit="unitDetails"> </UnitCard>

    <button class="btnPlaceBid">
      Bid on Unit
    </button>
    <p />
    <router-link
      v-if="userRole == 'admin'"
      :to="{ name: 'edit-unit', params: { id: this.unitDetails.unitId } }"
    >
      <!-- <button class="btnEditUnit">Edit Unit</button> -->
      Edit Unit
    </router-link>
    <!--TODO: code so it is hidden to nonAdmin users-->

    <button
      class="btnDeleteUnit"
      v-if="userRole == 'admin'"
      v-on:click="deleteUnit(unitDetails.unitId)"
    >
      Delete Unit
    </button>
    <!--TODO: need to code to link to the deleteUnit method in UnitDetails/ and code so it is hidden to nonAdmin users-->
    <button v-if="userRole == 'admin'" v-on:click="userRole = !userRole">
      User View
    </button>
  </div>
</template>

<script>
import unitService from "../services/UnitService";
import UnitCard from "../components/UnitCard";

export default {
  name: "unit-details",

  components: {
    UnitCard,
    //unitService,
  },

  props: {
    unitId: Number,
  },

  data() {
    return {
      unitDetails: undefined,

      userRole: this.$store.state.user.role,
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

  computed: {},

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
