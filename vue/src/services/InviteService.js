import axios from 'axios';

export default {

    newInvite(invite) {
        return axios.post('/Invite', invite)
    },

    getPendingInvites(userID) {
        return axios.get(`/Invite/${userID}`)
    },

    addUserToLeague(userID, league) {
        return axios.post(`/Invite/${userID}`, league)
    },

    acceptInvite(inviteID) {
        return axios.put(`/Invite/${inviteID}/accept`)
    },

    declineInvite(inviteID) {
        return axios.put(`/Invite/${inviteID}/decline`)
    },

    getAllUsers() {
        return axios.get('/user')
    }


}
