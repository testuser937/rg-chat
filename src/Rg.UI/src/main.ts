import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import router from './router'
import Axios from "axios";
import axios, {AxiosResponse} from "axios";
import store from "./store";
import {UserModule} from "./store/user";
import NotificationHub from "@/plugins/notificationHub";

Vue.config.productionTip = false

Axios.defaults.withCredentials = true;

axios.interceptors.request.use((config: any) => {
    const authToken = UserModule.token;
    if (authToken) {
        config.headers.Authorization = `Bearer ${authToken}`;
    }
    return config;
}, (err: any) => {
    return Promise.reject(err);
});

axios.interceptors.response.use(
    function (response: AxiosResponse) {
        return response
    },
    function (error) {
        if (error.response.status === 401) {
            store.dispatch('logout')
            router.push('/login')
        } else {
            alert(error.response.data.error)
            router.push('/')
        }
        return Promise.reject(error)
    })

Vue.use(NotificationHub)

new Vue({
    router,
    store,
    vuetify,
    render: h => h(App)
}).$mount('#app');




