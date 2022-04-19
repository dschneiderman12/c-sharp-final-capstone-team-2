import axios from 'axios';


export default {

  newLeague(league) {
    return axios.post('/League', league)
  },

  getLeagues(userID) {
    return axios.get(`/League/user/${userID}`)
  },

  getCurrentLeague(leagueID) {
    return axios.get(`/League/${leagueID}`)
  },

  //Don't think we will need this anymore in this service
  addUserToLeague(userID, league) {
    return axios.post(`/League/invite/user/${userID}`, league)
  },

  getCourses() {
    return axios.get('/courses')
  },
 
  getUsersByLeague(leagueID) {
    return axios.get(`/match/user/${leagueID}`)
  },

  getScoresForLeague(leagueID) {
    return axios.get(`/league/scores/${leagueID}`)
  }

}