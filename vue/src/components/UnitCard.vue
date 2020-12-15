<template>
  <!-- if we have time, we should add a countdown timer
  https://github.com/tyler-morales/countdown/blob/master/src/components/CountdownCard.vue -->
  <div class="unit-card container">
    <div class="row">
      <div class="col-sm">
    <!--<div>Unit ID: {{ unit.unitId }}</div>-->
    <div class="unitNumber">Unit Number: {{ unit.unitNumber }}</div>
    <div class="locationName">{{ unit.locationName }}</div>
    <img :src="unit.pictures" />
    </div>
    <div class="col-sm">
      
    <div class="auctionDetails">
      <div>
      <span class="icons">
        <i class="fas fa-clock"></i>
      </span>
      End of Auction: {{unit.auctionEnd}}</div>
    <div>
      <span class="icons">
        <i class="fas fa-map"></i>
      </span>
      Address: {{unit.facilityAddress}}</div>
    </div>
    <div class="auctionDetails">
    <div>
      <span class="icons">
        <i class="fas fa-gavel"></i>
      </span>
      Current Bid: </div>
      <div class="highBid">
      ${{ unit.highBid }}.00</div>
    <div>Size: {{ unit.unitSize }}</div>
    <div>Details: {{ unit.notes }}</div>
    
    <div>End of Auction: {{unit.auctionEnd}}</div>
    </div>
    </div>
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
#unit-num {
  font-weight: bold;
  font-size: 1.5rem;
  /* text-align: left; */

  margin-top: 1rem;
}

.unit-card {
  /*background-color: white;
  border: 5px solid black;
  border-radius: 10px; */
  text-align: left;
  margin: 15px;
  padding: 15px;
}

img {
  width: 100%;
  border-radius: .5rem;
  margin-top: 1rem;
}

.unitNumber {
  color: #ff944d;
  font-size: 1.5rem;
  font-weight: 500;
}

.locationName {
  color: black;
  font-size: 2.5rem;
  font-weight: 700;
}

.auctionDetails {
  margin: 20px;
  background-color: rgb(238, 238, 238);
  box-shadow: 5px 5px 5px rgb(209, 209, 209);
  border-radius: 5px;
  height:fit-content;
  padding: 10px;
  font-weight: 500;
}

.highBid {
  margin-left: 20px;
  color: #ff944d;
  font-size: 2.5rem;
  font-weight: 500;

}
</style>
