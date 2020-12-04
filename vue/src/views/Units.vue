<template>
  <div class="units">
    <!-- List all Units -->
    <UnitCard
      v-for="u in this.$store.state.units"
      v-bind:key="u.id"
      v-bind:unit="u"
    />
  </div>
</template>

<script>
import UnitCard from "../components/UnitCard.vue";

export default {
  name: "Units",

  components: {
    UnitCard,
  },
};
</script>

<style></style>
