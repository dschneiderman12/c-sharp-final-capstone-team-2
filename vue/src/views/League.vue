<template>
    <div>
        <league-form />
        </div>
</template>

<script>
import LeagueForm from '../components/LeagueForm.vue';
export default {
components: { LeagueForm },
  name: "home"
}
</script>

<style>
#league-div {
  display: flex;
  flex-direction: column;
  padding: 10px;
}
#league-list {
  display: flex;
  flex-direction: column;
  padding: 5px;
  justify-content: center;
}
#league-list > a {
  text-decoration: none;
  background-color: #184D47;
  border-radius: 40px;
  text-shadow: black 5px 5px 5px;
  color: white;
  padding: 4px;
  display: flex;
  justify-content: center;
  filter: drop-shadow(3px 3px 3px black);
}
</style>