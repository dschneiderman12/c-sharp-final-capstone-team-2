<template>
  <div class="home">
    <h1>My Leagues</h1>
    <p>You must be authenticated to see this</p>
    <league-form />
    <league-list/>
  </div>
</template>

<script>
import LeagueForm from '../components/LeagueForm.vue';
import LeagueList from '../components/LeagueList.vue';
export default {
  components: { LeagueForm, LeagueList },
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
  width: 40%;
  filter: drop-shadow(5px 5px 5px black);
  display:flex;
  margin-top: 20px;
  margin-bottom:20px;
  flex-direction: column;
  justify-content: space-around;
}
</style>