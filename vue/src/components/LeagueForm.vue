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
        


        <label id = selectacourse>Choose a course:</label>


        
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
#page-body > div:nth-child(1) > div > form > div:nth-child(2){
  display:flex;
  flex-direction: column;
  align-content: space-between;
}
#page-body > div:nth-child(1) {
  background: rgba(150, 187, 124, 0.6);
  border-radius: 5px;
}

    .this {
        position: relative;
        display: block;
      
        height: 3em;
        line-height: 3;
        overflow: hidden;
        border-radius: .25em;
    }
     
    select {
        width: 100%;
        height: 100%;
        margin: 0;
        padding: 0 0 0 .5em;
   
        cursor: pointer;
    }
 
  
     
    .this::after {
        content: '\25BC';
        position: absolute;
        top: 0;
        right: 0;
        bottom: 0;
        padding: 0 1em;
        background: #34495E;
        pointer-events: none;
    }
     
     .select{
       background-color: #184D47 ;
       color: tan;
      
     
     
     
     }
h2{
background-color: #184D47;
 text-shadow: black 3px 3px 3px;
  filter: drop-shadow(3px 3px 3px black);
border-radius: 3px;
color: white;
padding: 5px;
border: solid tan 3px;

}
     #pagetext{
         filter: drop-shadow(3px 3px 3px black);
  text-shadow: rgb(90, 87, 87) 3px 3px 3px;
  color: white;
  margin: 0px;
  
       
     }

form{
  padding:5%;
  
}
     #leagueName, #selectacourse{
       width:35%;
       background-color: rgb(24, 77, 71);
       margin-top: 5px;
       margin-bottom: 5px;
       
       padding-left: 5px;
       border-radius: 3px;
       
      
     }

</style>