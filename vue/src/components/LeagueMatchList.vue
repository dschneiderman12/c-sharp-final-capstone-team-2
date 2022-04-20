<template>
  <div>
    <table id="league-matches">
      <thead>
        <tr>
          <th  >Match Name</th>
          <th>Date And Start Time</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="match in matches" v-bind:key="match.matchId" >
          <td >
            <router-link :to="{ path: '/match/' + match.matchId }" id="match_names">
              {{ match.matchName }}
            </router-link>
          </td>
          <td>{{ match.dateAndTime }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import MatchService from "../services/MatchService.js";
export default {
  name: "league-matches",
  data() {
    return {
      matches: [],
      //dateAndTimes : []
    };
  },
  created() {
    MatchService.getMatches(this.$route.params.id)
      .then((response) => {
        this.matches = response.data;

        //  this.matches.forEach((item) => {
        //      let newObj =  {
        // date : item.dateAndTime.substring(0,10),
        // time : item.dateAndTime.substring(10),
        // matchId: item.matchId
        // }

        //    this.dateAndTimes.push(newObj);
        // })
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating"); //need to add the method
      });
  },
};
</script>

<style>
#leaguePage > div:nth-child(6){
  background-color:peachpuff ;

  
}
#match_names{
  margin: 10px;
}
#match_names{
  color:white;
  text-transform: capitalize;
  text-decoration: none;
  font-weight: bold;
  background:rebeccapurple;
 margin: 10px;
 margin-top:50px;
}
#leaguePage > div:nth-child(6){}
</style>