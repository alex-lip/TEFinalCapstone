<template>
<div class="container-fluid vh-100">
  <div class="row align-items-start vh-100 overlay">
    <div class="col-md-1 .ml-md-auto">Column 1</div>
    <div class="col-md-5 .ml-md-auto" id="aboutContent">
      <h1>Best Place to Bid on Abandoned Self Storage Units</h1>
      <p>Bid on the contents of abandoned self storage units.</p>
      <p>Register today to participate in online auctions.</p>
      <p>Real time auctions.</p>
      <p>Same day local pickup.</p>
    </div>
    <div class="col-md-1 .ml-md-auto">Column 3</div>
  <div id="register" class="col text-center">
    <form class="form-register" @submit.prevent="register">
      <h1 class="h3 mb-3 font-weight-normal">Register</h1>
      <div class="alert alert-danger" role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
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
      <div class="form-group">
        <input
          type="password"
          id="confirmPassword"
          class="form-control"
          placeholder="Confirm Password"
          v-model="user.confirmPassword"
          required />
      </div>
      <div class="btnGroup">
      <button class="btn btn-custom" type="submit">
        Create Account
      </button>
      
        <router-link :to="{ name: 'login' }">
          <button class="btn btn-custom-outline">
          Have an account?
          </button>
          </router-link>
      
      
      </div>
    </form>
  </div>
  <div class="col-md-1 .ml-md-auto">Column 4</div>
  </div>
  </div>

</template>

<script>
import authService from '../services/AuthService';

export default {
  name: 'register',
  data() {
    return {
      user: {
        username: '',
        password: '',
        confirmPassword: '',
        role: 'user',
      },
      registrationErrors: false,
      registrationErrorMsg: 'There were problems registering this user.',
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = 'Password & Confirm Password do not match.';
      } else {
        this.$store.state.userVerification = this.user.username;
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                name: 'verification',
                //query: { registration: 'success' },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = 'Bad Request: Validation Errors';
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = 'There were problems registering this user.';
    },
  },
};
</script>

<style>

.container-fluid {
  background-image: url(https://images.unsplash.com/photo-1595050309250-3047a857b88d?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1987&q=80);
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  
  height: 100%;
  
}

.overlay {
    background: rgba(0, 0, 0, 0.8); /*can be anything, of course*/
    background-blend-mode: multiply;
    padding-top: 35px;
}

#aboutContent {
  text-align: center;
  background:rgb(47, 47, 47, 0.6);
  color: white;
  border-radius: 5px;
  padding: 1px;
  margin-top:80px;
}

#register {
  background:white;
  border-radius: 10px;
  padding: 15px;
  margin-top:80px;
}

.btnGroup {
  padding: 5px;
}

h1 {
  font-size: 2.5em;
}

p {
  font-size: 1.5em;
  text-align: left;
  padding-left: 20px;
}
</style>


