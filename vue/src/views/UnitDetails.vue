<template>
  <div>
      <h3>{{unitDetails.unitNumber}}</h3>
      <h3>{{unitDetails.unitSize}}</h3>
      <h3>{{unitDetails.locationName}}</h3>
  </div>
</template>

<script>
export default {
name: 'unit-details',
data(){
    return{
        unitDetails: undefined,
    };
},
created(){
    this.unitDetails = this.$store.state.units.find(u => u.id == this.$route.params.id);
    if(!this.unitDetails){
        this.unitDetails = this.$store.state.units.find(u => u.id == this.$route.params.id);
    }
 },
   methods: {
    deleteUnit(id){
      const confirmed = confirm(
        "Are you sure you want to delete this unit? This cannot be undone"
      );

      if (confirmed) {
        unitService
            .deleteUnit(id)
            .then((response) => {
              console.debug('Unit deleted', response);

              if(response.status === 200){
               //Call out to our web service and have it make the delete
               this.$store.commit("UNIT_DELETED", this.unit);
               this.$router.push({ name: "Units" });
              }
        });
      }
    },
}
</script>

<style>

</style>