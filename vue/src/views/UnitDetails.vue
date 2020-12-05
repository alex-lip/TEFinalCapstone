<template>
  <div>
      <h2>{{bookDetails.title}}</h2>
      <img v-if="bookDetails.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + bookDetails.isbn + '-M.jpg'"/>
      <h3>{{bookDetails.author}}</h3>
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
 }
}
</script>

<style>

</style>