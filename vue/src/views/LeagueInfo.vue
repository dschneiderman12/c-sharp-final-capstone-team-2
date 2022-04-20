<template>

  <div id=leaguePage>

    <div>
      <div id = "leagueHead">
      <h1 id = "leagueTitle">{{ league.leagueName }}</h1>
    </div>

    <div id="league-info">
    <div>
      <h2 id="course">
        Course:
      <router-link :to="{path: '/course/'+league.leagueCourse.courseId} " text-decoration="none">{{ league.leagueCourse.courseName }}</router-link>
      </h2>
      </div>

      <div id="organ">
      <h2 id ="organizerName">Organizer: {{ league.organizerName }}</h2>
      </div>
      <!-- <h3>
  {{userlist}}
</h3>      this is a list of users in this league- we can use it to choose a user to setr-->
    </div>
    <league-scores />


</div>

    <invite-form v-if="league.organizerId === this.$store.state.user.userId" />
    <match-form v-if="league.organizerId === this.$store.state.user.userId" />
    <league-matches />
    <!-- ADD MATCH LIST COMPONENT -->
  </div>
</template>

<script>
import LeagueService from "../services/LeagueService.js";
import InviteForm from "../components/InviteForm.vue";
//import MatchScore from "../components/MatchScore.vue";
import MatchForm from "../components/MatchForm.vue";
import LeagueMatches from "../components/LeagueMatchList.vue";
import LeagueScores from "../components/LeagueScores.vue"

export default {
  components: { InviteForm, MatchForm, LeagueMatches, LeagueScores },
  data() {
    return {
      league: {
        leagueName: "",
        organizerId: "",
        leagueCourse: {
          courseName: "",
          courseId: ""
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
/* #league-title > h1 {
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
} */

#page-body > div:nth-child(1) {
  background-color: rgba(209, 255, 209, 0.5);
  border-width: 3px; 
  border-radius: 6px;
  padding: 5px;
  /* margin: 30px; */
  width: 80%;
  filter: drop-shadow(5px 5px 5px black);
  display: flex;
  margin-top: 20px;
  margin-bottom: 20px;
  flex-direction: column;
}
#leagueTitle{
display: flex;
justify-content: center;
background: #FAD586;
padding: 2px;
filter: drop-shadow(2px 2px 2px black);
border-bottom: #22577A 3px solid;
border-top: #22577A 3px solid;
text-transform: capitalize;
color:#22577A;
font-variant: small-caps;
font-family:Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;


}
#league-info{
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  text-shadow: none;
  margin: 0;
 
}

  #course{
    margin: 0;
    font-size: large;
    text-transform: capitalize;
  }
  #organizerName{
    margin-top:0;
    font-size:large;
    text-transform: capitalize;
  }
  #course > a{
    color:#1d3d52;
  }
#course > a:hover{
  color: #FAD586;
}
#leaguePage > div:nth-child(1){
  
}
</style>

