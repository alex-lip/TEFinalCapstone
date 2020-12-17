<template>
  <div class="container-sm">
    <h1>Welcome to Self Storage Auctions</h1>
    <h2>Please review the directions below on how view units and place bids</h2>
    <p />
    <p />
    <h2>For Users</h2>
    <h3>
      Click on Available Units in the header to see the complete list of units
      available for auction
    </h3>
    <h3>
      Click the details button to see more information the respective unit, such
      as inventory pictures
    </h3>
    <h3>
      From that page, you can place a bid. Once you have placed a bid it will
      show up in your bids table
    </h3>
    <h3>
      To see the full list of all your bids made, click on My Bidding History in
      the header.
    </h3>
    <h3>
      This table will show your bids as well as the respective unit's current
      highest bid and date and time the auction ends
    </h3>
    <h3>
      Use this table to see if another bid needs to be made, or if there is time
      left to do so
    </h3>
    <h3>
      If you are the highest bidder for a unit at the time the auction ends, you
      will be notified by email about next steps
    </h3>
  </div>
</template>

<script>
export default {
  name: "user-instruction",

  data() {
    return {

    }
  }

};
</script scoped>

<style scoped>
*{
  text-align: left;
}

h3 {
  font-size: 20px;
  padding: 10px;
}
</style>