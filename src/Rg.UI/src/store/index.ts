import Vue from 'vue';
import Vuex from 'vuex';
import {IUser} from "./user";

Vue.use(Vuex);

export interface IRootState {
    user: IUser;
}

const store = new Vuex.Store<IRootState>({});

export default store;

