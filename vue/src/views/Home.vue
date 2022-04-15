<template>
  <div class="home">
    <div id="league-info">
    <h1>My Leagues</h1>
    <div class="nav-link">
        <router-link class="leagueLink" v-bind:to="{ name: 'league' }"
          >Create League</router-link>
        <!-- &nbsp;&nbsp; -->
       
        
      </div>
      </div>
    
    <league-form />

    <league-list/>
  </div>
</template>

<script>

import LeagueList from '../components/LeagueList.vue';
export default {
  components: { LeagueList },
  name: "home"
};
</script>
<style scoped>

#pagebody > div.home{
  background-color: rgba(209, 255, 209, 0.5);
  /* border-color: rgb(43, 126, 43); */
  /* border-style: solid;
  border-width: 3px; */
  border-radius: 6px;
  padding: 5px;
  /* margin: 30px; */
  width: 60%;
  filter: drop-shadow(5px 5px 5px black);
  display:flex;
  margin-top: 20px;
  margin-bottom:20px;
  flex-direction: column;
  /* justify-content: space-around; */
  align-items: center;

}
#league-info > h1 {
  filter: drop-shadow(3px 3px 3px black);
  background-color: #184d47;
  text-decoration: none;
  font-weight: bold;
  text-shadow: darkslateblue 5px 5px 5px;
  color: white;
  font-size: x-large;
  display: flex;
  width: 100%;
  justify-content: center;
  margin-bottom: 3px;
}
#league-info {
  display: flex;
  flex-direction: column;
 justify-content: center;
 width: 80%;
}
#league-info > div {
  display: flex;
  justify-content: flex-end;
}

</style>