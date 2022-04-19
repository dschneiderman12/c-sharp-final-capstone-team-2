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
    }, 
    getMatch(matchId){
        return axios.get(`/match/info/${matchId}`)
<<<<<<< HEAD
=======
    },
    getUserMatchesHomePage(userId){
        return axios.get(`/userMatch/list/${userId}`)
>>>>>>> 26b1b4afaba4993f5a3b977693f7728663f6c261
    }

}