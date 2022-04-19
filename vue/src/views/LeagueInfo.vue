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
    <match-score v-if="league.organizerId === this.$store.state.user.userId" />
  </div>
</template>

<script>

import LeagueService from "../services/LeagueService.js";
import InviteForm from "../components/InviteForm.vue";
import MatchScore from "../components/MatchScore.vue";

export default {
  components: { InviteForm, MatchScore ,},
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
#league-title > h1 {
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
#league-info > h3, 
#page-body > div:nth-child(1) > div:nth-child(4) > form > h3,
#page-body > div:nth-child(1) > div:nth-child(5) > form > div:nth-child(1) > label,
#page-body > div:nth-child(1) > div:nth-child(5) > form > div:nth-child(2) > label {
 width:35%;
  background-color: rgb(24, 77, 71);
  margin-top: 5px;
  margin-bottom: 5px;
  color: white;
  padding-left: 5px;
  border-radius: 3px;
  font-weight: bold;
  text-shadow: black 5px 5px 5px;
  filter: drop-shadow(3px 3px 3px black);
}
#user-list,
#page-body > div:nth-child(1) > div:nth-child(5) > form > div:nth-child(1) > select,
#page-body > div:nth-child(1) > div:nth-child(5) > form > div:nth-child(2) > select,
#page-body > div:nth-child(1) > div:nth-child(5) > form > div:nth-child(3) {
 filter: drop-shadow(3px 3px 3px black);
  text-shadow: rgb(90, 87, 87) 3px 3px 3px;
}
</style>

