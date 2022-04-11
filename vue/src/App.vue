<template>
  <div id="app">
    <div id="nav">
     
      <img src="@/images/golfLogo.png" alt="templogo" />

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
  </div>
</template>
<style scoped>
* {
  font-family: "Lucida Sans", "Lucida Sans Regular", "Lucida Grande",
    "Lucida Sans Unicode", Geneva, Verdana, sans-serif;
}
.homeLink {
  text-decoration: none;

  text-shadow: darkslateblue;
  color: white;
  font-size: x-large;
  -webkit-text-stroke-width: 0.3px;
  -webkit-text-stroke-color: rgb(0, 0, 0);
  background-color: green;
}
#login {
  background-color: rgba(209, 255, 209, 0.9);
  border-color: darkgreen;
  border-style: solid;
  border-width: 5px;
  border-radius: 7px;
  padding: 5px;
  margin: 5px;
  width: 30%;
}

#nav  > img
{
  max-width: 5%;
  margin-right: 85%;
}
#nav {
  /* height: 5vh; */
  background-color: rgba(0, 100, 0, 0.5);
  /* border-radius: 7px;
  padding: 5px; */
  
  display: flex;
  flex-direction: row;
 align-items: center;
  /* justify-content: flex-end; */
  
}
#app {
  max-width: 100%;
  min-height: 100vh;
  background: url("images/golfCourse1.jpg"),
   linear-gradient(to bottom, #efe8f5, #8845e0);
  background-size: cover;
}
#nav > div {
  
  /* display: flex;
  justify-content: flex-end; */
  /* width: 400px; */
  /* margin-left: 90%; */
}
router-link {
  background-color: green;
  height: 100px;
}
</style>