<template>
  <div id="league-board">
    <div id="league-list" v-for="league in leagues" :key="league.id">
      <router-link :to="{ path: '/league/' + league.leagueId }">
        {{ league.leagueName }}
      </router-link>
      <!-- Commenting out - probably don't need here, just click link to league to get these details
      <p class="course-name">{{ league.leagueCourse.courseName }}</p>
      <p>
        {{ league.organizerName }}
      </p>
      -->
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
    };
  },
  created() {
    LeagueService.getLeagues(this.$store.state.user.userId)
      .then((response) => {
        this.leagues = response.data;
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
#league-list {
  background: #184d47;
  color: white;
  display: flex;
  flex-direction: column;
}
#league-board {
  width: 90%;
  background: #184d47;
}
