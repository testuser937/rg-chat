import { VuexModule, Module, Mutation, Action, getModule } from 'vuex-module-decorators'
import {UserController} from "@/controllers/UserController";
import store from "./index";

export interface IUser {
    username: string;
    token: string;
    id: number;
    authorized: Boolean;
    currentChatId: number;
}

@Module({ dynamic: true, store, name: 'User' })
class User extends VuexModule {
    readonly AUTH_USERNAME_KEY: string = "userName";
    readonly AUTH_TOKEN_KEY: string = "authToken";
    readonly AUTH_AUTHORIZED_KEY: string = "authorized";
    readonly AUTH_ID_KEY: string = "id";
    readonly CURRENT_CHAT_ID_KEY: string = "currentChatId";

    username: IUser['username'] = localStorage.getItem(this.AUTH_USERNAME_KEY);
    token: IUser['token'] = localStorage.getItem(this.AUTH_TOKEN_KEY);
    authorized: IUser['authorized'] = JSON.parse(localStorage.getItem(this.AUTH_AUTHORIZED_KEY));
    id : IUser['id'] = JSON.parse(localStorage.getItem(this.AUTH_ID_KEY));
    currentChatId: IUser['currentChatId'] = JSON.parse(localStorage.getItem(this.CURRENT_CHAT_ID_KEY));

    get userNameRead(): string {
        return this.username;
    }

    get tokenRead(): string {
        return this.token;
    }

    get authorizedRead(): Boolean {
        return this.authorized;
    }

    get idRead(): number {
        return this.id;
    }

    get currentChatIdRead(): number{
        return this.currentChatId;
    }

    // Мутации
    @Mutation
    SET_USERNAME(username: string) {
        this.username = username;
    }

    @Mutation
    SET_TOKEN(token: string) {
        this.token = token;
    }

    @Mutation
    SET_AUTHORIZED(auth: Boolean) {
        this.authorized = auth;
    }

    @Mutation
    SET_ID(id: number){
        this.id = id;
    }

    @Mutation
    SET_CURRENT_CHAT_ID(chatId: number){
        this.currentChatId = chatId;
    }

    @Action({ commit: 'SET_USERNAME' })
    async SetUserName(username: string) {
        localStorage.setItem(this.AUTH_USERNAME_KEY, username);
        return username;
    }

    @Action({ commit: 'SET_TOKEN' })
    async SetToken(token: string) {
        let oldValue = localStorage.getItem(this.AUTH_TOKEN_KEY);
        if (oldValue != token) {
            localStorage.setItem(this.AUTH_TOKEN_KEY, token);
        }
        return token;
    }

    @Action({ commit: 'SET_AUTHORIZED' })
    async SetAuthorized(auth: Boolean) {
        localStorage.setItem(this.AUTH_AUTHORIZED_KEY, JSON.stringify(auth));
        return auth;
    }

    @Action({ commit: 'SET_ID' })
    async SetId(id: number) {
        localStorage.setItem(this.AUTH_ID_KEY, JSON.stringify(id));
        return id;
    }

    @Action({ commit: 'SET_CURRENT_CHAT_ID' })
    async SetCurrentChatId(chatId: number) {
        localStorage.setItem(this.CURRENT_CHAT_ID_KEY, JSON.stringify(chatId));
        console.log(JSON.stringify(chatId))
        return chatId;
    }
}

export const UserModule = getModule(User);
