<template>
  <div>
    <form v-on:submit.prevent="submitScore()">
      <div>
        <h3>Update scores</h3>
        <label>Select user:</label>
        <select class="user-match" v-model.number="userMatch.userId">
          <option
            v-for="user in userMatches"
            v-bind:key="user.counter"
            v-bind:value="user.userId"
          >
            {{ user.username }}
          </option>
        </select>
      </div>
      <div>
        <label>Select match:</label>
        <select class="user-match" v-model.number="userMatch.matchId">
          <option
            v-for="match in userMatches"
            v-bind:key="match.counter"
            v-bind:value="match.matchId"
          >
            {{ match.matchName }}
          </option>
        </select>
      </div>
      <div>
        <input id="score" type="text" v-model.number="userMatch.score" />
      </div>
      <button type="submit" class="btn-submit">Submit</button>
    </form>
  </div>
</template>

<script>
import MatchService from "../services/MatchService.js";

export default {
  name: "match-score",
  data() {
    return {
      userMatch: {
        matchId: "",
        userId: "",
        score: "",
      },
      userMatches: [],
    };
  },
  created() {
    MatchService.getUserMatches(this.$route.params.id)
      .then((response) => {
        this.userMatches = response.data;
        let adder = 0;
        this.userMatches.forEach((item) => {
          adder++;
          item.counter = adder;
        });
      })
      .catch((error) => {
        this.handleErrorResponse(error, "finding");
      });
  },
  methods: {
    submitScore() {
      this.userMatch = {
        matchId: this.userMatch.matchId,
        userId: this.userMatch.userId,
        score: this.userMatch.score,
      };
      MatchService.addMatchScore(this.userMatch)
        .then((response) => {
          if (response.status === 200) {
            this.$router.push('/');
            alert("Score updated");
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "updating score in");
        });
    },
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          " user matches. Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg =
          "Error " + verb + " user matches. Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + " user matches. Request could not be created.";
      }
      console.log(this.errorMsg);
    },
  },
};
</script>

<style>
</style>