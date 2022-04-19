import axios from 'axios';
export default {

    createCourse(course){
        return axios.post("/course/", course)
    }
}