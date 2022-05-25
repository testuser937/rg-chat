import { SiteSettings } from '@/components/settings/SiteSettings';
import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr'
import {UserModule} from "@/store/user";

export default {
    install(Vue) {
        const MAX_TRY: number = 10;
        const TRY_TIMEOUT: number = 10000;
        let tryCounter: number = 0;

        const logLevel = () => {
            if (process.env.NODE_ENV == "production") {
                return LogLevel.None;
            }
            return LogLevel.Debug;
        }

        const connection = new HubConnectionBuilder()
            .withUrl(SiteSettings.baseUrl() + 'chat-hub', {
                accessTokenFactory: () => UserModule.tokenRead,
            })
            .configureLogging(logLevel())
            .build();



        Vue.prototype.$notificationHub = connection;


        let startedPromise = null;

        const start = () => {
            console.log("NotificationHub: start() called");
            startedPromise = connection.start()
                .catch(err => {
                    tryCounter++;
                    if (tryCounter < MAX_TRY) {
                        return new Promise((resolve, reject) =>
                            setTimeout(() => start().then(resolve).catch(reject), TRY_TIMEOUT * tryCounter));
                    } else {
                        console.error(`NotificationHub: Failed to connect to hub in ${MAX_TRY} tries.`)
                    }
                });
            return startedPromise;
        }


        connection.onclose((error) => {
            start()
        });

        start();

        Vue.prototype.$notificationHub.joinChat = (chatId: number) =>{
            if (!startedPromise) return
            console.log("chatId", chatId)
            return startedPromise
                .then(() => connection.invoke('JoinChat', chatId))
                .catch(console.error)
        }

        Vue.prototype.$notificationHub.leaveChat = (chatId: number) => {
            if (!startedPromise) return
            console.log("chatId", chatId)
            return startedPromise
                .then(() => connection.invoke('LeaveChat', chatId))
                .catch(console.error);
        }
    }
}