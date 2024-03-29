import Vue from 'vue'
import { HubConnection } from '@microsoft/signalr';

declare module 'vue/types/vue' {
    interface Vue {
        $notificationHub: HubConnection
  }
}