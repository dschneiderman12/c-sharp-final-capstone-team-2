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
      };

  },created() {
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

<style scoped>

</style>
