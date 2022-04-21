<template>
  <div>
    <form v-on:submit.prevent="submitForm()">
      <div id="teetime">
        <h2>Create a New Tee-Time</h2>
      </div>
      <div>
        <select id="userList" type="text" v-model.number="userMatch.userId">
          <option value="" selected="selected" class="default-selector">
            Select a Player
          </option>
          <option
            v-for="user in filteredList"
            v-bind:key="user.userId"
            v-bind:value="user.userId"
          >
            {{ user.username }}
          </option>
        </select>
      </div>
      <input
        id="tee-time"
        type="datetime-local"
        class="form-control"
        v-bind:min="today"
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
      nullMatchScore: [],
      filteredList: [],
      userMatch: {
        matchId: "",
        userId: "",
        teeTime: "",
      },
      match: {
        leagueId: "",
        dateAndTime: "",
      },
      errorMsg: "",
      today: "",
    };
  },

  created() {
    this.today = new Date();
    let dd = this.today.getDate();
    let mm = this.today.getMonth() + 1; //January is 0 so need to add 1 to make it 1!
    let yyyy = this.today.getFullYear();
    if (dd < 10) {
      dd = "0" + dd;
    }
    if (mm < 10) {
      mm = "0" + mm;
    }
    this.today = `${yyyy}-${mm}-${dd}T00:00`;
    MatchService.getMatch(this.$route.params.id).then((response) => {
      this.match = response.data;
      LeagueService.getUsersByLeague(this.match.leagueId).then((response) => {
        this.userList = response.data;
        MatchService.getAllUserMatches(this.$route.params.id).then((response) => {
          this.nullMatchScore = response.data;
          this.filteredList = this.userList.filter((user) => {
            return this.nullMatchScore.every((empty) => {
              return empty.userId != user.userId;
            });
          });
        });
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
      MatchService.setTeeTimeForUser(newUm)
        .then((response) => {
          if (response.status === 201) {
            // 2010 = "Created"
            alert("TeeTime set.");
            location.reload();
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
.default-selector {
  color: lightgray;
  text-decoration-style: wavy;
  display: none;
}
#teetime {
  font-style: italic;
  font-weight: bold;
  background: wheat;
  border-radius: 4px;
  font-size: large;
  color: #184d47;
  font-size: small;
  filter: drop-shadow(3px 3px 3px black);
  text-transform: capitalize;
}
</style>
