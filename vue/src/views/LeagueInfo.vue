<template>
  <div>
    <div id="league-title">
      <h1>{{ league.leagueName }}</h1>
    </div>
    <div id="league-info">
      <h2>Course Name: {{ league.leagueCourse.courseName }}</h2>
      <h3>Organizer: {{ league.organizerName }}</h3>
    </div>
    <div id="scoreboard">
      <table>
        <tr>
          <td>Player Name</td>
          <td>Player Score</td>
        </tr>
        <tr>
          <td>Mario</td>
          <td>-50</td>
        </tr>
        <tr>
          <td>Mario</td>
          <td>50</td>
        </tr>
        <tr>
          <td>Mario</td>
          <td>-50</td>
        </tr>
      </table>
    </div>
    <!-- need invite form to show ONLY IF you are the organizer 
    Currently shows for everyone
    v-if league.organizerId = current user??
    Need to add something like that to the element-->
    <invite-form /> 
  </div>
</template>

<script>
import LeagueService from "../services/LeagueService.js";
import InviteForm from "../components/InviteForm.vue";
export default {
  components: { InviteForm },
  data() {
    return {
      league: {
        leagueName: "",
        leagueCourse: {
          courseName: "",
        },
        organizerName: "",
      },
    };
  },
  created() {
    LeagueService.getCurrentLeague(this.$route.params.id)
      .then((response) => {
        this.league = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating"); //need to add the method
      });
  },
};
</script>

<style>
#page-body > div:nth-child(1) {
  width: 90%;
}
</style>

