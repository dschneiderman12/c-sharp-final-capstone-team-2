import axios from 'axios';


export default {

  newLeague(league) {
    return axios.post('/League', league)
  },

  getLeagues(userId) {
    return axios.get(`/League/user/${userId}`)
  },

  getCurrentLeague(leagueId) {
    return axios.get(`/League/${leagueId}`)
  },

  //Don't think we will need this anymore in this service
  addUserToLeague(userId, league) {
    return axios.post(`/League/invite/user/${userId}`, league)
  },

  getCourses() {
    return axios.get('/courses')
  },
 
  getUsersByLeague(leagueId) {
    return axios.get(`/match/user/${leagueId}`)
  },

  getScoresForLeague(leagueId) {
    return axios.get(`/league/scores/${leagueId}`)
  }

}