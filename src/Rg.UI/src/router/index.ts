import Vue from 'vue'
import VueRouter from 'vue-router'
import HomeView from "@/views/HomeView.vue";
import {UserModule} from "../store/user";
import LoginView from "@/views/LoginView.vue";
import ChatControl from "@/components/ChatControl.vue";

Vue.use(VueRouter)

const routes = [
    {
        path: '/',
        name: 'Home',
        component: HomeView
    },
    {
        path: "/chat/:chatId",
        name: "Chat",
        component: ChatControl,
        props: true,
    },
    {
        path: "/login",
        name: "Login",
        component: LoginView,
        props: true,
        meta: {
            guest: true
        },
    },
]

const router = new VueRouter({
    mode: 'history',
    base: process.env.BASE_URL,
    routes
})

//Auth watch hooks
router.beforeEach((to, from, next) => {
    if (to.matched.some(route => route.meta.guest)) {
        next();
    }
    else {
        if (UserModule.authorizedRead == true) {
            next();
        }
        else {
            next({
                name: "Login",
                params: { nextUrl: to.fullPath },
            });
        }
    }
});

export default router