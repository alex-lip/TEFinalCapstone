<!--TODO: Need to see if this page is even needed. Ask about suggested protocal for emailing the winner-->
<template>
    <div class="container-sm">
      <h1>Admin View: Send email to auction winner</h1>
      <form>
        <div>
        <div class="form-row">
          <div class="col">
            <input type="email" class="form-control" placeholder="Winner email" readonly>
          </div>
          <div class="col">
            <input type="number" class="form-control" placeholder="Winning Bid" readonly>
          </div>
          <div class="col">
            <input type="text" class="form-control" placeholder="End Date" readonly>
          </div>
        </div>

        <div class="form-row">
          <div class="col">
            <input type="number" class="form-control" placeholder="Auction ID" readonly>
          </div>
          <div class="col">
            <input type="text" class="form-control" placeholder="Facility Name" readonly>
          </div>
          <div class="col">
            <input type="text" class="form-control" placeholder="Address" readonly>
          </div>
          <div class="col">
            <input type="number" class="form-control" placeholder="Unit Number" readonly>
          </div>
        </div>

        <div class="form-row">
          <div class="col">
            <textarea class="form-control" placeholder="Next steps for pickup">
            </textarea>
          </div>
        </div>
        <button type="button" class="btn btn-primary email">Send Email</button>
      </div>
      </form>
  </div>
</template>

<script>
import unitService from "../services/UnitService";

export default {
  name: "contact-winner",
  props: ["unitId"],
  data() {
    return {
      unitDetails: undefined,
    };
  },

  
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
