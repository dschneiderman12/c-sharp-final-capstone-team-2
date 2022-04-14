<template>
  <table>
    <thead>
      <tr>
      
        <th>League Name</th>
        <th>course</th>
        <th>League Organizer</th>
        <th>Leader</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="league in leagues" :key="league.id">
        <td class="league-name">
          {{ league.leagueName }}
        </td>
        <td class="course-name">{{ league.leagueCourse.courseName }}</td>
        <td>
          {{ league.organizerName }}
        </td>
        <td>LEADER</td>
      </tr>
    </tbody>
  </table>
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
</style>           