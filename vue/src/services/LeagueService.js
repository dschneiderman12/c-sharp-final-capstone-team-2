import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315"
  });

export default {
    
  newLeague(league) {
    return http.post('/League', league)
  }
}