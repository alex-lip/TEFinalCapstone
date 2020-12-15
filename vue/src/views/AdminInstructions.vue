<template>
  <div class="home">
    <h1>Welcome to Self Storage Auctions</h1>
    <p />
    <p />
    <h2 v-show="userRole == 'admin'">For Admins</h2>
    <h3 v-show="userRole == 'admin'">
      Click on Available Units in the header to see the complete list of units
      available for auction
    </h3>
    <h3 v-show="userRole == 'admin'">
      From this same page, you can the appropriate buttons to view all bids from
      all users or add units for auction
    </h3>
        <h4 v-show="userRole == 'admin'">
            When adding a unit fill out the the form as needed, to fill in the picture of the unit:
        </h4>
            <ol>
                <li>Login to Imgur, create an account if you do not have one https://imgur.com/</li>
                <li>Click on the top left button marked New Post</li>
                <li>Click choose photo or video to upload the picture from your computer</li>
                <li>When the next screen with the image shows up, right click on the image and click Open In New Tab</li>
                <li>The newly opened tab will show on the image, copy the hyperlink from the address bar, or URL bar at the top of the screen</li>
                <li>Once the hyperlink is copied, paste it into the inventory bar in the add unit form</li>
            </ol>
    <h3 v-show="userRole == 'admin'">
      You can click on specific units to view their details, and if needed edit
      unit details with the edit unit button
    </h3>
        <h4>If you need to change the picture of the unit follow the directions provided above for the add unit form</h4>
    <h3 v-show="userRole == 'admin'">
      From the same page, you can also remove any unit from the auction list by
      clicking Delete Unit
    </h3>
    <h3 v-show="userRole == 'admin'">
      You can find the winning bid by viewing the bids table, click View All
      Bids in the units page
    </h3>
    <h3 v-show="userRole == 'admin'">
      Use the filter bars on the bids table to narrow the selection down to the
      top bid
    </h3>
    <h3 v-show="userRole == 'admin'">
      Once the top bid is found, click on the link attached to the username to
      send an email to the winner for next steps
    </h3>
  </div>
</template>

<script>
export default {
  name: "admin-instruction",

  data() {
    return {

      userRole: this.$store.state.user.role,
    }
  }

};
</script>
