<template>
  <div>
    <table id="user-scores">
      <thead>
        <tr>
          <th>Match</th>
          <th>Date</th>
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

    <div>
      <h3>Your handicap:</h3>
      <p>{{ handicap }}</p>
    </div>
  </div>
</template>

<script>
import MatchService from "../services/MatchService.js";

export default {
  name: "user-scores",
  data() {
    return {
      userScores: [],
      scores: [],
      pars: [],
      scoreTotal: "",
      parTotal: "",
      handicap: "Not enough data to calculate handicap",
      dates: [],
    };
  },
  created() {
    MatchService.getAllUserScores(this.$store.state.user.userId)
      .then((response) => {
        this.userScores = response.data;
        this.userScores.forEach((item) => {
          if (item.total === 0) {
            item.total = "E";
          } else if (item.total > 0) {
            item.total = "+" + item.total;
          }
          this.scores.push(item.score);
          this.pars.push(item.par);
          let myDate = item.teeTime;
          let date = new Date(myDate).toDateString();
          item.teeTime = date;
        });
        this.gameCount = this.userScores.length;
        this.scoreTotal = this.scores.reduce((sum, number) => {
          return sum + number;
        }, 0);
        this.parTotal = this.pars.reduce((sum, number) => {
          return sum + number;
        });
        if (this.userScores.length >= 1) {
          this.handicap = (
            (this.scoreTotal - this.parTotal) /
            this.userScores.length
          ).toFixed(1);
        }
        if (this.handicap < 1) {
          this.handicap = "You're a scratch golfer. Well done!";
        }
      })
      .catch((error) => {
        this.handleErrorResponse(error, "retrieving");
      });
  },
  methods: {
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          " match scores. Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg =
          "Error " + verb + " match scores. Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + " match scores. Request could not be created.";
      }
      console.log(this.errorMsg);
    },
  },
};
</script>

<style>
</style>