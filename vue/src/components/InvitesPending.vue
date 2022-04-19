<template>
  <div id="invitations">
    <div
      id="invite-list"
      v-for="invite in pendingInvites"
      :key="invite.inviteId"
    >
  
      <router-link :to="{ path: '/invite/' + invite.inviteId }"
        >Invite to {{ invite.toLeagueName }}
      </router-link>
    </div>
  </div>
</template>

<script>
import InviteService from "../services/InviteService.js";
export default {
  name: "invites-pending",
  data() {
    return {
      pendingInvites: [],
    };
  },
  created() {

    InviteService.getPendingInvites(this.$store.state.user.userId)
      .then((response) => {
        this.pendingInvites = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "retrieving");
      });
  },
  methods: {
    handleErrorResponse(error, verb) {
      if (error.response) {
        this.errorMsg =
          "Error " +
          verb +
          " invites. Response received was '" +
          error.response.statusText +
          "'.";
      } else if (error.request) {
        this.errorMsg =
          "Error " + verb + " invites. Server could not be reached.";
      } else {
        this.errorMsg =
          "Error " + verb + " invites. Request could not be created.";
      }
      console.log(this.errorMsg);
    },
  },
};
</script>

<style>
</style>