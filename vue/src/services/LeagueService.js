import axios from 'axios';
import store from '../store/index.js';
store.getters.config;
const http = axios.create({
  baseURL: "https://localhost:44315",
  // headers: {
  //   'Authorization': `${store.state.token}`
  // }
});

export default {

  newLeague(league) {
    return http.post('/League', league)
  },

  getLeagues(userID) {
    return http.get(`/League/user/${userID}`)
  },

  getCurrentLeague(leagueID) {
    return http.get(`/League/${leagueID}`)
  },

  //Don't think we will need this anymore in this service
  addUserToLeague(userID, league) {
    return http.post(`/League/invite/user/${userID}`, league)
  },

  getCourses() {
    return http.get('/courses')

  },
<<<<<<< HEAD
  getUsersByLeague(leagueId){
    return axios.get(`/league/users/${leagueId}`)
}
=======

  getUsersByLeague(leagueID) {
    return axios.get(`/match/user/${leagueID}`)
  },
  setTeetimeForUser(userMatch) {
    return axios.post('/match', userMatch)

  },

  addMatchScore(userMatch) {
    return axios.put('/match', userMatch)
  }
>>>>>>> 303a0cced65ef53ae7bbf1dd71bc3455a868ce04
}