<template>

  <div id="app">
    

    <div>
    <div id="nav">
      <div id="left-header">
        <img src="@/images/wildcard.png" alt="" />
        
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
    <div id="page-body">
      <router-view />
      <div id="map">
        <course-locator />
      </div>
    </div>
    </div>
    <div id="footer"></div>
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



#nav > div > img {
  min-height: 150px;min-width:300px;
  width: 30vh;
  
  /* margin-right: 80%; */
}
#nav {
  /* this selects the top bar (logo, navigation buttons) */
  background: rgb(250,213,134);
background: linear-gradient(180deg, rgba(250,213,134,0.98) 0%, rgba(250,213,134,0.50) 80%, rgba(250,213,134,0.15) 90%, rgba(250,213,134,0) 95%);
  /* border-radius: 7px;*/
  padding: 5px;
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-between;
  padding: 10px;
  padding-bottom:10px;
}

#app {
  max-width: 100%;
  min-height: 100vh;
  background-blend-mode: overlay;
  background: url("images/golfCourse1.jpg"),
    linear-gradient(to bottom, #688884, #a79a7d);
  
  /* height: 500px; You must set a specified height */
  background-position: center; /* Center the image */
  background-repeat: no-repeat; /* Do not repeat the image */
  background-size: cover; /* Resize the background image to cover the entire container */

}
#left-header {
  color: #184d47;
  font-weight: bolder;
  width:10vw;
}

#nav > div > a {
  /* this selects all of the navigation links */
  filter: drop-shadow(3px 3px 3px black);
  background-color: #184d47;
  
  text-decoration: none;
  font-weight: bold;
  text-shadow: rgb(0, 0, 0) 5px 5px 5px;
  color: white;
  font-size: x-large;
  /* -webkit-text-stroke-width: 1px;
  -webkit-text-stroke-color: rgb(0, 0, 0); */

  margin-right: 5px;
  padding: 10px;
  padding-top:0;
  padding-bottom:0;
  border-radius: 8px;
}
#page-body {
  display: flex;
  flex-direction: column;
  /* row-gap: 20vh; */
  align-items: center;
  /* margin-top: 15vh; */
}
#map {
  /*map component contained within this div*/
  width: 65%;
  display: flex;
  flex-direction: column;
  align-items: center;
  
}
#app{
  display:flex;
flex-direction: column;
justify-content:space-between;

}

#footer{
 background: rgb(35,156,142);
background: linear-gradient(180deg, rgba(35,156,142,0) 0%, rgba(33,129,118,0.4654236694677871) 47%, rgba(20,68,62,0.6587009803921569) 100%);
height:10vh;

}

</style>