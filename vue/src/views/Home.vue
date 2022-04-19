<template>
  <div class="home">
    <div id="league-info">
      <h1>My Leagues</h1>
      <div class="nav-link">
        <router-link class="leagueLink" v-bind:to="{ name: 'league' }"
          >New League</router-link
        >
        <!-- &nbsp;&nbsp; -->
      </div>
    </div>
    
    <league-list />
    <div id = "inviteBox">
    <div id="invites">
      <h3 id= inviteHead>League Invitations</h3>
    </div>
    <invites-pending />
    </div>
    <div id="dashboard-flex">
    <div id ="upcoming">
      <h1 id="upcomingMatches">Upcoming Matches</h1>
      <user-matches/>  
    </div>
    <div id= "AddCourse">
      <course-form/>
    </div>
    </div>
  </div>
</template>

<script>
import InvitesPending from "../components/InvitesPending.vue";
import LeagueList from "../components/LeagueList.vue";
import UserMatches from "../components/UserMatchList.vue";
import CourseForm from "../components/CourseForm.vue";
export default {
  name: "home",
  components: { LeagueList, InvitesPending, UserMatches, CourseForm},
};
</script>
<style scoped>
.grow { 
transition: all .2s ease-in-out; 
}

.grow:hover { 
transform: scale(1.1); 
}
#page-body > div.home {
  background-color: rgba(209, 255, 209, 0.5);
  /* border-color: rgb(43, 126, 43); */
  /* border-style: solid;
  border-width: 3px; */
  border-radius: 6px;
  padding: 5px;
  /* margin: 30px; */
  width: 80%;
  filter: drop-shadow(5px 5px 5px black);
  display: flex;
  margin-top: 20px;
  margin-bottom: 20px;
  flex-direction: column;
  /* justify-content: space-around; */
  align-items: center;
}
#league-info > h1
 {
  filter: drop-shadow(3px 3px 3px black);
  background-color: #184d47;
  text-decoration: none;
  font-weight: bold;
  text-shadow: black 5px 5px 5px;
  color: white;
  font-size: x-large;
  display: flex;
  width: 60%;
  justify-content: center;
  margin-bottom: 3px;
}
#league-info {
  display: flex;
  flex-direction: column;
  justify-content: center;
 

  width: 80%;
}
#league-info > div {
  display: flex;
  justify-content: flex-end;


}
#league-info > div > a{
  margin-top: 3px;
  text-decoration: none;
background: oldlace;
border-radius: 40px;
padding:4px;
padding-top: 0;
padding-bottom: 0;
font-size: 75%;
color: rgb(122, 107, 73);
font-weight:bold;
border: 1px rgb(122, 107, 73) solid;
/* text-shadow:rgba(0, 0, 0, 0.2) 1px 1px 1px; */
}
#league-info > div > a:hover{
  background: #ebc96e;
}
#dashboard-flex{
  flex-direction: column;
  width:100%;
}
#upcoming{
  background: rgba(24, 77, 71, .5);
  border-radius:4px;
  padding:10px;
}
#upcomingMatches{
  font-style: italic;
  font-weight: bold;
background:wheat;
border-radius:4px;
font-size:large;
color:#184D47;

 filter: drop-shadow(3px 3px 3px black);
text-transform: capitalize;

}
#inviteHead{
  
  filter: drop-shadow(3px 3px 3px black);
  background-color: rgba(24, 77, 71, .5);
  text-decoration: none;
  font-weight: bold;
text-shadow: none;
  color: white;
  font-size: x-large;
  display: flex;

margin:30px;
margin-bottom: 10px;

}
#inviteBox{
  display:flex;
  flex-direction:column;
  background-color: rgba(24, 77, 71, .5);
  margin:20px;
 
}

</style>