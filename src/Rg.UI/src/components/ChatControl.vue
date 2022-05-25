<template>
  <v-card>
    <v-card-text>
      <v-virtual-scroll
          :bench="benched"
          :items="items"
          height="400"
          item-height="32"
      >
        <template v-slot:default="{ item }">
          <v-list-item :key="item.Id">
            <v-list-item-content>
              <v-list-item-title>
                {{ item.Dt }} Пользователь{{ item.UserId }} Сообщение {{ item.Text }}
              </v-list-item-title>
            </v-list-item-content>

          </v-list-item>
        </template>
      </v-virtual-scroll>
      <v-text-field v-model="message"></v-text-field>
      <v-btn @click="send">Отправить</v-btn>
    </v-card-text>
  </v-card>

</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import {Prop} from "vue-property-decorator";
import MessageModel from "@/models/MessageModel";
import MessageController from "@/controllers/MessageController";
import {AxiosResponse} from "axios";
import {UserModule} from "@/store/user";
import {MessageWriteModel} from "@/models/MessageWriteModel";

@Component
export default class ChatControl extends Vue {
  messageController = new MessageController();
  items: MessageModel[] = []
  benched = 0
  message = ''
  messageToSend: MessageWriteModel
  maxMessagesCount = 50
  @Prop()
  public chatId: number;

  created() {
    // @ts-ignore
    this.$notificationHub.joinChat(this.chatId);
    this.$notificationHub.on('NewMessage', this.onNewMessage);
    UserModule.SetCurrentChatId(this.chatId);
  }

  beforeDestroy() {
    // @ts-ignore
    this.$notificationHub.leaveChat(this.chatId);

    this.$notificationHub.off('NewMessage', this.onNewMessage);

    UserModule.SetCurrentChatId(-1);
  }

  mounted() {
    this.loadMessages()
  }

  loadMessages() {
    this.messageController.GetLastMessages(this.chatId, this.maxMessagesCount)
        .then(this.messagesLoaded)
        .catch(e => console.log(e));
  }

  messagesLoaded(response: AxiosResponse<MessageModel[]>) {
    this.items = response.data;
  }

  send() {
    if (!this.message || this.message.length === 0) {
      alert("Сначала введите сообщение!")
      return
    }

    this.messageToSend = new MessageWriteModel(
        this.chatId,
        UserModule.id,
        this.message,
        new Date());
    this.messageController.SendMessage(this.messageToSend);
  }

  onNewMessage(message: MessageModel) {
    this.items.push(message);
    if (this.items.length > this.maxMessagesCount) {
      this.items = this.items.slice(this.items.length - this.maxMessagesCount, this.items.length)
    }
  }
}
</script>

<style scoped>

</style>