<template>
  <div>
    <div id="league-title">
      <h1>{{ league.leagueName }}</h1>
    </div> 


    <div id="league-info">
      <h2>Course Name: {{ league.leagueCourse.courseName }}</h2>
      <h3>Organizer: {{ league.organizerName }}</h3>
      
    
<!-- <h3>
  {{userlist}}
</h3>      this is a list of users in this league- we can use it to choose a user to setr-->

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
    <invite-form v-if="league.organizerId === this.$store.state.user.userId" />
    <match-form v-if="league.organizerId === this.$store.state.user.userId"/> 
    <!--need to move to matchInfo.vue-->
     <match-score v-if="league.organizerId === this.$store.state.user.userId" />
  </div>
</template>

<script>

import LeagueService from "../services/LeagueService.js";
import InviteForm from "../components/InviteForm.vue";
import MatchScore from "../components/MatchScore.vue";
import MatchForm from "../components/MatchForm.vue";

export default {
  components: { InviteForm, MatchScore ,MatchForm},
  data() {
    return {
      league: {
        leagueName: "",
        organizerId: "",
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
  
    
  
    LeagueService.getUsersByLeague(this.$route.params.id)
  .then((response) => {
        this.userlist = response.data;
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

