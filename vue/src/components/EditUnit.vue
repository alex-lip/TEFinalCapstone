<template>
  <div>
    This is how admins will edit unit information
    <p>It will look just like a add unit form but filled out</p>
  </div>
</template>

<script>
export default {
  props: {
    unit: Object, // This prop is hooked to 'u' in 'Units.vue'
  },
  data() {
        return {
            unit: null,
            errorMessage: ''
        }
    },
    methods: {
        saveUnit() {
            UnitService.update(this.unit)
                .then(response => {
                    this.$store.commit('UNIT_UPDATED', response.data);
                    this.$router.push({name: 'UnitDetails', params: {id: response.data.id}});
                })
                .catch(error => {
                    this.errorMessage = error.message;
                });
        }
    },
    created() {
        const id = this.$route.params.studentId;
        UnitService.getUnit(id)
            .then(response => {
                this.student = response.data;
            })
            .catch(error => this.errorMessage = error.message);
    }
};
</script>

<style></style>
