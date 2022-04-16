<template>
  <div>
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
        <!-- not sure what for="cars" is -->
        <label for="cars">Choose a course:</label>

        <select id="course-name" v-model.number="league.leagueCourse.courseId">
          <option
            v-for="course in courses"
            v-bind:key="course.courseId"
            v-bind:value="course.courseId"
          >
            {{ course.courseName }}
          </option>
        </select>
      </div>
      <button type="submit" class="btn-submit">Submit</button>
    </form>
    <form v-on:submit.prevent="addUser()">
      <div>this is where we can add players</div>
      <h2>Add player to League</h2>
      <select name="select-player" id="select-player">
        <!-- need to pull from database of current users 
        need the user list method on backend for this-->
        <option value="1" id="user-id-one">1</option>
      </select>
      <button type="submit" class="btn-submit">Add User</button>
    </form>
  </div>
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
          //courseName: "",
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
      courses: [],
    };
  },
  created() {
    LeagueService.getCourses()
      .then((response) => {
        this.courses = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "generating courses for");
      });
  },
  methods: {
    submitForm() {
      const newLeague = {
        leagueName: this.league.leagueName,
        organizerId: Number(this.$store.state.user.userId),
        leagueCourse: {          
          courseId: this.league.leagueCourse.courseId,
          //courseName:
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
    addUser() {
      //Need to replace with current league page we are in
      const league = {
        leagueId: 2,
      };
      //Need to replace number with selected user, currently will only work once
      LeagueService.addUserToLeague(3, league)
        .then((response) => {
          if (response.status === 201) {
            this.$router.push(`/league`); // This isn't working
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "adding user to");
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
#page-body > div:nth-child(1) {
  background: rgba(150, 187, 124, 0.6);
  border-radius: 5px;
}
#page-body > div:nth-child(1) > form > div:nth-child(1) > h2 {
  filter: drop-shadow(3px 3px 3px black);
  text-shadow: darkslateblue 3px 3px 3px;
  color: white;
  font-weight: bolder;
  background: rgb(250, 213, 134);
  background: rgba(150, 187, 124);
  /* border-radius: 7px;*/
  border-bottom: blanchedalmond solid 3px;
}
</style>