<template>
  <div id="editunit">
    <EditUnit />
    You Made it to the EditUnit view.
  </div>
</template>

<script>
import EditUnit from "@/components/EditUnit.vue";

export default {
  name: "edit-unit",

  components: {
    EditUnit,
  },

  // props: {
  //   unitId: Number,
  // },
};
</script>

<style></style>
