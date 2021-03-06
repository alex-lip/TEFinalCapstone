import Vue from "vue";
import Router from "vue-router";
import Home from "../views/Home.vue";
import Login from "../views/Login.vue";
import Logout from "../views/Logout.vue";
import Register from "../views/Register.vue";
import store from "../store/index";

Vue.use(Router);

/**
 * The Vue Router is used to "direct" the browser to render a specific view component
 * inside of App.vue depending on the URL.
 *
 * It also is used to detect whether or not a route requires the user to have first authenticated.
 * If the user has not yet authenticated (and needs to) they are redirected to /login
 * If they have (or don't need to) they're allowed to go about their way.
 */

const router = new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "home",
      component: Home,
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false,
      },
    },
    {
      path: "/verification",
      name: "verification",
      component: () => import("../views/Verification.vue"),
    },
    {
      path: "/units",
      name: "units",
      component: () => import("../views/Units.vue"),
      // Does the user have to be logged in in order to see the available units?
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/usersguide",
      name: "users-instruction",
      component: () => import("../views/UserInstructions.vue"),
      // Does the user have to be logged in in order to see the available units?
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/adminguide",
      name: "admin-instruction",
      component: () => import("../views/AdminInstructions.vue"),
      // Does the user have to be logged in in order to see the available units?
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/allbids",
      name: "all-bids",
      component: () => import("../views/AllBids.vue"),
      // Does the user have to be logged in in order to see the available units?
      meta: {
        requiresAuth: true,
      },
    },
    
    {
      path: "/usersbids/:userId",
      name: "users-bids",
      component: () => import("../views/UsersBids.vue"),
      // Does the user have to be logged in in order to see the available units?
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/units/newunit",
      name: "add-unit",
      component: () => import("../views/AddUnit.vue"),
      meta: {
        requiresAuth: true,
      },
    },

    {
      path: "/units/:id/edit",
      name: "edit-unit",
      component: () => import("../views/EditUnit.vue"),
      meta: {
        requiresAuth: true,
      },
    },

    {
      path: "/units/:id/placebid",
      name: "place-bid",
      component: () => import("../views/PlaceBid.vue"),
      meta: {
        requiresAuth: true,
      },
    },

    {
      path: "/units/:id",
      name: "unit-details",
      component: () => import("../views/UnitDetails.vue"),
      // Does the user have to be logged in in order to see the available units?
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/bids/email/:username",
      name: "contact-winner",
      component: () => import("../views/ContactWinner.vue"),
      // Does the user have to be logged in in order to see the available units?
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "*",
      redirect: "/",
    },
    {
      path: "/terms",
      name: "terms",
      component: () => import("../views/Terms.vue"),
    },
    // {
    //   path: "/contactWinner/",
    //   name: "contactWinner",
    //   component: () => import("../views/ContactWinner.vue"),
    // },
  ],
});

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some((x) => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === "") {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
