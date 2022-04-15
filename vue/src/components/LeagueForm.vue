<template>
  <form v-on:submit.prevent="submitForm()">
    <div><h2>Create a new League</h2></div>
    <div>
      League Name
      <input
        id="league-name"
        type="text"
        class="form-control"
        v-model="league.leagueName"
      />
<label for="cars">Choose a course:</label>

<select name="courseName" id="coursename">
  <option value="1">course 1</option>
  <option value="2">course 2</option>
  <option value="3">course 3</option>
  <option value="4">course 4</option>
</select>
    <div>this is where we can add players</div>

    </div>
    <button type="submit" class="btn-submit">Submit</button>
  </form>
</template>

<script>
import LeagueService from "../services/LeagueService";

export default {
  name: "league-form",
  data() {
    return {
      league: {
        leagueName: "",
        organizerId: "",
        leagueCourse: {
          courseId: "",
          courseName: "",
        },
      },
      returnLeague: {
        leagueId: "",
        leagueName: "",
        organizerId: "",
        leagueCourse: {
          courseId: "",
          courseName: "",
        },
      },
      errorMsg: "",
    };
  },
  methods: {
    submitForm() {
      const newLeague = {
        leagueName: this.league.leagueName,
        organizerId: Number(this.$store.state.user.userId),
        leagueCourse: {
          courseId: 1,
          courseName: "",
        },
      };
      LeagueService.newLeague(newLeague)
        .then((response) => {
          if (response.status === 201) {
            this.returnLeague = response.data;
            this.$router.push(`/league/${this.returnLeague.leagueId}`);
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
#pagebody > div:nth-child(1){
  background: rgba(150, 187, 124, .6);
border-radius: 5px;
}
#pagebody > div:nth-child(1) > form > div:nth-child(1) > h2{
  filter: drop-shadow(3px 3px 3px black);
  text-shadow: darkslateblue 3px 3px 3px;
  color: white;
  font-weight: bolder;
background: rgb(250, 213, 134);
background:rgba(150, 187, 124) ;
  /* border-radius: 7px;*/
  border-bottom: blanchedalmond solid 3px;
}
</style>