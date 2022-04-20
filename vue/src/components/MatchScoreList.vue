<template>
  <div>
    <div id= "match_board">
    <h2 id d="matchboard">Match Leaderboard</h2>
    </div>
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
          <td>{{ score.total }}</td>
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
        this.matchScores.forEach((item) => {
          if (item.total === 0) {
            item.total = "E";
          }
        });
      })
      .catch((error) => {
        this.handleErrorResponse(error, "generating"); //need to add the method
      });
  },
};
</script>

<style>
#match_board{
   font-style: italic;
  font-weight: bold;
background:wheat;
border-radius:4px;
font-size:large;
color:#184D47;
font-size: small;
 filter: drop-shadow(3px 3px 3px black);
text-transform: capitalize;
}
</style>