<template>
  <div id="map-block">
    <h3>Search for golf courses</h3>
    <input
      type="text"
      id="course-search"
      class="form-search"
      placeholder="Search Map"
      v-model="courseSearch"
    />
    <button v-on:click="locationToSearch()">Search</button>
<<<<<<< HEAD
    <button v-if="showButton === true" v-on:click="hideButton()">Hide</button>
=======
>>>>>>> 75c7f933a2d9af03f92f94cdc370622cb7fb8966
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
<<<<<<< HEAD
      showButton: false,
=======
>>>>>>> 75c7f933a2d9af03f92f94cdc370622cb7fb8966
      srcString: "",
    };
  },
  methods: {
    locationToSearch() {
      this.showMap = true;
<<<<<<< HEAD
      this.showButton = true;
      this.srcString = `https://www.google.com/maps/embed/v1/search?key=AIzaSyCMwjT48KCWWEad9HoL0IRtRAEG2rB96os&q=golf+course+${this.courseSearch}`;
      
    },
    hideButton(){
      this.showMap = false;
      this.showButton = false;
    
    }
    
=======
      this.srcString = `https://www.google.com/maps/embed/v1/search?key=AIzaSyCMwjT48KCWWEad9HoL0IRtRAEG2rB96os&q=golf+course+${this.courseSearch}`;
    },
>>>>>>> 75c7f933a2d9af03f92f94cdc370622cb7fb8966
  },
};
</script>

<style>
.search-map {
<<<<<<< HEAD
  width: 100%;
=======
  width: 70vw;
>>>>>>> 75c7f933a2d9af03f92f94cdc370622cb7fb8966
  height: 40vh;
}
#map-block {
  margin-left: 2%;

}
h3 {
  filter: drop-shadow(3px 3px 3px black);
  text-shadow: darkslateblue 5px 5px 5px;
  color: white;
<<<<<<< HEAD
  margin: 0px;
=======
>>>>>>> 75c7f933a2d9af03f92f94cdc370622cb7fb8966
}
.map {
  /* controls box around map */
  /* display: flex;
  justify-content: center; */
}
</style>