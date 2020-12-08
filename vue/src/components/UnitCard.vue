<template>
  <div class="unit-card">
    <div>Unit ID: {{ unit.unitId }}</div>
    <div>Location: {{ unit.locationName }}</div>
    <div>Unit Number: {{ unit.unitNumber }}</div>
    <div>Size: {{ unit.unitSize }}</div>
    <div>Current Bid: {{ unit.highBid }}</div>
    <div>Picture ID: {{ unit.picturesUnitNumber }}</div>
    <!--TODO: Need to add multiple pictures not just picture number-->

    <div>
    <button class="btnEditUnit">Edit Unit</button><!--TODO: need to code to link the form to edit the unit, EditUnit.vue/ and code so it is hidden to nonAdmin users-->
    <button class="btnDeleteUnit">Delete Unit</button><!--TODO: need to code to link to the deleteUnit method in UnitDetails/ and code so it is hidden to nonAdmin users-->
    </div>
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
  border: 3px solid black;
  border-radius: 10px;
}
</style>
