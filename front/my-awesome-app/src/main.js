import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import './styles/app.css';
import 'tw-elements'
import { library } from '@fortawesome/fontawesome-svg-core'
import {faPhone, faUser, faTriangleExclamation} from '@fortawesome/free-solid-svg-icons'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'

library.add(faPhone, faUser, faTriangleExclamation)

createApp(App).component('fa', FontAwesomeIcon).use(store).use(router).mount('#app')
