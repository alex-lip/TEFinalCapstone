<template>
  <div id="login" class="container">
  
    <form class="form-signin" @submit.prevent="login">
      <h1 id = title>Welcome to Self Storage Auctions</h1>
      <h2 id="loginform" class="h3 mb-3 font-weight-normal">Please Sign In</h2>
      <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
        Invalid username and password!
      </div>

      <div class="alert alert-danger" role="alert" v-if="networkError">
        Network error!
      </div>

      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration">
        Thank you for registering, please sign in.
      </div>
      <div class="form-group">
        <input
          type="email"
          id="username"
          class="form-control"
          placeholder="email@address.com"
          v-model="user.username"
          required
          autofocus />
      </div>
      <div class="form-group">
        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required />
      </div>
      <div class="form-check">
        <input class="form-check-input" type="checkbox" value="" id="defaultCheck1" required>
          <label class="form-check-label" for="defaultCheck1">
            <router-link :to="{name: 'terms'}">
            I agree to the Terms & Conditions
            </router-link>
          </label>
      </div>
      <div class="form-group">
        <router-link :to="{ name: 'register' }">Need an account?</router-link>
      </div>
      <button class="btn btn-primary" type="submit">Sign in</button>
    </form>
    <img src="storageunits.jpg">
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
      networkError: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push({ name: "home" });
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response == null || response.status === 500) {
            this.networkError = true;
          }

          else if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>
<style>




/* body {
  font-family: system-ui;
  background: #ff944d;
  color: black;
  text-align: center;
}

#loginform{
  padding-top: 50px;
  padding-bottom: 10px;
}

#title{
  display: block;
  width: 50%;
  margin: auto;
  text-align: center;
  background-color: white;
}

img{
  width: 100%;
  height: 30%;
  padding: 10px;
} */
</style>