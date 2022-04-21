<template>
  <div>
    <h3>Invite to: {{ invite.toLeagueName }}</h3>
    <h3>From: {{ invite.inviteFrom }}</h3>
    <button id="accept-invite" v-on:click="accept(), addToLeague()">
      Accept Invite
    </button>
    <button id="decline-invite" v-on:click="decline()">Decline Invite</button>
  </div>
</template>

<script>
import InviteService from "../services/InviteService.js";
export default {
  data() {
    return {
      invite: {
        toLeagueName: "",
        inviteFrom: "",
        toLeagueId: "",
      },
      league: {
        leagueId: "",
      },
    };
  },
  created() {
    InviteService.getCurrentInvite(this.$route.params.id)
      .then((response) => {
        this.invite = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating");
      });
  },
  methods: {
    accept() {
      InviteService.acceptInvite(this.$route.params.id)
        .then((response) => {
          if (response.status === 200) {
            this.$router.push("/");
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "accepting");
        });
    },
    addToLeague() {
      const addLeague = {
        leagueId: this.invite.toLeagueId,
      };
      InviteService.addUserToLeague(this.$store.state.user.userId, addLeague)
        .then((response) => {
          if (response.status === 200) {
            alert("Invite accepted");
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "adding user to league from");
        });
    },
    decline() {
      InviteService.declineInvite(this.$route.params.id)
        .then((response) => {
          if (response.status === 200) {
            this.$router.push("/");
            alert("Invite declined");
          }
        })
        .catch((error) => {
          this.handleErrorResponse(error, "declining");
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