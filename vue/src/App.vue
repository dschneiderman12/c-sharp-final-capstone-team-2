<template>
  <div id="app">
    <div id="nav">
      <router-link class="homeLink" v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'logout' }" v-if="$store.state.token != ''">Logout</router-link>
    </div>
    <router-view />
  </div>
</template>
<style scoped>
.homeLink{
  text-decoration: none;
  color: white;
  -webkit-text-stroke-width: 0.3px;
  -webkit-text-stroke-color:rgb(0, 0, 0);
  
}
#nav{
  background-color:rgba( 0, 100, 0, 0.5);
  border-radius: 25px;
  padding: 5px;
  text-align: center;
}
#app{
  
  min-height: 100vh;
  background: url('images/golfCourse1.jpg') ;
}
</style>