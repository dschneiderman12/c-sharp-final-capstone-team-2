<template>
  <div class="home">
    <div id="league-info">
      <h1>My Leagues</h1>
      <div class="nav-link">
        <router-link class="leagueLink" v-bind:to="{ name: 'league' }"
          >New League</router-link
        >
        <!-- &nbsp;&nbsp; -->
      </div>
    </div>
    
    <league-list />
    <div id="invites">
      <h1>League Invitations</h1>
    </div>
    <invites-pending />
  </div>
</template>

<script>
import InvitesPending from "../components/InvitesPending.vue";
import LeagueList from "../components/LeagueList.vue";
export default {
  name: "home",
  components: { LeagueList, InvitesPending },
};
</script>
<style scoped>
#page-body > div.home {
  background-color: rgba(209, 255, 209, 0.5);
  /* border-color: rgb(43, 126, 43); */
  /* border-style: solid;
  border-width: 3px; */
  border-radius: 6px;
  padding: 5px;
  /* margin: 30px; */
  width: 60%;
  filter: drop-shadow(5px 5px 5px black);
  display: flex;
  margin-top: 20px;
  margin-bottom: 20px;
  flex-direction: column;
  /* justify-content: space-around; */
  align-items: center;
}
#league-info > h1,
h1 {
  filter: drop-shadow(3px 3px 3px black);
  background-color: #184d47;
  text-decoration: none;
  font-weight: bold;
  text-shadow: black 5px 5px 5px;
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
#league-info > div > a{
  margin-top: 3px;
  text-decoration: none;
background: oldlace;
border-radius: 40px;
padding:4px;
padding-top: 0;
padding-bottom: 0;
font-size: 75%;
color: rgb(122, 107, 73);
font-weight:bold;
border: 1px rgb(122, 107, 73) solid;
/* text-shadow:rgba(0, 0, 0, 0.2) 1px 1px 1px; */
}
#league-info > div > a:hover{
  background: #e6c87e;
}


</style>