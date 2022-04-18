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
    getMatches(leagueId) {
        return http.get(`/${leagueId}`)
    },

    newMatch(match) {
        return http.post(`/createMatch`, match)
    },

    getUserMatches(leagueId) {
        return axios.get(`/userMatch/${leagueId}`)
    },

    addMatchScore(userMatch) {
        return axios.put('/userMatch', userMatch)
    }

}