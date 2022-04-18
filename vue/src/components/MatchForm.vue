<template>
    <div>
        <form v-on:submit.prevent="submitForm()">
            <div></div>


        </form>
    </div>
</template>
<script>
import MatchService from "../services/MatchService"
import LeagueService from "../services/LeagueService"
export default {
    data() {
            return{
                match:{
                    matchId:"",
                    matchName:"",
                    startTime:""


                },
                matches: [],
                usersInLeague: [],

            };

    },
    created(){
        MatchService.getMatches()
          .then((response) => {
        this.courses = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "generating courses for");
      });
        LeagueService.getCourses()
      .then((response) => {
        this.usersInLeague = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "generating courses for");
      });
    


    LeagueService.getUsersByLeague()
    },
    methods:{
            submitForm() {
      const newMatch = {
        matchId: '2',
        matchName: "taylorsMatch",
        startTime: "2017-09-08T19:04:14.480Z"
      };
      MatchService.newMatch(newMatch)
        .then((response) => {
          if (response.status === 201) {
            this.returnLeague = response.data;
         
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "creating");
        });


    },
    filterMatches(){
      
    }

}
}
</script>
<style scoped>

</style>