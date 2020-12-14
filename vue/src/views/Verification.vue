<template>
  <div id="verification" class="text-center">
    <div class="row align-items-start">
    <div class="col-md-4"></div>
    <div class="col-md-4">
    <form class="form-verification" @submit.prevent="submitVerification">
      <h2 ></h2>
      <div class="alert alert-danger" role="alert" v-if="verificationError">
        {{ verificationErrorMsg }}
      </div>
      <h2 class="h3 mb-3 font-weight-normal">Please enter the verification code</h2>
      <input
        type="text"
        class="inputVerify"
        placeholder="123456"
        maxlength="6"
        v-model.number="verificationCode.code"
        required
      />
      <br>
      <button class="btn btn-custom">Submit</button>
    </form>
    </div>
    <div class="col-md-4"></div>
  </div>
  </div>
</template>

<script>
import AuthService from '../services/AuthService'
export default {
    name: 'Verification',
    data() {
    return {
      verificationCode: {
        code: '',
      },
      // user: {
      //   username: '',
      //   password: '',
      //   confirmPassword: '',
      //   role: 'user',
      // },
      invalidCredentials: false,
      networkError: false,
        };
    },
    props: { usernameProp: String },
    methods: {
      submitVerification() { 
        AuthService
          .verification(this.$store.state.userVerification, this.verificationCode.code) //set this state to empty once verified
          .then((response) => {
            if (response.status == 200) {
              this.$router.push({name: 'login',}); // navigate to a different success page // alert if unsuccessful this.data.error
            }
          })
          .catch((error) => {
            const response = error.response;
            // typically these don't need status codes
            if (response == null || response.status == 500) {
              this.networkError = true;
            }

            else if (response.status === 401) {
              this.invalidCredentials = true;
            }
          });
      },
  },
}

</script>


<style>
.form-verification {
  margin-top: 50px;
  background-color: rgb(238, 238, 238);
  padding: 5px;
  border-radius: 5px;
}

.inputVerify {
  margin: 10px;
}

</style>