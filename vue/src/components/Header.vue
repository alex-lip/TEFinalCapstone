<template>
  <!-- <div>
    <router-link class="nav-item" v-bind:to="{ name: 'home' }">
      <i class="fas fa-home"></i>
      <div id="home-icon">
        Unit Storage Auctions
      </div>
    </router-link>
    <div id="nav">
      <router-link class="nav-item" v-bind:to="{ name: 'units' }">
        Available Units
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'register' }"
        v-if="!$store.state.token"
        >&nbsp;|&nbsp;Register</router-link
      >
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'login' }"
        v-if="!$store.state.token"
      >
        &nbsp;|&nbsp;Login
      </router-link>
      <router-link
        class="nav-item"
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token"
      >
        &nbsp;|&nbsp;Logout
      </router-link>
    </div>
  </div> -->
  <nav class="navbar navbar-expand-lg navbar-dark bg-custom">

  <a class="navbar-brand" href="#" >
   <router-link class="nav-item" id="navbar-brand" v-bind:to="{ name: 'home' }">
     Self Storage Auctions
   </router-link></a>

  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavAltMarkup" aria-controls="navbarNavAltMarkup" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
    <div class="navbar-nav">
      <a class="nav-item nav-link" href="#">
        <router-link class="nav-item" v-bind:to="{ name: 'home' }"> <!--<i class="fas fa-home"></i> -->
      <!-- This is a font awesome icon -->
      Home
    </router-link></a>

      <a class="nav-item nav-link" href="#">
        <router-link class="nav-item" v-bind:to="{ name: 'units' }">
        Available Units
      </router-link></a>

            <a class="nav-item nav-link" href="#">
        <router-link class="nav-item" v-bind:to="{ name: 'users-bids' }"> <!--TODO: Need to create link here for the list of users, with only this bids made by the logged in user filtered -->
        My Bidding History
      </router-link></a>

      <a class="nav-item nav-link" href="#">
        <router-link
      class="nav-item"
      v-bind:to="{ name: 'login' }"
      v-if="!$store.state.token">
      Login
    </router-link></a>
      
      <a class="nav-item nav-link" href="#">
      <router-link class="nav-item" v-bind:to="{ name: 'register' }" v-if="!$store.state.token">
      Register </router-link></a>
    </div>
  </div>
    
    <a class="nav-item nav-link" href="#">
      <router-link
      class="nav-item"
      v-bind:to="{ name: 'logout' }"
      v-if="$store.state.token">
      Logout
    </router-link></a>
    

    

    <!-- <router-link
      class="nav-item"
      v-bind:to="{ name: 'register' }"
      v-if="!$store.state.token">
      Register
      </router-link> -->

    

    
   
  </nav>

</template>

<script>
export default {
  name: "Header",
};
</script>

<style>
/* #home-icon {
  font-weight: 800;
  font-size: 27px;
  background-color: #FFFCFF;
  color: #FF9505;

  text-align: left;
  padding-left: 1rem;
} */
  #navbar-brand  {
    color: black;
    font-size: 1.5em;
    font-weight: 600;
  }

  #navbar-brand:hover {
    color: white;
    text-decoration: none;
  }


  .nav-item {
    font-size: 1.2em;
    color: white;
  }

  .nav-item:hover {
    color: black;
  }

  .bg-custom {
    background-color: #ff944d;
    background: linear-gradient(60deg, rgb(245, 104, 10) 28%, rgb(255, 197, 90) 100%);

    /* background-color: #ff944d; */
  }

</style>
