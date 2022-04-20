<template>
  <div id="league-board">
    <div id="league-div">
      <div class="loading" v-if="isLoading">
        <img src="../images/spinner.svg" />
      </div>
      <div id="league-list" v-for="league in leagues" :key="league.id">
        <div id="league-names" class="grow">
          <router-link :to="{ path: '/league/' + league.leagueId }" id=leagueNames>
            {{ league.leagueName }}
          </router-link>
        </div>
        <!-- Commenting out - probably don't need here, just click link to league to get these details
      <p class="course-name">{{ league.leagueCourse.courseName }}</p>
      <p>
        {{ league.organizerName }}
      </p>
      --></div>
    </div>
  </div>
</template>

<script>
import LeagueService from "../services/LeagueService.js";
export default {
  name: "League-List",
  data() {
    return {
      leagues: [],
      isLoading: true,
    };
  },
  created() {
    LeagueService.getLeagues(this.$store.state.user.userId)
      .then((response) => {
        this.leagues = response.data;
        this.leagues.shift();
        this.isLoading = false;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating");
      });
  },

  methods: {
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

<style>
#league-board {
  margin-top: 5px;
  border-radius: 15px;
  background: rgb(250, 213, 134);
  background: linear-gradient(
    0deg,
    rgba(250, 213, 134, 0.9164040616246498) 0%,
    rgba(251, 237, 206, 1) 50%,
    rgba(250, 213, 134, 0.7847514005602241) 100%
  );
  filter: drop-shadow(3px 3px 3px black);
  width: 80%;
}
</style>

