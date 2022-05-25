<template>
  <v-app>
    <Header/>
    <v-main>
      <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import Component from "vue-class-component";
import Vue from "vue";
import Header from "@/components/Header.vue";
import {UserModule} from "./store/user";

@Component({
  components: {
    Header,
  }
})
export default class App extends Vue {
  async mounted() {
    window.onstorage = this.storageChanged;
  }

  storageChanged(event: StorageEvent) {
    console.log(event)
    if (event.key == UserModule.AUTH_TOKEN_KEY && event.newValue != UserModule.token) {
      UserModule.SetToken(event.newValue);
    }
  }

  public get isUserLoggedIn(): boolean{
    return !(UserModule.token == null || UserModule.token == "" || UserModule.token == "null");
  }


  async refreshWindow(){
    document.location.reload();
  }
}
</script>