<template>
  <div id="scoreboard">
    <h3>League Leaderboard</h3>
    <div>
      <table>
        <thead>
          <tr>
            <th>Player</th>
            <th>Total Score</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="score in leagueScores" v-bind:key="score.userId">
            <td>
              {{ score.username }}
            </td>
            <td>{{ score.totalScore }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import LeagueService from "../services/LeagueService.js";

export default {
  name: "league-scores",
  data() {
    return {
      leagueScores: [],
    };
  },
  created() {
    LeagueService.getScoresForLeague(this.$route.params.id)
      .then((response) => {
        this.leagueScores = response.data;
        this.leagueScores.forEach((item) => {
          if (item.totalScore === 0) {
            item.totalScore = "E";
          } else if (item.totalScore > 0) {
            item.totalScore = "+" + item.totalScore;
          }
        });
      })
      .catch((error) => {
        this.handleErrorResponse(error, "generating");
      });
  },
  methods: {
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          " leaderboard. Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg =
          "Error " + verb + " leaderboard. Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + " leaderboard. Request could not be created.";
      }
      console.log(this.errorMsg);
    },
  },
};
</script>

<style>
</style>