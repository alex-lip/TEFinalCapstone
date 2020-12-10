<template>
    <div>
        <h1>Add Unit</h1>
        <form @submit.prevent="saveUnit()">
            <div class="form-group">
                <label for="locationName">Location Name</label>
                <input type="text" class="form-control" id="locationName" 
                       v-model="newUnit.locationName"
                       autocomplete="location"
                       required>
            </div>
            <div class="form-group">
                <label for="unitNumber">Unit Number</label>
                <input type="text" class="form-control" id="unitNumber" 
                       v-model="newUnit.unitNumber"
                       autocomplete="number"
                       required>
            </div>
            <div class="form-group">
                <label for="unitSize">Unit Size</label>
                <input type="text" class="form-control" id="unitSize" 
                       v-model="newUnit.unitSize"
                       autocomplete="size">
            </div>
            <div class="form-group">
                <label for="pictures">Inventory Pictures</label>
 
            </div>
            <!--<div class="form-group">
                <label for="notes">Notes</label>
                <textarea class="form-control" 
                          id="notes" 
                          v-model="unit.notes" />
            </div>-->
            <button type="submit" class="btn btn-success">Create</button>
        </form>
    </div>
</template>

<script>
import UnitService from "../services/UnitService.js";

export default {
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
            UnitService.createNewUnit(this.unit)
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

        -->