<template>
  <div class="d-flex flex-column h-100 w-100 justify-content-center align-items-center bg">
    <v-list rounded>
      <v-subheader>Чаты</v-subheader>
      <v-list-item-group
          color="primary"
      >
        <v-list-item
            v-for="(item, i) in items"
            :key="i"
            @click="listItemClick(item)"
        >
          <v-list-item-content>
            <v-list-item-title>
              {{item.Name}}
            </v-list-item-title>
            <v-list-item-subtitle>
              {{'Клан ' + item.ClanId}}
            </v-list-item-subtitle>
          </v-list-item-content>
        </v-list-item>
      </v-list-item-group>
    </v-list>
  </div>

</template>

<script lang="ts">
import Vue from "vue";
import ChatsController from "@/controllers/ChatsController";
import {AxiosResponse} from "axios";
import Component from "vue-class-component";
import {UserModule} from "../store/user";
import {UserController} from "@/controllers/UserController";
import {ChatModel} from "@/models/ChatModel";

@Component
export default class ChatListControl extends Vue {
  chatController = new ChatsController();
  userController = new UserController();
  items: ChatModel[] = []

  mounted() {
    this.loadChats()
  }

  loadChats() {
    this.chatController.GetList().then(this.chatsLoaded).catch(e => console.log(e));
  }

  chatsLoaded(response: AxiosResponse<ChatModel[]>) {
    this.items = response.data;
  }

  listItemClick(item: ChatModel) {
    this.userController.GetUser(UserModule.id).then(
        user => {
          if (UserModule.currentChatId > 0 && UserModule.currentChatId !== item.Id){
            alert("Одновременно можно быть только в 1 чате!")
            return
          }

          if (user.data && user.data.ClanId === item.ClanId) {
            // enter to chat
            this.$router.push(
                {
                  name: "Chat",
                  params: {
                    // @ts-ignore
                    chatId: item.Id,
                  }
                });
          } else {
            alert("Вы не являетесь участником клана");
          }
        }
    )
  }
}
</script>

<style scoped>

</style>