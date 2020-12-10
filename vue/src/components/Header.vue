<template>
  <div id="nav">
    <router-link class="nav-item" v-bind:to="{ name: 'home' }">
      <i class="fas fa-home"></i>
      <!-- This is a font awesome icon -->
      Home
    </router-link>
    <router-link class="nav-item" v-bind:to="{ name: 'units' }">
      &nbsp;|&nbsp;Available Units
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
</template>

<script>
export default {
  name: "Header",
};
</script>

<style></style>
