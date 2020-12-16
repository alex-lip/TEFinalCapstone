<template>
  <div class="container">
    <UnitCard v-bind:unit="unitDetails"> </UnitCard>

    <!-- TODO: Need to input some boolean check to verify the amount entered is 
    higher than the current high bid, and connect form to add bid to log and change 
    high bid value on the unit.
    -->
    <router-link
      :to="{ name: 'place-bid', params: { id: this.unitDetails.unitId } }"
    >
      <button class="btn btn-custom-units-bid">Place Bid</button>
    </router-link>
    <br>
    <router-link v-bind:to="{ name: 'units' }">
      <button class="btn btn-light">
        Return to List of Units
      </button>
    </router-link>

    <p />

    <router-link
      v-if="userRole == 'admin'"
      :to="{ name: 'edit-unit', params: { id: this.unitDetails.unitId } }"
    >
      <button class="btn btn-primary">Edit Unit</button>
    </router-link>

    <router-link
      v-if="userRole == 'admin'"
      :to="{ name: 'contactWinner', params: { id: this.unitDetails.unitId } }"
    >
    </router-link>

    <button class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">Email Winner</button>

    <button
      class="btn btn-primary"
      v-if="userRole == 'admin'"
      v-on:click.prevent="deleteUnit()"
    >
      Delete Unit
    </button>

    <button 
    class="btn btn-primary"
    v-if="userRole == 'admin'" v-on:click="userRole = !userRole">
      User View
    </button>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <form class="modal-content" @submit="sendEmail">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Send Email to Winner</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      
      <div class="modal-body">
        <div class="col emailContent" >
            <p class="emailBody">Winning Bid: ${{unitDetails.highBid}}</p>
            <p class="emailBody">Facility Name: {{unitDetails.locationName}}</p>
            <p class="emailBody">Pickup Address: {{unitDetails.facilityAddress}}</p>
            <p class="emailBody"> Unit Number: {{unitDetails.unitNumber}}</p>
            <p class="emailBody">Auction Number: {{unitDetails.unitId}}</p>
            <p class="emailBody">Unit Size: {{unitDetails.unitSize}}</p>
            <p class="emailBody">Auction End Time: {{unitDetails.auctionEnd}}</p>
            <textarea class="form-control" placeholder="Next steps for pickup"
            v-model="message.messageBody"></textarea>
            <p class="emailCc">*Admin will be cc'd on email</p>
        </div>
      </div>
      
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="submit" class="btn btn-primary">Send Email

          
        </button>
        
      </div>
      
    </form>
  </div>
</div>

  </div>
</template>

<script>
import unitService from "../services/UnitService";
import UnitCard from "../components/UnitCard";
import UnitService from '../services/UnitService';

export default {
  name: "unit-details",

  components: {
    UnitCard,
  },

  props: {
    unitId: Number,
  },

  data() {
    return {
      unitDetails: undefined,

      userRole: this.$store.state.user.role,

      message: {
        messageBody: '',
      }
    };
  },

  created() {
    // Populate 'unitDetails' data
    this.unitDetails = this.$store.state.units.find(
      (u) => u.unitId == this.$route.params.id
    );
  },

  computed: {},

  methods: {
    deleteUnit() {
      // use filter to grab from state
      const confirmed = confirm(
        "Are you sure you want to delete this unit? This cannot be undone"
      );

      if (confirmed) {
        unitService.deleteUnit(this.unitDetails.unitId).then((response) => {
          console.debug("Unit deleted", response);

          if (response.status === 204) {
            // Call out to our web service and have it make the delete
            // this.$store.commit("UNIT_DELETED", this.unit);
            this.$router.push({ name: "units" });
          }
        });
      }
    },
    AddNewBid() {
      //TODO: populate method to add to list of bids
    },
    sendEmail() {
      UnitService
        .sendWinnerEmail(this.unitDetails.unitId, this.message.messageBody)
        .then((response) => {
          if (response.status == 200) {
          this.$router.push({name: 'home',});
          }})
        .catch(() => {
          console.log("ERROR")
        })
    }
  },
};
</script>

<style>

.btn-primary {
  margin: 3px;
}
.btn-custom-units-bid {
  background: linear-gradient(110deg, rgb(248, 103, 6) 28%, rgb(255, 189, 68) 100%);
  color: white;
  font-weight: 600;
  font-size: 18px;
  margin: 4px;
  width: 400px;
  padding: 10px;
}

.btn-custom-units-bid:hover {
  transform: translateY(2px);
}

.btn-custom-units-outline:after {
  color: linear-gradient(110deg, rgb(248, 103, 6) 28%, rgb(255, 189, 68) 100%);
  background-color: white;
  font-weight: 600;
  font-size: 18px;
  margin: 4px;
}

.emailCc {
  font-size: 14px;
  text-align: right;
  padding-right: 20px;
}

.emailContent {
  text-align: left;
  padding: 10px;
  background-color: rgb(238, 238, 238);
  box-shadow: 5px 5px 5px rgb(209, 209, 209);
  border-radius: 5px;
}

.emailBody {
  font-size: 16px;
  font-weight: 500;
  margin: 5px;
}

/*
.btnPlaceBid {
  background-color: #3366ff;
  border: 3px solid white;
  border-radius: 12px;
  color: white;
  padding: 10px 25px;
  text-align: center;
  display: inline-block;
  font-size: 24px;
}
.btnNoBid {
  background-color: #3366ff;
  border: 3px solid white;
  border-radius: 12px;
  color: white;
  padding: 10px 25px;
  text-align: center;
  display: inline-block;
  font-size: 24px;
}
.btnSubmit {
  background-color: #3366ff;
  border: 3px solid white;
  border-radius: 12px;
  color: white;
  text-align: center;
  display: inline-block;
}
*/

</style>
