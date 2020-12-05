<template>
  <div class="units">
    <!-- Create a dropdown selection in order to filter by location -->

    <!-- List all Units -->
    <UnitCard
      v-for="u in this.$store.state.units"
      v-bind:key="u.id"
      v-bind:unit="u"
    >
    <div></div>
    </UnitCard>

    <p>Segment to add unit (Part of the "Unit Information" Card)</p>
  </div>
</template>

<script>
import unitService from "../services/UnitService";
import UnitCard from "../components/UnitCard.vue";

export default {
  name: "Units",

  components: {
    UnitCard,
  },

  data() {
    return {
      unit: {
        // Idk the unit properties that I need yet.
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
};
</script>

<style></style>
