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

  addUserToLeague(userID, league) {
    return http.post(`/League/invite/user/${userID}`, league)
  },

  getCourses() {
    return http.get("/courses")
  }
}