<template>
  <div id="verification" class="text-center">
    <form class="form-verification" @submit.prevent="submitVerification">
      <h1 class="h3 mb-3 font-weight-normal">Create Account</h1>
      <div class="alert alert-danger" role="alert" v-if="verificationError">
        {{ verificationErrorMsg }}
      </div>
      <h1>Please enter the verification code: </h1>
      <input
        type="text"
        placeholder="123456"
        maxlength="6"
        v-model.number="verificationCode.code"
        required
      />
      <button>Submit</button>
    </form>
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
</style>