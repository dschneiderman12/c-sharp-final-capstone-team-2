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
  padding: 20px;
 
}
div> #league-list {
  display: flex;
  flex-direction: column;
  padding: 5px;
  justify-content: center;
  width: 60vw;
 
}
#league-list > #league-names> a {
  text-decoration: none;
  background-color: rgb(24, 77, 71);
  border-radius: 40px;
  text-shadow: black 1px 1px 1px;
  color: rgb(226, 213, 184);;
  font-weight: bolder;
  padding: 4px;
  display: flex;
  justify-content: center;
  filter: drop-shadow(3px 3px 3px black);
  width:300px;

}
#league-list > #league-names> a:hover{
  background-color: rgb(58, 124, 117);
}
#league-names
{display: flex;
justify-content: center;}
</style>