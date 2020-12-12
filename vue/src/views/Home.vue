<template>
  <div class="home">
    <h1>Welcome to Self Storage Auctions</h1>
    <p>Accept terms and conditions below to</p>
    <p>see the full of units up for auction</p>
    <p/>
    <p>
      <input type="checkbox" name="terms" v-on:click="checked = !checked">
      I accept the terms and conditions
    </p>
    <router-link v-bind:to="{ name: 'units' }">
    <button v-if=checked>I Accept</button>
    </router-link>
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
