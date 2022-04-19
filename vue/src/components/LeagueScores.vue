<template>
  <div id="scoreboard">
    <h3>League Leaderboard</h3>
    <div>
    <table>
      <thead>
        <tr>
          <th>Player</th>
          <th>Cumulative Score (+/- Par)</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="score in LeagueScores" v-bind:key="score.userId">
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
  name: "LeagueScores",
  data() {
    return {
      LeagueScores: [],
    };
  },
  created() {
    LeagueService.getScoresForLeague(this.$route.params.id)
      .then((response) => {
        this.LeagueScores = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "getting"); //need to add the method
      });
  },
};
</script>

<style>
</style>