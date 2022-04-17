<template>
  <div>
    <!-- <form v-on:submit.prevent="submitForm()"> -->
      <div><h2>Create a new teetime</h2></div>
      
      <div> 
          
         
        
             {{userlist}}  
     
          
          <users-in-league-list>
          </users-in-league-list>
        enter a userId
        <input
          id="userid"
          type="text"
          class="form-control"
          v-model="userMatch.userId"
        />
    
        <label>enter a time:</label>

        <input
          id="teetime"
          type="text"
          class="form-control"
          v-model="userMatch.teeTime"
        />
      </div>
      <button type="submit" class="btn-submit">Submit</button>
    <!-- </form> -->
  </div>
</template>
<script>
import  LeagueService  from '../services/LeagueService';

import UsersInLeagueList from './UsersInLeagueList.vue';

export default {
    name: "TeeAssignmentForm",
    data() {
        return{
                userMatch: {
                    matchId: "",
                    userId: "",
                    teeTime: "",

                },
                    errorMsg: "",
        }
        
    },
    components:{UsersInLeagueList},
    created(){
 LeagueService.getUsersByLeague(this.$route.params.id)
  .then((response) => {
        this.userlist = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating"); //need to add the method
      });

    },
   
    methods:{
        submitForm() {

            LeagueService.setTeetimeForUser(this.userMatch)
            .then(response => {
        if (response.status === 201) { // 201 = "Created"
          this.userMatch = { matchId: '', userId: '', teeTime:'' };
        }
      })
        
         .catch((error) => {
          this.errorMsg = '';
    
    
          if (error.response) {
          
          if (error.response.status === 500) {
            this.errorMessage = "Error submitting form. An internal server error occurred.";
          } else if (error.response.status === 404) {
             this.errorMessage = "Error submitting form. URL could not be found.";
          } else {
             this.errorMessage = "Error submitting form. Response received was code " + error.response.status + " '" + error.response.statusText + "'.";
          }

        
      }
    })
        },
    },
    };

</script>

<style scoped>
</style>
