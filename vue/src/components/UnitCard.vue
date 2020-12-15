<template>
  <div class="unit-card">
    <!--<div>Unit ID: {{ unit.unitId }}</div>-->
    <div id="unit-num">Unit Number: {{ unit.unitNumber }}</div>
    <div>Location: {{ unit.locationName }}</div>
    <!-- <div>Address: {{unit.facilityAddress}}</div> -->
    <div>Size: {{ unit.unitSize }}</div>
    <div>Details: {{ unit.notes }}</div>
    <div>Current Bid: ${{ unit.highBid }}</div>
    <div>End of Auction: {{unit.auctionEnd}}</div>
    <img :src="unit.pictures" />
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
#unit-num {
  font-weight: bold;
  font-size: 1.5rem;
  /* text-align: left; */

  margin-top: 1rem;
}

.unit-card {
  background-color: white;
  /* border: 5px solid black; */
  border-radius: 10px;
}

img {
  width: 100%;
  max-width: 400px;
  height: auto;

  border-radius: 2rem;
  margin-top: 1rem;
  margin-bottom: 1rem;
}
</style>
