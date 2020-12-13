<template>
<div class="container-fluid ">
  <div class="row align-items-start overlay">
    <div class="col-md-1 .ml-md-auto"></div>
    <div class="col-md-5 .ml-md-auto" id="aboutContent">
      <h1>Bid on Abandoned Self Storage Units</h1>
      <p class="headerCopy">Bid on the contents of abandoned self storage units.
      Register today to participate in online auctions.
      Real time auctions. Same day local pickup.</p>
    </div>
    <div class="col-md-1 .ml-md-auto"></div>
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
  <div class="col-md-1 .ml-md-auto"></div>
  </div>
<div class="container features">
    <!-- Example row of columns -->
    <div class="row">
      <div class="col-md-4">
      <span class="icons">
        <i class="fas fa-clock"></i>
      </span>
        <h3>Real Time Bidding</h3>
      <p class="featureCopy">Never lose at the last minute. Watch bids as they are placed.</p></div>
      <div class="col-md-4">
        <span class="icons">
        <i class="fas fa-truck"></i>
        </span>
      <h3>Same Day Pickup</h3>
      <p class="featureCopy">Get your winnings the same day. Pick up at our central Ohio locations.</p></div>
      <div class="col-md-4">
        <span class="icons">
        <i class="fas fa-list-ol"></i>
        </span>
      <h3>Monitor Your Auctions</h3>
      <p class="featureCopy">Keep track of your bids on multiple auctions in real time.</p></div>
    </div>
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
  /*background-image: url(https://images.unsplash.com/photo-1595050309250-3047a857b88d?ixid=MXwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=1987&q=80);
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover; */
  
  height: 100%;
  
  
}

.overlay {
    /*background: rgba(0, 0, 0, 0.8); 
    background-blend-mode: multiply;
    padding-top: 35px; */
  
  background-position-y: 20%;
  background: linear-gradient(60deg, rgb(245, 104, 10) 28%, rgb(253, 227, 177) 100%);
}

#aboutContent {
  text-align: center;
  color: white;
  border-radius: 5px;
  padding: 1px;
  margin-top:50px;
  margin-bottom:25px;
}

#register {
  background: (0,0,0,0.5);
  border-radius: 10px;
  padding: 15px;
  margin-top:50px;
  margin-bottom:25px;
}

.btnGroup {
  padding: 5px;
}

h1 {
  font-size: 4.0rem;
  font-weight: 500;
}

.icons {
  color: #ff944d;
  font-size: 3.0rem;
}

.features {
  padding-top: 30px;
  text-align: left;
  margin-top: 20px;
  margin-bottom: 40px;
}

.headerCopy  {
  font-size: 1.5rem;
  font-weight: 200;
  text-align: left;
  padding-left: 20px;
}
</style>


