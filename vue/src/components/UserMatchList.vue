<template>
  <div>
    <table id="league-matches">
      <thead>
        <tr>
          <th>Match Name</th>
          <th>Date And Start Time</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="match in matches" v-bind:key="match.matchId">
          <td>
            <router-link :to="{ path: '/match/' + match.matchId }">
              {{ match.matchName }}
            </router-link>
          </td>
          <td>{{ match.teeTime }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import MatchService from "../services/MatchService.js";
export default {
  name: "user_matches",
  data() {
    return {
      matches: [],
    };
  },
  created() {
    MatchService.getUserMatchesHomePage(this.$store.state.user.userId)
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
</style>