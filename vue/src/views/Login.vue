<template>
  <div id="login" class="container loginContainer">
    <div class="row align-items-start">
    <div class="col-md-4"></div>
    <div class="col-md-4">
    <form class="form-signin" @submit.prevent="login">
      <h2 id="loginform" class="h3 mb-3 font-weight-normal">Sign in to Self Storage Auctions</h2>
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
      <div class="form-check agree">
        <input class="form-check-input" type="checkbox" value="" id="defaultCheck1" required>
          <label class="form-check-label" for="defaultCheck1">
            <router-link :to="{name: 'terms'}">
            I agree to the Terms & Conditions
            </router-link>
          </label>
      </div>
      
      <button class="btn btn-custom" type="submit">Sign in</button>
    </form>
    <div class="needAccount">
      <div class="form-group"> New to Self Storage Auctions?
        <router-link :to="{ name: 'register' }">Create an account</router-link>
      </div>
    </div>
    </div>
    <div class="col-md-4"></div>
    </div>
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

.form-signin {
  margin-top: 50px;
  background-color: rgb(238, 238, 238);
  padding: 15px;
  border-radius: 5px;
}

.needAccount {
  margin-top: 20px;
  background-color: rgb(238, 238, 238);
  padding: 15px;
  border-radius: 5px;
}

.agree {
  text-align: left;
  margin-left: 30px;
  margin-bottom: 15px;
}


</style>