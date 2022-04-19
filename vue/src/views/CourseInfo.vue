<template>
  <div>

    <h3>{{course.courseName}}</h3>
    
    <iframe
  width="600"
  height="450"
  style="border:0"
  loading="lazy"
  allowfullscreen
  referrerpolicy="no-referrer-when-downgrade"
  v-bind:src="[srcString]">
</iframe>


    <h3>Address: {{course.address}}</h3>
    <h3>Active Leagues:</h3>
    <div>
      <router-link :to="{path:'/league/' + league.leagueId}" v-for="league in leagueList" v-bind:key="league.leagueId" v-text="`${league.leagueName }||`+ ' '">
        
      </router-link>
      
    </div>
  </div>
</template>

<script>
import CourseService from "../services/CourseService.js";
export default {
  data() {
    return {
      course: {
        courseId: "",
        courseName: "",
        address: "",
      },
      leagueList: [],
      srcString: ""
    };
  },
  created() {
    CourseService.getCourseById(this.$route.params.id).then((response) => {
      this.course = response.data;
      this. srcString = `https://www.google.com/maps/embed/v1/place?key=AIzaSyCMwjT48KCWWEad9HoL0IRtRAEG2rB96os&q=${this.course.courseName}`
      CourseService.getLeaguesByCourseId(this.course.courseId)
        .then((response) => {
          this.leagueList = response.data;
        })
        
    });
  },
};
</script>

<style>
</style>