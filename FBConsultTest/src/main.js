import Vue from 'vue'
import BootstrapVue from "bootstrap-vue"
import App from './App.vue'
import "bootstrap/dist/css/bootstrap.min.css"
import "bootstrap-vue/dist/bootstrap-vue.css"

Vue.use(BootstrapVue)
export const eventBus = new Vue()

Vue.config.productionTip = false

new Vue({
    render: h => h(App),
}).$mount('#app')