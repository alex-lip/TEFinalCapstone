<!-- Main Application Template. 
     Note that you have classes from bootstrap available to you.
     See https://getbootstrap.com/docs/4.5/getting-started/introduction/ for reference on bootstrap -->
<template>
  <!-- If you start to get random styling you don't like, remove "container" from this "app" div -->
  <div id="app">
    <div id="content-wrap">
      <Header />
      <router-view />
      <Footer />
    </div>
  </div>
</template>

<script>
import Header from "@/components/Header.vue";
import Footer from "@/components/Footer.vue";

export default {
  components: {
    Header,
    Footer,
  },
};
</script>

<!-- Application-Wide Styles go here. 
     Any valid CSS or SCSS is allowable here. See https://sass-lang.com/documentation/style-rules for info on SCSS -->
<style lang="scss">
#id {
  position: relative;
  min-height: 100vh;
}

#content-wrap {
  text-align: center;
  padding-bottom: 2.5rem; /* Footer Height */
}

#footer {
  background: #ff944d;
  position: absolute;
  bottom: 0;
  width: 100%;
  height: 2.5rem; /* Footer Height */
}

.btn-custom {
  background-color: #ff944d;
  color: white;
  font-weight: 600;
  font-size: 18px;
}

// #nav {
//   height: 2.5rem;
//   background: #ff944d;
//   color: black;
// }
</style>
