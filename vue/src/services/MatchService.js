import axios from 'axios';
import store from '../store/index.js';
store.getters.config;


export default {
    getMatches(leagueID){
        return axios.get(`/match/${leagueID}`)
    },
    newMatch(match){
        return axios.post(`/createMatch`, match)

    },
    
    

    getUserMatches(leagueId) {
        return axios.get(`/userMatch/${leagueId}`)
    },

    addMatchScore(userMatch) {
        return axios.put('/userMatch', userMatch)
    }

}