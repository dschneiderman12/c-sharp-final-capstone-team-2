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
    <button v-if="showButton === true" v-on:click="hideButton()">Hide</button>
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
      showButton: false,
      srcString: "",
    };
  },
  methods: {
    locationToSearch() {
      this.showMap = true;
      this.showButton = true;
      this.srcString = `https://www.google.com/maps/embed/v1/search?key=AIzaSyCMwjT48KCWWEad9HoL0IRtRAEG2rB96os&q=golf+course+${this.courseSearch}`;
      
    },
    hideButton(){
      this.showMap = false;
      this.showButton = false;
    
    }
    
  },
};
</script>

<style>
.search-map {
  /* width: 100%; */
  height: 30vh;
  width:60vw;
}
/* #map-block {
  
  

} */
h3 {
  filter: drop-shadow(3px 3px 3px black);
  text-shadow: darkslateblue 5px 5px 5px;
  color: white;
  margin: 0px;
}

#map {
  /* controls box around map */
  /* display: flex;
  justify-content: center; */
  background-color: rgba(209, 255, 209, 0.5);
  /* border-color: rgb(43, 126, 43); */
  /* border-style: solid;
  border-width: 3px; */
  border-radius: 6px;
  padding: 5px;
  /* margin: 30px; */
  width: 60%;
  filter: drop-shadow(5px 5px 5px black);
  display:flex;
  margin-top: 20px;
  margin-bottom:20px;
  /* margin-left:30%; */
  /* justify-content: space-around; */
  /* padding: 4%;  */
  padding-top: 2%;
  height:80%;
}
button{
  background-color: #184D47 ;
  color: white;
}
</style>