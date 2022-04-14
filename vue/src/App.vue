<template>
  <div id="app">
    <div id="nav">
      <div id="left-header">
        <img src="@/images/golfLogo.png" alt="templogo" />
        "stuff about golf and stuff"
      </div>
      <div class="nav-link">
        <router-link class="homeLink" v-bind:to="{ name: 'home' }"
          >Home</router-link
        >&nbsp;&nbsp;
        <router-link
          v-bind:to="{ name: 'logout' }"
          v-if="$store.state.token != ''"
          >Logout</router-link
        >
      </div>
    </div>
    <router-view />
    <div id="map">
      <course-locator />
    </div>
  </div>
</template>

<script>
import CourseLocator from "./components/CourseLocator.vue";

export default {
  name: "Map",
  components: {
    CourseLocator,
  },
};
</script>


<style scoped>
* {
  font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande",
    "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
}

#login,
#register {
  background-color: rgba(209, 255, 209, 0.7);
  border-color: rgb(43, 126, 43);
  border-style: solid;
  border-width: 3px;
  border-radius: 7px;
  padding: 5px;
  margin: 5px;
  width: 30%;
  filter: drop-shadow(5px 5px 5px black);
}

#nav > div > img {
  width: 10vh;
  /* margin-right: 80%; */
}
#nav {
  /* this selects the top bar (logo, navigation buttons) */
  background-color: rgba(0, 100, 0, 0.5);
  /* border-radius: 7px;*/
  padding: 5px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
}

#app {
  max-width: 100%;
  min-height: 100vh;
  background-blend-mode: overlay;
  background: url("images/golfCourse1.jpg"),
    linear-gradient(to bottom, #a1cc79, #9d5fb6);
  background-size: cover;
}
#left-header {
  color: white;
}

#nav > div > a {
  /* this selects all of the navigation links */
  filter: drop-shadow(3px 3px 3px black);
  background-color: green;
  text-decoration: none;
  font-weight: bold;
  text-shadow: darkslateblue 5px 5px 5px;
  color: white;
  font-size: x-large;
  /* -webkit-text-stroke-width: 1px;
  -webkit-text-stroke-color: rgb(0, 0, 0); */

  margin-right: 5px;
  padding: 10px;
  border-radius: 8px;
}

#map {
  /*map component contained within this div*/
}
</style>