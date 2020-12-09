<template>
<div>
  <h1>Please enter your code</h1>
  <input type="text" placeholder="123456" maxlength="6"  v-model="verificationCode.code" required>
  <button>Submit</button>
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
    methods: {
      verify() {
        AuthService
          .verify(this.verificationCode.code)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                name: 'login',
              });
            }
          });
      }
    }
    }
    }
}

</script>

<style>

</style>