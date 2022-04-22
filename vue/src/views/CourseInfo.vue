<template>
  <div>
    <h3>{{ course.courseName }}</h3>

    <iframe
      width="600"
      height="450"
      style="border: 0"
      loading="lazy"
      allowfullscreen
      referrerpolicy="no-referrer-when-downgrade"
      v-bind:src="[srcString]"
    >
    </iframe>

    <h3>Address: {{ course.address }}</h3>
    <h3>Active Leagues:</h3>
    <div>
      <router-link
        :to="{ path: '/league/' + league.leagueId }"
        v-for="league in leagueList"
        v-bind:key="league.leagueId"
        v-text="`${league.leagueName}||` + ' '"
      >
      </router-link>
      <vue-weather
        v-if="showForecast == true"
        api-key="8967dc1398824eb30d8ee9b314182915"
        units="us"
        v-bind:latitude="[geometry.lat]"
        v-bind:longitude="[geometry.lon]"
      />
    </div>
  </div>
</template>

<script>
import CourseService from "../services/CourseService.js";
import VueWeather from "vue-weather-widget";
export default {
  data() {
    return {
      course: {
        courseId: "",
        courseName: "",
        address: "",
      },
      leagueList: [],
      srcString: "",
      geometry: {},
      showForecast: false,
    };
  },
  components: {
    VueWeather,
  },
  created() {
    CourseService.getCourseById(this.$route.params.id).then((response) => {
      this.course = response.data;
      this.srcString = `https://www.google.com/maps/embed/v1/place?key=AIzaSyCMwjT48KCWWEad9HoL0IRtRAEG2rB96os&q=${this.course.courseName}`;
      CourseService.getLeaguesByCourseId(this.course.courseId).then(
        (response) => {
          this.leagueList = response.data;
          CourseService.getCoordinates(
            this.course.address.substr(this.course.address.length - 5)
          ).then((response) => {
            this.geometry = response.data;
            this.showForecast = true;
          });
        }
      );
    });
  },
};
</script>

<style>
#page-body > div:nth-child(1) > div > div{background: ;
width:100%}
#page-body > div:nth-child(1) > div{
  margin: 0px;
}
#page-body > div:nth-child(1) > div > div > div.vww__content > div.vww__currently{
  width:250px;
}
</style>