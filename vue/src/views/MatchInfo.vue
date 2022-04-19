<template>
<div>
    <div>
    <h2>Match Name: {{match.matchName}}</h2> 
    

    <tee-assignment-form/>
    </div>
</div>    
</template>

<script>
import LeagueService from "../services/LeagueService.js";
import MatchService from "../services/MatchService.js";
import TeeAssignmentForm from "../components/TeeAssignmentForm.vue";
export default {
  components: { TeeAssignmentForm },
  data(){ return {
      match: {
        matchId: "",
        matchName: "",
        leagueId: "",
        leagueName: "",
        StartTime: ""
      },
      league:{
        leagueId: "",
        organizerId: ""
      },
        errorMsg:"",
      };

  },created() {
    MatchService.getMatch(this.$route.params.id)
      .then((response) => {
        this.match = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "gettingcurrentleague"); 
      });
    LeagueService.getCurrentLeague(this.match.leagueId).
    then((response) => {
      this.league = response.data;
    })
    .catch((error) => {
        this.handleErrorResponse(error, "gettingcurrentleague"); 
      });
  },
    methods:{
      handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          "  Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg =
          "Error " + verb + "  Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + "  Request could not be created.";
      }
      console.log(this.errorMsg);
    },
    }
  
 };


</script>

<style scoped>

</style>
