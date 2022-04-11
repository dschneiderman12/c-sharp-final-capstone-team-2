<template>
  <div id="app">
    <div id="nav">
      <router-link class="homeLink" v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;&nbsp;
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
#login{

 background-color:rgba(209, 255, 209, 0.8);
  border-radius: 5px;
  padding: 5px;
  width: 30%;
  margin: 5px;
 
  }
  
#nav{
  background-color:rgba( 0, 100, 0, 0.5);
  border-radius: 5px;
  padding: 5px;
  display: flex;
  justify-content: flex-end;
  margin: 5px;
}
#app{
  max-width: 100%;
  min-height: 100vh;
  background: url('images/golfCourse1.jpg') ;
background-size:cover;
}

</style>