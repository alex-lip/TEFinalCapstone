<!--TODO: Need to see if this page is even needed. Ask about suggested protocal for emailing the winner-->
<template>
  <div class="container-sm">
    <h1>Admin View: Send email to auction winner</h1>
    <form @submit.prevent="sendEmail">
      <div>
        <div class="form-row">
          <div class="col">
            <textarea class="form-control" placeholder="Next steps for pickup" v-model="message.messageBody">
            </textarea>
          </div>
        </div>
        <button type="submit" class="btn btn-primary email">Send Email</button>
      </div>
    </form>

  </div>

  
</template>

<script>
import unitService from "../services/UnitService";

export default {
  name: "contact-winner",
  //props: ["id"],
  data() {
    return {
      message: {
        messageBody: '',
      },
      id: this.$route.params.id,
    };
  },
  methods: {
  sendEmail() {
      unitService
        .sendWinnerEmail(this.$route.params.id, this.message.messageBody)
        .then((response) => {
          if (response.status == 200) {
          this.$router.push({name: 'home',});
          }})
        .catch(() => {
          console.log("ERROR")
        })
    }
  }
};
</script>

<style scoped>
.container-sm {
  background-color: rgb(238, 238, 238);
  box-shadow: 5px 5px 5px rgb(209, 209, 209);
  margin-top: 15px;
}

.form-row {
  padding: 10px;
}

.email {
  margin: 10px;
}
</style>
