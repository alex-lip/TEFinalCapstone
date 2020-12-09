<template>
    <div>
        <h1>Add Unit</h1>
        <form class="new-unit-form" v-on:submit.prevent="saveUnit">
        <h4>
            <input class="location-input" type="text" placeholder="Location" v-model="unit.locationName" required/>
        </h4>
        <h4>
            <input class="number-input" type="text" placeholder="Unit Number" v-model="unit.unitNumber" required/>
        </h4>
        <h4>
            <input class="size-input" type="text" placeholder="Unit Size" v-model="unit.unitSize" required/>
        </h4>
        <h4>
            <input class="pictures-input" type="text" placeholder="Unit Size" v-model="unit.unitSize" required/>
        </h4><!--TODO: update to download pictures from the computer drive-->
    <button>Save</button>
    </form>
    </div>
</template>

<script>
import UnitService from "../services/UnitService.js";

export default {
  props: {
    unit: Object, // This prop is hooked to 'u' in 'Units.vue'
  },
   data() {
        return {
            errorMessage: '',
            newUnit: {
                locationName: '',
                unitNumber: '',
                unitSize: '',
                pictures: '',
                notes: ''
            }
        }
    },
    methods: {
        saveUnit() {
            UnitService.create(this.unit)
                .then(response => {
                    const newUnit = response.data;
                    this.$store.commit('UNIT_ADDED', newUnit);
                    this.$router.push({name: 'UnitDetails', params: {unitId: newUnit.id}})
                })
                .catch(error => {
                    this.errorMessage = error.message;
                });
        }
    }
};
</script>

<style></style>


<!--  </form>

        <form @submit.prevent="saveUnit()" v-if="unit">
            <div class="form-group">
                <label for="locationName">Location Name</label>
                <input type="text" class="form-control" id="locationName" 
                       v-model="unit.locationName"
                       autocomplete="location"
                       required>
            </div>
            <div class="form-group">
                <label for="unitNumber">Unit Number</label>
                <input type="text" class="form-control" id="unitNumber" 
                       v-model="unit.unitNumber"
                       autocomplete="number"
                       required>
            </div>
            <div class="form-group">
                <label for="unitSize">Unit Size</label>
                <input type="text" class="form-control" id="unitSize" 
                       v-model="unit.unitSize"
                       autocomplete="size">
            </div>
            <div class="form-group">
                <label for="pictures">Inventory Pictures</label>
 
            </div>
            <div class="form-group">
                <label for="notes">Notes</label>
                <textarea class="form-control" 
                          id="notes" 
                          v-model="unit.notes" />
            </div>
            <button type="submit" class="btn btn-success">Create</button>
        </form>-->