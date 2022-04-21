<template>
  <div>
    <form id="match-form" v-on:submit.prevent="submitForm()">
      <h2 id="setup">Set up a new match</h2>
      <div>
        <h2 class="inputPrompt">Enter a title for your new match</h2>
        <input
          id="match-name"
          type="text"
          class="form-control"
          v-model="match.matchName"
        />
      </div>
      <div>
        <h2 class="inputPrompt">Please choose a start date and time</h2>
        <input
          id="starttime"
          type="datetime-local"
          class="form-control"
          v-bind:min="today"
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
  },
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
      today: "",
    };
  },

  methods: {
    submitForm() {
      const newMatch = {
        matchName: this.match.matchName,
        DateAndTime: String(this.match.startTime),
        leagueId: Number(this.$route.params.id),
      };
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
      this.today = yyyy + "-" + mm + "-" + dd;
      if (newMatch.DateAndTime == this.today) {
        alert("you cannot set a match earlier than today");
        return;
      }

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
#match-form {
  background: rgba(189, 236, 162, 0.8);
  border-radius: 3px;
  padding: 20px;
  margin: 20px;
  filter: drop-shadow(black 3px 3px 3px);
}
.inputPrompt {
  font-size: medium;
  font-weight: medium;

  margin: 0%;
}
#starttime {
  color: rgb(24, 77, 71);
}
#setup {
  margin: 0;
  font-weight: bolder;
  border: 4px rgb(24, 77, 71) solid;
  border-radius: 2px;
  background: #e1fad4;
  margin-bottom: 5px;
  padding: 2px;
  padding-left: 1px;
  display: flex;
  justify-content: center;
}
</style>