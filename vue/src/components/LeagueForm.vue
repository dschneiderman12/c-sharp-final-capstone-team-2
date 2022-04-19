<template>
  <div>
    <form v-on:submit.prevent="submitForm()">
      <div id="newLeague"><h2>Create a new League</h2></div>
      <div id = pagetext>
        <div id=leagueName>
        League Name
        </div>
        
        <input
          id="league-name"
          type="text"
          class="form-control"
          v-model="league.leagueName"
        />
        

<!-- 
        <label id = selectacourse>
          Choose a course:</label> -->

Choose a Course
        
        <div class = "this">
        <select id="course-name" v-model.number="league.leagueCourse.courseId">
          <option class="select"
            v-for="course in courses"
            v-bind:key="course.courseId"
            v-bind:value="course.courseId"
          >
        
            
            {{ course.courseName }}
        
          </option>
        </select>
</div>





      </div>
      <button type="submit" class="btn-submit">Submit</button>
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
#newLeague > h2 {
  filter: drop-shadow(3px 3px 3px black);
  background-color: #184d47;
  text-decoration: none;
  font-weight: bold;
  text-shadow: black 5px 5px 5px;
  color: white;
  font-size: x-large;
  display: flex;
  justify-content: center;
  margin-bottom: 3px;
}
#pagetext {
  display: flex;
  flex-direction: column;
  
}
#leagueName {
  margin-top: 30px
}

#league-name {
  margin-bottom: 30px;
}

#pagetext > div.this {
  margin-bottom: 30px;
}
#invite-form {
  row-gap:20px
}
</style>