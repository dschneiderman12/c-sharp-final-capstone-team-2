<template>
  <div>
    <form v-on:submit.prevent="submitForm()">
      <div>
        <h2>..... create a new match...please enter a title for your match</h2>
        <input
          id="match-name"
          type="text"
          class="form-control"
          v-model="match.matchId"
        />
      </div>
      <div>
        enter a startTime
        <input
          id="starttime"
          type="text"
          class="form-control"
          v-model="match.startTime"
        />
      </div>
      <button type="submit" class="btn-submit">Submit</button>
    </form>
  </div>
</template>
<script>
import MatchService from "../services/MatchService";
import LeagueService from "../services/LeagueService";
export default {
  data() {
    return {
      match: {
        matchId: "",
        matchName: "",
        startTime: "",
      },
      matches: [],
      usersInLeague: [],
      errorMsg: "",
      courses: [],
    };
  },
  created() {

              //this needs to be league id instead of 1
    MatchService.getMatches(1)
      .then((response) => {
        this.matches = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "generating matches for");
      });
    LeagueService.getCourses()
      .then((response) => {
        this.usersInLeague = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "generating courses for");
      });

   
  },
  methods: {
    submitForm() {
      const newMatch = {
        matchId: this.match.matchId,
        matchName: this.match.matchName,
        startTime: this.match.startTime,
      };
      MatchService.newMatch(newMatch)
        .then((response) => {
          if (response.status === 201) {
            this.returnLeague = response.data;
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
   }
  },
   
};
</script>
<style scoped>
</style>