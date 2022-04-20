<template>
  <div>
    <table id="user-scores">
      <thead>
        <tr>
          <th>Match</th>
          <th>Date and Tee Time</th>
          <th>Score</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="score in userScores" v-bind:key="score.matchId">
          <td>{{ score.matchName }}</td>
          <td>{{ score.teeTime }}</td>
          <td>{{ score.total }}</td>
        </tr>
      </tbody>
    </table>
    <!--
    <div>
      <h3>Your handicap:</h3>
      <h4>{{ totals.handicap }}</h4>
    </div>
    -->
  </div>
</template>

<script>
import MatchService from "../services/MatchService.js";

export default {
  name: "user-scores",
  data() {
    return {
      userScores: [],
      // userTotals: {
      //   score: "",
      //   par: "",
      //   handicap: "",
      // },
    };
  },
  created() {
    MatchService.getAllUserScores(this.$store.state.user.userId)
      .then((response) => {
        this.userScores = response.data;
        this.userScores.forEach((item) => {
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

//   const totals = {
//     score: Number(
//       this.userScores.score.reduce((sum, score) => {
//         return sum + score;
//       }, 0)
//     ),
//     par: Number(
//       this.userScores.par.reduce((sum, score) => {
//         return sum + score;
//       }, 0)
//     ),
//     handicap:
//       (totals.score - totals.par) / Number(this.userScores.length),
//   };
// computed: {
//   getTotalScore() {
//     return this.userScores.score.reduce((sum, score) => {
//       return sum + score;
//     }, 0);
//   },
//   getTotalPar() {
//     return this.userScores.par.reduce((sum, score) => {
//       return sum + score;
//     }, 0);
//   },
// },
</script>

<style>
</style>