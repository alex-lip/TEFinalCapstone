<template>
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
  #navbar-brand  {
    color: black;
    font-size: 2.0em;
    font-weight: 600;
  }

  .nav-item {
    font-size: 1.2em;
    color: white;
  }

  .bg-custom {
    background-color: #ff944d;
  }

</style>
