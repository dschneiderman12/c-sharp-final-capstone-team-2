<template>
<div>
    <tee-assignment-form/>
    <match-form/>
</div>    
</template>

<script>
import LeagueService from "../services/LeagueService.js";
import TeeAssignmentForm from "../components/TeeAssignmentForm.vue";
import MatchForm from "../components/MatchForm.vue"
export default {
  components: { TeeAssignmentForm, MatchForm},
  data(){ return {
      league: {
        leagueName: "",
        organizerId: "",
        leagueCourse: {
          courseName: "",
        },
        organizerName: "",
      
      },
        errorMsg:"",
      };

  },created() {
    LeagueService.getCurrentLeague(this.$route.params.id)
      .then((response) => {
        this.league = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "gettingcurrentleague"); 
      });
  
    
                        //need to make this take in current league :(
    LeagueService.getUsersByLeague(2)
  .then((response) => {
        this.userlist = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "getusersbyleague");
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
