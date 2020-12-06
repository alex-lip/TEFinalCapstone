<template>
  <div class="unit-card">
    <div>Current Bid: {{ unit.highBid }}</div>
    <div>Location: {{ unit.locationName }}</div>
    <div>Picture ID: {{ unit.picturesUnitNumber }}</div>
    <div>Unit ID: {{ unit.unitId }}</div>
    <div>Unit Number: {{ unit.unitNumber }}</div>
    <div>Size: {{ unit.unitSize }}</div>

    <p>Make each card clickable to go to specific unit page</p>
    <p>Edit and Delete buttons</p>
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
  background-color: red;
}
</style>
