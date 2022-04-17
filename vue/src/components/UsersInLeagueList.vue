<template>
<div>
    {{userlist}}
</div>
</template>

<script>
import LeagueService from "../services/LeagueService.js";


export default {
    name:"usersInLeague",
  components: { },
  data() {
    return {
      userlist: [],
      };
      
    
  },
    created() {
        
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
<style >

</style>
