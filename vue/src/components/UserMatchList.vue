<template>
    <div>


        <table id = "league-matches" v-if="this.matches.length >0">
            <thead>
                <tr>
                    <th>Match Name</th>
                    <th>Date And Start Time</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for=" match in matches " v-bind:key="match.matchId" >
                    <td id="matchListItem">
                       <div id= nameOfMatch class= grow>
                          <router-link :to="{path:'/match/' + match.matchId}">
                        
                        {{match.matchName}}
                      
                        </router-link> 
                         </div>
                    </td>
                    <td >{{match.teeTime}}</td>
                </tr>
            </tbody>
        </table>
            <div id=noMatch v-if="this.matches.length <= 0">
        You do not have any upcoming matches.

    </div>
    </div>
</template>

<script>
import MatchService from "../services/MatchService.js";
export default {
  name: "user-matches",
  data() {
    return {
      matches: [],
    };
  },
  created() {
    MatchService.getUserMatchesHomePage(this.$store.state.user.userId)
      .then((response) => {
        this.matches = response.data;

        //  this.matches.forEach((item) => {
        //      let newObj =  {
        // date : item.dateAndTime.substring(0,10),
        // time : item.dateAndTime.substring(10),
        // matchId: item.matchId
        // }

        //    this.dateAndTimes.push(newObj);
        // })
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating"); //need to add the method
      });
  },
};
</script>

<style>

#league-matches {
  width:100%;
}
#league-matches > tbody > tr{
background: rgb(24, 77, 71);
width:100%;

}

#nameOfMatch{
  width: 90%;
  
   display: flex;
   justify-content: center; 
   padding:5px;
   
  padding: 5px;
  
 
}

#nameOfMatch > a{
 background:wheat;
 text-decoration: none;
  color: rgb(24, 77, 71);
  width:100%;
  border-radius:4px;
  display: flex;
  justify-content: center;
  font-weight: 900;
  word-spacing: -2px;
  
  text-transform: capitalize;
  font-variant: small-caps;
  text-decoration: underline;

}
#nameOfMatch > a:hover{
background: #ebc96e;

}
.grow { 
transition: all .2s ease-in-out; 
}

.grow:hover { 
transform: scale(1.1); 
}
</style>