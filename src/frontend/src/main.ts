import '@/assets/main.css'

import '@mdi/font/css/materialdesignicons.css'
import { createApp } from 'vue'
import '@/prototypes/Date'
import '@/prototypes/String'

import App from '@/App.vue'
import router from '@/router'
import vuetify from '@/plugins/vuetify'

const app = createApp(App)

app.use(router).use(vuetify)

app.mount('#app')
