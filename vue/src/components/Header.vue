<template>
  <div>
    <router-link class="nav-item" v-bind:to="{ name: 'home' }">
      <!--<i class="fas fa-home"></i>
      This is a font awesome icon-->
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
  </div>
</template>

<script>
export default {
  name: "Header",
};
</script>

<style>
#home-icon {
  font-weight: 800;
  font-size: 27px;
  background-color: #FFFCFF;
  color: #FF9505;

  text-align: left;
  padding-left: 1rem;
}
</style>
