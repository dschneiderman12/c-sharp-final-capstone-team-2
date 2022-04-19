<template>
  <div>
    <form v-on:submit.prevent="submitForm()">
      <h2>Create a New Tee-Time</h2>
      <label> Select A User </label>
      <select id="userList" type="text" v-model.number="userMatch.userId">
        <option
          v-for="user in userList"
          v-bind:key="user.userId"
          v-bind:value="user.userId"
        >
          {{ user.username }}
        </option>
      </select>

      <label>enter a time:</label>

      <input
        id="teetime"
        type="datetime-local"
        class="form-control"
        v-model="userMatch.teeTime"
      />

      <button type="submit" class="btn-submit">Submit</button>
    </form>
  </div>
</template>
<script>
import LeagueService from "../services/LeagueService.js";
import MatchService from "../services/MatchService.js";
export default {
  name: "TeeAssignmentForm",
  data() {
    return {
      userList: [],
      userMatch: {
        matchId: "",
        userId: "",
        teeTime: "",
      },
      match: {
        leagueId: "",
      },

      errorMsg: "",
    };
  },

  created() {
    MatchService.getMatch(this.$route.params.id).then((response) => {
      this.match = response.data;
      LeagueService.getUsersByLeague(this.match.leagueId).then((response) => {
        this.userList = response.data;
      });
    });
  },

  methods: {
    submitForm() {
      const newUm = {
        matchId: Number(this.$route.params.id),
        userId: this.userMatch.userId,
        teeTime: String(this.userMatch.teeTime),
      };
      LeagueService.setTeetimeForUser(newUm)
        .then((response) => {
          if (response.status === 201) {
            // 2010 = "Created"
            alert("TeeTime set.");
          }
        })

        .catch((error) => {
          this.errorMsg = "";

          if (error.response) {
            if (error.response.status === 500) {
              this.errorMessage =
                "Error submitting form. An internal server error occurred.";
            } else if (error.response.status === 404) {
              this.errorMessage =
                "Error submitting form. URL could not be found.";
            } else {
              this.errorMessage =
                "Error submitting form. Response received was code " +
                error.response.status +
                " '" +
                error.response.statusText +
                "'.";
            }
          }
        });
    },
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          " league. Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg =
          "Error " + verb + " league. Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + " league. Request could not be created.";
      }
      console.log(this.errorMsg);
    },
  },
};
</script>

<style scoped>
</style>
