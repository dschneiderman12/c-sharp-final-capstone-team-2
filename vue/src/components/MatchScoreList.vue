<template>
  <div>
      <h3>Match Leaderboard</h3>
    <table id="match-scores">
      <thead>
        <tr>
          <th>Player</th>
          <th>Match Score</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="score in matchScores" v-bind:key="score.userId">
          <td>
            {{ score.username }}
          </td>
          <td>{{ score.score }}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import MatchService from "../services/MatchService.js";

export default {
  name: "match-score-list",
  data() {
    return {
      matchScores: [],
    };
  },
  created() {
    MatchService.getAllMatchScores(this.$route.params.id)
      .then((response) => {
        this.matchScores = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "generating"); //need to add the method
      });
  },
};
</script>

<style>
</style>