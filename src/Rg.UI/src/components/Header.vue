<template>
  <v-app-bar
      app
      color="white"
      elevation="1"
  >
    <div class="d-flex align-center">
      <router-link to="/">
        <v-img
            alt="Df Logo"
            class="shrink mr-2"
            contain
            src="/icons/logo.png"
            transition="scale-transition"
        />
      </router-link>
    </div>

    <v-toolbar-items>
      <v-btn v-for="item in items" :key="item.text" :to="item.link"
             class="no-active"
             color="black"
             text>{{item.text}}
      </v-btn>
    </v-toolbar-items>
    <v-spacer></v-spacer>
    <span>{{ currentUser }}</span>
  </v-app-bar>

</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import {UserModule} from "@/store/user";

@Component({})
export default class Header extends Vue {
  private items: Array<any> = [
    {
      text: 'Чаты',
      link: "/",
    },
  ];

  get currentUser() {
    return UserModule.username;
  }
}
</script>

<style scoped>
>>> .v-btn--active.no-active:not(:hover)::before {
  opacity: 0 !important;
}

>>> .v-btn--active .v-btn__content {
  color: orange;
}
</style>