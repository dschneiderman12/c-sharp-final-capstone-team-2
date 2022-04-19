<template>
  <div id="login" class="text-center">
    <form class="form-signin" @submit.prevent="login">
      <h1 class="h3 mb-3 font-weight-normal">Please Sign In</h1>
      <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
        Invalid username and password!
      </div>
      <div
        class="alert alert-success"
        role="alert"
        v-if="this.$route.query.registration"
      >
        Thank you for registering, please sign in.
      </div>

      <div class="group">
        <!-- <label for="username" class="sr-only">Username</label> -->
        <input
          type="text"
          id="username"
          class="form-control"
          v-model="user.username"
          required
        />
        <span class="highlight"> </span>
        <span class="bar"> </span>
        <label>Username</label>
      </div>
      <div class="group">
        <!-- <label for="password" class="sr-only">Password</label> -->
        <input
          type="password"
          id="password"
          class="form-control"
          v-model="user.password"
          required
        />
        <span class="highlight"> </span>
        <span class="bar"> </span>
        <label>password</label>
      </div>

      <button class="btn" type="submit">Sign in</button>

      <router-link :to="{ name: 'register' }">Need an account?</router-link>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>
<style>
#login > form {
  /* this controls the properties of the form inside the sign in box */

  display: flex;
  flex-direction: column;

  row-gap: 10px;
  /* this line adds space between items on sign in form */

  width: 80%;
}
.btn {
  width: 30%;
}

#login > form > button {
  margin-top: 20px;
}
#login > form > h1 {
  filter: drop-shadow(3px 3px 3px black);
  background-color: #184d47;
  text-decoration: none;
  font-weight: bold;
  text-shadow: black 5px 5px 5px;
  color: white;
  font-size: x-large;
  display: flex;
  width: 100%;
  justify-content: center;
  margin-bottom: 3px;
}
#login > form > label:nth-child(2),
#login > form > label:nth-child(4) {
  width: 35%;
  background-color: rgb(24, 77, 71);
  margin-top: 5px;
  margin-bottom: 5px;
  color: white;
  padding-left: 5px;
  border-radius: 3px;
}
/* 
#login > form {
  filter: drop-shadow(3px 3px 3px black);
  text-shadow: rgb(90, 87, 87) 3px 3px 3px;
}
#login > form > a {
  filter: none;
  text-shadow:none;
} 


/* form starting stylings ------------------------------- */
.group {
  position: relative;
  margin-bottom: 45px;
}
#username,
#password {
  font-size: 18px;
  padding: 10px 10px 10px 5px;
  display: block;
  width: 300px;
  border: none;
  border-bottom: 1px solid #757575;
}
input:focus {
  outline: none;
}

/* LABEL ======================================= */
label {
  color: #999;
  font-size: 18px;
  font-weight: normal;
  position: absolute;
  pointer-events: none;
  left: 5px;
  top: 10px;
  transition: 0.2s ease all;
  -moz-transition: 0.2s ease all;
  -webkit-transition: 0.2s ease all;
}

/* active state */
input:focus ~ label,
input:valid ~ label {
  top: -20px;
  font-size: 14px;
  color: #5264ae;
}

/* BOTTOM BARS ================================= */
.bar {
  position: relative;
  display: block;
  width: 300px;
}
.bar:before,
.bar:after {
  content: "";
  height: 2px;
  width: 0;
  bottom: 1px;
  position: absolute;
  background: #5264ae;
  transition: 0.2s ease all;
  -moz-transition: 0.2s ease all;
  -webkit-transition: 0.2s ease all;
}
.bar:before {
  left: 50%;
}
.bar:after {
  right: 50%;
}

/* active state */
input:focus ~ .bar:before,
input:focus ~ .bar:after {
  width: 50%;
}

/* HIGHLIGHTER ================================== */
.highlight {
  position: absolute;
  height: 60%;
  width: 100px;
  top: 25%;
  left: 0;
  pointer-events: none;
  opacity: 0.5;
}

/* active state */
input:focus ~ .highlight {
  -webkit-animation: inputHighlighter 0.3s ease;
  -moz-animation: inputHighlighter 0.3s ease;
  animation: inputHighlighter 0.3s ease;
}

/* ANIMATIONS ================ */
@-webkit-keyframes inputHighlighter {
  from {
    background: #5264ae;
  }
  to {
    width: 0;
    background: transparent;
  }
}
@-moz-keyframes inputHighlighter {
  from {
    background: #5264ae;
  }
  to {
    width: 0;
    background: transparent;
  }
}
@keyframes inputHighlighter {
  from {
    background: #5264ae;
  }
  to {
    width: 0;
    background: transparent;
  }
}
</style>