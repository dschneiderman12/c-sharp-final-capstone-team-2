<template>
  <div>
    <table id="league-matches">
      <thead>
        <tr>
          <th  id="matchHeader">Match Name</th>
          <th id="matchHeader2">Date And Start Time</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="match in matches" v-bind:key="match.matchId" id="match-row">
          <td id = "matchNames">
            <router-link :to="{ path: '/match/' + match.matchId }" id="match_names">
              {{ match.matchName }}
            </router-link>
          </td>
          <td id = "dateAndTimes">{{ match.dateAndTime }}</td>
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
      dateTimes: [],
    };
  },
  created() {
    MatchService.getMatches(this.$route.params.id)
      .then((response) => {
        this.matches = response.data;
        this.matches.forEach((item) => {
          let fullDate = item.dateAndTime;
          let date = new Date(fullDate).toDateString();
          let time = new Date(fullDate).toLocaleTimeString([], {hour: '2-digit', minute:'2-digit'})
          this.dateTimes.push(date);
          this.dateTimes.push(time);
        })
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating"); //need to add the method
      });
  },
};
</script>

<style>
#leaguePage > div:nth-child(6){
  background-color:rgb(250, 213, 134);
margin: 10px;
  
}



#league-matches > tbody > tr:nth-child(){
  /* padding: 15px; */
}
#match_names{
  margin: 7px;
}
#match_names{
  color:white;
  text-transform: capitalize;
  text-decoration: none;
  font-weight: bold;
background:rgb(248, 218, 154) ;
  display: flex;
  justify-content: center;
  color:rgb(24, 77, 71) ;
  
 /* margin: 10px; */
 /* margin-top:50px; */
}
#match_names:hover{
  background: rgb(248, 202, 103);
}
#dateAndTimes{
  color:rgb(248, 230, 192);
  padding-left:5%;
}
#matchHeader, #matchHeader2{
  font-weight: bold;
}
#matchHeader2{
  display: flex;
  justify-content: flex-start;
  padding-left:10%;

}
#dateAndTimes{
  font-weight: bold;
}
</style>