<template>
  <div>
    <form id="match-form" v-on:submit.prevent="submitForm()">
      <div>
        <h2>..... create a new match...please enter a title for your match</h2>
        <input
          id="match-name"
          type="text"
          class="form-control"
          v-model="match.matchName"
        />
      </div>
      <div>
        enter a startTime
        <input
          id="starttime"
          type="datetime-local"
          class="form-control"
          v-model="match.startTime"
        />
      </div>
      <button type="submit" class="btn-submit">Submit</button>
    </form>
  </div>
</template>
<script>
import MatchService from "../services/MatchService.js";
export default {
  data() {
    return {
      match: {
        matchName: "",
        startTime: "",
        leagueId: "",
      },
      returnMatch: {
        matchName: "",
        startTime: "",
        leagueId: "",
        matchID: "",
      },
      usersInLeague: [],
      errorMsg: "",
      courses: [],
    };
  },

  methods: {
    submitForm() {
      const newMatch = {
        matchName: this.match.matchName,
        DateAndTime: String(this.match.startTime),
        leagueId: Number(this.$route.params.id),
      };
      MatchService.newMatch(newMatch)
        .then((response) => {
          if (response.status === 201) {
            this.returnMatch = response.data;
            alert("match created");
            this.$router.push(`/match/${this.returnMatch.matchId}`);
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "creating");
        });
    },
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          " match. Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg =
          "Error " + verb + " match. Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + " match. Request could not be created.";
      }
      console.log(this.errorMsg);
    },

    filterMatches() {},
  },
};
</script>
<style scoped>
</style>