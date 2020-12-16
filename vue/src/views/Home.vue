<template>
<div class="container-fluid">
  <div class="row align-items-start overlay filter">
    <div class="col-md-1 .ml-md-auto"></div>
    <div class="col-md-5 .ml-md-auto" id="aboutContent">
      <h1>Welcome to Self-Storage Auctions</h1>
      <p class="headerCopy">Click on the button to the right to learn how to navigate the website, or click on the header tabs to get started.</p>
    </div>
    <div class="col-md-1 .ml-md-auto"></div>
      <div class="btnGroup">
      <router-link :to="{ name: 'users-instruction' }">
      <button class="btn btn-custom-register" type="submit">
        User Website Instructions
      </button>
      </router-link>
      <p/>      
        <router-link :to="{ name: 'admin-instruction' }">
          <button class="btn btn-custom-outline" v-show="userRole == 'admin'">
          Admin Website Instructions
          </button>
          </router-link>
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

export default {
  name: 'home',
  data() {
    return {
      userRole: this.$store.state.user.role,
    };
  },
};
</script>

<style scoped>

.overlay {
  background-image:linear-gradient(to right,rgb(0, 0, 0,0.8) 0%,rgba(0, 0, 0, 0.63) 100%), url(https://www.argus-selfstorage.com/wp-content/uploads/2016/02/slider-selfstorage.jpg);
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
  background-position-y: 60%;
  padding-top: 35px;  
  background-blend-mode:darken;
    
  
  /* background-position-y: 20%;
  background: rgba(0, 0, 0, 0.8);
  background: linear-gradient(60deg, rgb(245, 104, 10) 28%, rgb(253, 227, 177) 100%); */
}


#aboutContent {
  text-align: center;
  color: white;
  border-radius: 5px;
  padding: 1px;
  margin-top:50px;
  margin-bottom:50px;
   
}

#register {
  border-radius: 10px;
  padding: 15px;
  margin-top:30px;
  margin-bottom:50px;
}

#register h1 {
  color: white;
  padding: 10px;
  font-size: 3.0rem;
  font-weight: 400;

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

.btn-custom-register {
  background: linear-gradient(110deg, rgb(248, 103, 6) 28%, rgb(255, 189, 68) 100%);
  color: white;
  font-weight: 600;
  font-size: 18px;
  margin: 3px;
}

.btn-custom-register:hover {
  background: linear-gradient(170deg, rgb(248, 103, 6) 0%, rgb(255, 189, 68) 100%);
  transform: translateY(2px);
}

.btn-custom-register:active {
  background: linear-gradient(170deg, rgb(248, 103, 6) 100%, rgb(255, 189, 68) 100%);
  box-shadow: 0 5px rgb(255, 160, 52);
  transform: translateY(4px);
}

</style>

