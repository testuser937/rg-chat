<template>
  <v-container>
    <v-row>
      <v-col>
        <span>Авторизация</span>
      </v-col>

    </v-row>
    <v-row>
      <v-col>
        <v-form
            ref="form"
            v-model="valid"
            lazy-validation
        >
          <v-text-field
              v-model="login"
              label="Логин"
              required
          ></v-text-field>

          <v-text-field
              v-model="password"
              :type="'password'"
              label="Пароль"
              required
          ></v-text-field>

          <v-btn
              :disabled="!valid"
              class="mr-4"
              color="success"
              @click="submit"
          >
            Войти
          </v-btn>
        </v-form>
      </v-col>
    </v-row>

  </v-container>

</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import {UserController} from "@/controllers/UserController";
import {UserModule} from "../store/user";
import {AuthenticationModel} from "@/models/AuthenticationModel";

@Component
export default class LoginView extends Vue {
  login = ""
  password = ""
  valid = true
  userController: UserController = new UserController()

  submit() {
    this.userController.Authenticate(new AuthenticationModel(this.login, this.password)).then(
        user => {
          UserModule.SetAuthorized(true);
          UserModule.SetToken(user.data.Token);
          UserModule.SetUserName(user.data.Login);
          UserModule.SetId(user.data.Id)
        }
    )
        .then(() => {
          if (this.$route.params.nextUrl != null) {
            this.$router.push(this.$route.params.nextUrl);
          } else {
            this.$router.push({name: "Home"});
          }
        })
        .catch(e => {
          UserModule.SetToken("");
          UserModule.SetUserName("");
          UserModule.SetAuthorized(false);
          UserModule.SetId(-1)
          alert("Неверный логин/пароль")
        })
  }
}

</script>