import Vue from 'vue';
import Vuetify from 'vuetify/lib/framework';
import en from 'vuetify/src/locale/en';
import ru from 'vuetify/src/locale/ru';

const opts = {
    lang: {
        locales: { en, ru },
        current: 'ru',
    },
}

Vue.use(Vuetify);

export default new Vuetify(opts);
