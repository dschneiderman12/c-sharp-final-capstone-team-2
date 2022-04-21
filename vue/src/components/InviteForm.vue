<template>
  <div>
    <form id="invite-form" v-on:submit.prevent="submitForm()">
      <div>
        <h2 id="invitePlayer">Invite player to league</h2>
        <h2 id="selectPlayer">Select player:</h2>
        <select id="user-list" v-model.number="invite.toUserId">
          <option value="" selected="selected" class="default-selector">
            Select a Player
          </option>
          <option
            v-for="user in filteredUsers"
            v-bind:key="user.userId"
            v-bind:value="user.userId"
          >
            {{ user.username }}
          </option>
        </select>
        <button type="submit" class="btn-submit">Send Invite</button>
      </div>
      <div>
        <table>
          <thead>
            <tr>
              <th>Pending Invites</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="user in pendingInvites" v-bind:key="user.toUserId">
              <td>{{ user.toUsername }}</td>
            </tr>
          </tbody>
        </table>
      </div>
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
      filteredUsers: [],
      leagueUsers: [],
      pendingInvites: [], //placeholder for when we call in method for the list
    };
  },
  created() {
    //creates list of users in league
    InviteService.getUsersForInvite(this.$route.params.id)
      .then((response) => {
        this.leagueUsers = response.data;
        InviteService.getPendingInvitesForLeague(this.$route.params.id).then(
          (response) => {
            this.pendingInvites = response.data;
            this.filteredUsers = this.leagueUsers.filter((user) => {
              return this.pendingInvites.every((pend) => {
                return pend.toUserId != user.userId;
              });
            });
          }
        );
      })
      .catch((error) => {
        this.handleErrorResponse(error, "creating"); //need to add the method
      });
  },
  methods: {
    submitForm() {
      const newInvite = {
        toUserId: this.invite.toUserId, //v-bind to user list selection
        toLeagueId: Number(this.$route.params.id),
      };
      //runs through list of users in league and checks if intended invitee is already enrolled
      InviteService.newInvite(newInvite) //currently allows for duplicate invites, need to handle this
        .then((response) => {
          if (response.status === 201) {
            this.returnInvite = response.data;
            alert("Invite sent");
            location.reload();
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
#selectPlayer {
  font-size: medium;
  font-weight: medium;

  margin: 0%;
}
#invite-form {
  background: rgba(189, 236, 162, 0.8);
  border-radius: 3px;
  padding: 20px;
  margin: 20px;
  filter: drop-shadow(black 3px 3px 3px);
}
#invitePlayer {
  margin: 0;
  font-weight: bolder;
  border: 4px rgb(24, 77, 71) solid;
  border-radius: 2px;
  background: #e1fad4;
  margin-bottom: 5px;
  padding: 2px;
  padding-left: 1px;
  display: flex;
  justify-content: center;
}
</style>