<template>
  <div>
    <form v-on:submit.prevent="submitForm()">
      <!-- <label for="course-name">Course Name:</label> -->
      <input type="text" v-model="course.courseName" />
      <button type="submit" class="btn-submit">Add Course</button>
    </form>
  </div>
</template>


<script>
import CourseService from "../services/CourseService.js";
export default {
  name: "course-form",
  data() {
    return {
      course: {
        CourseName: "",
        courseId: "",
      },
      returnCourse: {
        courseName: "",
        courseId: "",
      },
    };
  },
  created() {},
  methods: {
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          " invite. Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg =
          "Error " + verb + " invite. Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + " invite. Request could not be created.";
      }
      console.log(this.errorMsg);
    },

    submitForm() {
      const newCourse = {
        courseName: this.course.courseName,
      };
      CourseService.createCourse(newCourse)
        .then((response) => {
          if (response.status === 201) {
            this.returnCourse = response.data;
            alert("Course Added.");
            this.course.courseName = "";
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "creating");
        });
    },
  },
};
</script>

<style>
</style>