<template>
    <div>
        <h1>Add Unit</h1>

        <div class="alert alert-info" role="alert">Enter information about the new unit and click Create to continue</div>
        
        <div class="alert alert-danger" role="alert" v-if="errorMessage">{{errorMessage}}</div>

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
                <!-- not sure how to code this for multiple pictures
                <input type="img" class="form-control" id="pictures" 
                       v-model="student.phone"
                       autocomplete="tel">-->
            </div>
            <div class="form-group">
                <label for="notes">Notes</label>
                <textarea class="form-control" 
                          id="notes" 
                          v-model="unit.notes" />
            </div>
            <button type="submit" class="btn btn-success">Create</button>
        </form>
    </div>
</template>

<script>
export default {
  props: {
    unit: Object, // This prop is hooked to 'u' in 'Units.vue'
  },
   data() {
        return {
            errorMessage: '',
            unit: {
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
