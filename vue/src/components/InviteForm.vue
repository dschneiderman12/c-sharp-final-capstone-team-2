<template>
  <div>
    <form v-on:submit.prevent="submitForm()">
      <div><h2>Invite player to league</h2></div>
    </form>
  </div>
</template>

<script>
import InviteService from "../services/InviteService";

export default {
  name: "invite-form",
  data() {
    return {
      invite: {
        toUserId: "",
        toLeagueId: "",
      },
      returnInvite: {
        inviteId: "",
        inviteStatus: "",
        toUserId: "",
        toLeagueId: "",
      },
      pendingInvites: [], //placeholder for when we call in method for the list
    };
  },
  methods: {
    submitForm() {
      const newInvite = {
        toUserId: this.user.userId, //v-bind to user list selection
        toLeagueId: this.league.leagueId, // should be in league page we are in, not sure about syntax
      };
      InviteService.newInvite(newInvite)
        .then((response) => {
          if (response.status === 201) {
            this.returnInvite = response.data;
            this.$router.push(); // need to decide where to go if successful
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "creating");
        });
    },
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          " invite. Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg =
          "Error " + verb + " invite. Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + " invite. Request could not be created.";
      }
      console.log(this.errorMsg);
    },
  },
};
</script>

<style>
</style>