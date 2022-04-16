import axios from 'axios';

export default {

    newInvite(invite) {
        return axios.post('/Invite', invite)
    },

    getPendingInvites(inviteID) {
        return axios.post(`/Invite/${inviteID}`)
    },

    addUserToLeague(userID, league) {
        return axios.post(`/Invite/${userID}`, league)
    },

    acceptInvite(inviteID) {
        return axios.put(`/Invite/${inviteID}/accept`)
    },

    declineInvite(inviteID) {
        return axios.put(`/Invite/${inviteID}/decline`)
    }


}
