<template>
  <div class="unit-card">
    <!-- <div>Unit ID: {{ unit.unitId }}</div> -->
    <div>Unit Number: {{ unit.unitNumber }}</div>
    <div>Location: {{ unit.locationName }}</div>
    <div>Size: {{ unit.unitSize }}</div>
    <div>Details: {{ unit.notes }}</div>
    <div>Current Bid: {{ unit.highBid }}</div>
    <img v-bind:src="'https://i.imgur.com/epMSRQH.png'" />
    <!-- <div>Picture ID: {{ unit.pictures }}</div> -->
    <!--TODO: Need to add multiple pictures not just picture number-->
  </div>
</template>

<script>
export default {
  props: {
    unit: Object, // This prop is hooked to 'u' in 'Units.vue'
  },
};
</script>

<style>
.unit-card {
  background-color: white;
  border: 5px solid black;
  border-radius: 10px;
}

img {
  width: 100%;
  max-width: 400px;
  height: auto;
}
</style>
