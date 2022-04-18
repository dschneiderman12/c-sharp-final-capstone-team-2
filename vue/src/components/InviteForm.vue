<template>
  <div>
    <form v-on:submit.prevent="submitForm()">
      <div><h2>Invite player to league</h2></div>
      <h3>Select player:</h3>
      <select id="user-list" v-model.number="invite.toUserId">
        <option
          v-for="user in leagueUsers"
          v-bind:key="user.userId"
          v-bind:value="user.userId"
        >
          {{ user.username }}
        </option>
      </select>
      <button type="submit" class="btn-submit">Send Invite</button>
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
      users: [],
      leagueUsers: [],
      pendingInvites: [], //placeholder for when we call in method for the list
    };
  }, 
  created() {
    InviteService.getAllUsers()
      .then((response) => {
        this.users = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "generating users for");
      });
      //creates list of users in league
      InviteService.getUsersForInvite(this.$route.params.id, this.$store.state.user.userId)
     .then((response) => {
        this.leagueUsers = response.data;
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating"); //need to add the method
      });
  },
  methods: {
    submitForm() {
      const newInvite = {
        toUserId: this.invite.toUserId, //v-bind to user list selection
        toLeagueId: Number(this.$route.params.id) 
      };
      //runs through list of users in league and checks if intended invitee is already enrolled
      InviteService.newInvite(newInvite) //currently allows for duplicate invites, need to handle this
        .then((response) => {
          if (response.status === 201) {
            this.returnInvite = response.data;
            alert("Invite sent");
            //this.$router.push(); 
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