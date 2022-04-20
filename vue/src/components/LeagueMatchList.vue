<template>
  <div>
    <table id="league-matches">
      <thead>
        <tr>
          <th>Match Name</th>
          <th>Date</th>
          <th>Start Time</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="match in matchInfo" v-bind:key="match.matchId">
          <td>
            <router-link :to="{ path: '/match/' + match.matchId }">
              {{ match.name }}
            </router-link>
          </td>
          <td>{{ match.date }}</td>
          <td>{{ match.time }}</td>
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
      matchInfo: [],
      match: {
        matchId: "",
        name: "",
        date: "",
        time: "",
      },
    };
  },
  created() {
    MatchService.getMatches(this.$route.params.id)
      .then((response) => {
        this.matches = response.data;
        this.matches.forEach((item) => {
          let newMatch = {};
          newMatch.matchId = item.matchId;
          newMatch.name = item.matchName;
          let fullDate = item.dateAndTime;
          newMatch.date = new Date(fullDate).toDateString();
          newMatch.time = new Date(fullDate).toLocaleTimeString([], {
            hour: "2-digit",
            minute: "2-digit",
          });
          this.matchInfo.push(newMatch);
        });
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating"); //need to add the method
      });
  },
};
</script>

<style>
</style>