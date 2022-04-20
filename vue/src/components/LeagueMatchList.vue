<template>
  <div>
    <table id="league-matches">
      <thead>
        <tr>
          <th>Match Name</th>
          <th>Date And Start Time</th>
          <th>Start Time</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="match in matches" v-bind:key="match.matchId">
          <td>
            <router-link :to="{ path: '/match/' + match.matchId }">
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
</style>