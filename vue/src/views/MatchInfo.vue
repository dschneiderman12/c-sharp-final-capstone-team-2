<template>
  <div>
    <div>
      <match-score-list />
    </div>
    <div>
      <h2 v-on:created="populateLeague()">Match Name: {{ match.matchName }}</h2>
      <tee-assignment-form
        v-if="league.organizerId === $store.state.user.userId"
      />
    </div>
    <div>
      <match-score v-if="league.organizerId === $store.state.user.userId" />
    </div>
  </div>
</template>

<script>
import LeagueService from "../services/LeagueService.js";
import MatchService from "../services/MatchService.js";
import TeeAssignmentForm from "../components/TeeAssignmentForm.vue";
import MatchScore from "../components/MatchScore.vue";
import MatchScoreList from "../components/MatchScoreList.vue";

export default {
  components: { TeeAssignmentForm, MatchScore, MatchScoreList },
  data() {
    return {
      match: {
        matchId: "",
        matchName: "",
        leagueId: "",
        leagueName: "",
        StartTime: "",
      },
      league: {
        leagueId: "",
        organizerId: "",
      },
      errorMsg: "",
      clicker: "",
    };
  },
  created() {
    MatchService.getMatch(this.$route.params.id)
      .then((response) => {
        this.match = response.data;
        LeagueService.getCurrentLeague(this.match.leagueId)
          .then((response) => {
            this.league = response.data;
          })
          .catch((error) => {
            this.handleErrorResponse(error, "getting current league");
          });
      })
      .catch((error) => {
        this.handleErrorResponse(error, "getting current league");
      });
  },
  methods: {
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          "  Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg = "Error " + verb + "  Server could not be reached.";
      } else {
        this.errorMsg = "Error " + verb + "  Request could not be created.";
      }
      console.log(this.errorMsg);
    },
  },
};
</script>

<style scoped>
</style>
