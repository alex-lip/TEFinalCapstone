<template>
  <div class="units">
    <!-- Create a dropdown selection in order to filter by location -->  

    <!-- Added this commented out table here, wasn't sure if I should put it in, we never really came to a full agreement on the display for the selection of units
    <div>
    <h2 id = contents>
    <table border="1" width="100%">
	<col style="width:10%">
	<col style="width:10%">
	<col style="width:10%">
  <col style="width:70%">
	<thead>
	<tr>
		<th>Unit Location</th>
		<th>Unit Number</th>
		<th>Unit Size</th>
    <th>Unit Details </th>
	</tr>
  <tr>
		<th>{{ unit.locationName }}</th>
		<th>{{ unit.unitNumber }}</th>
		<th>{{ unit.unitSize }}</th>
    <th>Inventory Pictures</th> Need to add link here to pull up the unit card so users can see unit pictures and current high bid
	</tr>
	</thead>  
      </h2>
  </div>-->

    <!-- List all Units -->
    <UnitCard
      v-for="u in this.$store.state.units"
      v-bind:key="u.id"
      v-bind:unit="u"
    >
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

<style>
body {
  font-family: system-ui;
  background: #ff944d;
  color: black;
  text-align: left;
}


</style>
