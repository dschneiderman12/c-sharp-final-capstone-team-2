<template>
  <div id="matchInformation">
    <div id ="match_title">
      <h2 v-on:created="populateLeague()" id="matchTitle"> {{ match.matchName }}</h2>
    </div>
    <button v-on:click="backButton()">Back</button>
    <div id="matchScores">
      <match-score-list />
    </div>
    
    <div id="teeTime">
      <tee-assignment-form
        v-if="league.organizerId === $store.state.user.userId"
      />
    </div>
    <div id="updatescores">
      <match-score v-if="league.organizerId === $store.state.user.userId" />
    </div>
  </div>
</template>

<script>
import LeagueService from "../services/LeagueService.js";
import MatchService from "../services/MatchService.js";
import TeeAssignmentForm from "../components/TeeAssignmentForm.vue";
import MatchScore from "../components/MatchScore.vue";
import MatchScoreList from "../components/MatchScoreList.vue";

export default {
  components: { TeeAssignmentForm, MatchScore, MatchScoreList },
  data() {
    return {
      match: {
        matchId: "",
        matchName: "",
        leagueId: "",
        leagueName: "",
        StartTime: "",
      },
      league: {
        leagueId: "",
        organizerId: "",
      },
      errorMsg: "",
      clicker: "",
    };
  },
  created() {
    MatchService.getMatch(this.$route.params.id)
      .then((response) => {
        this.match = response.data;
        LeagueService.getCurrentLeague(this.match.leagueId)
          .then((response) => {
            this.league = response.data;
          })
          .catch((error) => {
            this.handleErrorResponse(error, "getting current league");
          });
      })
      .catch((error) => {
        this.handleErrorResponse(error, "getting current league");
      });
  },
  methods: {
    backButton(){
      this.$router.push(`/league/${this.league.leagueId}`)
    },
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          "  Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg = "Error " + verb + "  Server could not be reached.";
      } else {
        this.errorMsg = "Error " + verb + "  Request could not be created.";
      }
      console.log(this.errorMsg);
    },
  },
};
</script>

<style scoped>
#matchScores{
  background: tan;
  margin: 10px;
  border-radius: 10px;
    padding-left:5px;
  padding-right:5px;
}
#match_title{
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
#teeTime{
  background: tan;
  margin: 10px;
  border-radius: 10px;
  padding-left:5px;
  padding-right:5px;
}
#updatescores{
   background: tan;
  margin: 10px;
  border-radius: 10px;
  padding-left: 5px;
  padding-right:5px;
}
#matchTitle{

  margin:0px;
}

</style>
