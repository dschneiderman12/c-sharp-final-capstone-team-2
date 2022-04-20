import axios from 'axios';
    const google  = axios.create({
        baserurl: "https://maps.googleapis.com"
    });

    
export default {

    createCourse(course){
        return axios.post("/course/", course)
    },
    getCourses() {
        return axios.get('/course')
      },
    getCourseById(courseId){
        return axios.get(`course/${courseId}`)
    },
    getLeaguesByCourseId(courseId){
        return axios.get(`/course/leagues/${courseId}`)
    },
    getLatitudeAndLongitude(address){
        return google.get(`/maps/api/geocode/json?address=${address}&key=AIzaSyCMwjT48KCWWEad9HoL0IRtRAEG2rB96os`)
    }
}