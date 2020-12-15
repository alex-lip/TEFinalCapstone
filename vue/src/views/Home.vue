<template>
  <div class="home">
    <h1>Welcome to Self Storage Auctions</h1>
    <h2>Please review the directions below on how view units and place bids</h2>
    <p/>    
    <p/>
    <h2>For Users</h2>
    <h3>Click on Available Units in the header to see the complete list of units available for auction</h3>
    <h3>Click the details button to see more information the respective unit, such as inventory pictures</h3>
    <h3>From that page, you can place a bid. Once you have placed a bid it will show up in your bids table</h3>
    <h3>To see the full list of all your bids made, click on My Bidding History in the header.</h3>
    <h3>This table will show your bids as well as the respective unit's current highest bid and date and time the auction ends</h3>
    <h3>Use this table to see if another bid needs to be made, or if there is time left to do so</h3>
    <h3>If you are the highest bidder for a unit at the time the auction ends, you will be notified by email about next steps</h3>
    <p/>
    <p/>
    <h2 v-show="userRole == 'admin'">For Admins</h2>
    <h3 v-show="userRole == 'admin'">Click on Available Units in the header to see the complete list of units available for auction</h3>
    <h3 v-show="userRole == 'admin'">From this same page, you can the appropriate buttons to view all bids from all users or add units for auction</h3>
    <h3 v-show="userRole == 'admin'">You can click on specific units to view their details, and if needed edit unit details with the edit unit button</h3>
    <h3 v-show="userRole == 'admin'">From the same page, you can also remove any unit from the auction list by clicking Delete Unit</h3>
    <h3 v-show="userRole == 'admin'">You can find the winning bid by viewing the bids table, click View All Bids in the units page</h3>
    <h3 v-show="userRole == 'admin'">Use the filter bars on the bids table to narrow the selection down to the top bid</h3>
    <h3 v-show="userRole == 'admin'">Once the top bid is found, click on the link attached to the username to send an email to the winner for next steps</h3>
  </div>
</template>

<script>
export default {
  name: "home",

  data() {
    return {
      checked: false
    }
  }
};
</script>
