<template>
  <div>
    <h3>Search for golf courses</h3>
    <input
      type="text"
      id="course-search"
      class="form-search"
      placeholder="Enter city or zip"
      v-model="courseSearch"
    />
    <button v-on:click="locationToSearch()">Search</button>
    <div class="map">
      <iframe
        class="search-map"
        referrerpolicy="no-referrer-when-downgrade"
        v-bind:src="[srcString]"
        v-if="showMap === true"
        allowfullscreen
      >
      </iframe>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      courseSearch: "",
      showMap: false,
      srcString: "",
    };
  },
  methods: {
    locationToSearch() {
      this.showMap = true;
      this.srcString = `https://www.google.com/maps/embed/v1/search?key=AIzaSyCMwjT48KCWWEad9HoL0IRtRAEG2rB96os&q=golf+course+${this.courseSearch}`;
    },
  },
};
</script>

<style>
.search-map {
  width: 800px;
  height: 600px;
}
</style>