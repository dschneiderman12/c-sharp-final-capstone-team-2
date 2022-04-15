<template>
    <div>
        <league-form />
        <p>Does work?</p>
       <p class="course-name">{{ league.leagueName }}</p>
        </div>
</template>

<script>
import LeagueService from "../services/LeagueService.js";
export default {

  name: "League-List",
  data() {
    return {
      league: {
          leagueName: "",
          leagueCourse: "",
          courseName: "",
          organizerName: ""
      },
    };
  },
  created() {
    LeagueService.getCurrentLeague(this.$store.state.leagueId)
      .then((response) => {
        this.league = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating");
      });
}}

  
</script>

<style>

</style>

