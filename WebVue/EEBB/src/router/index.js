import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Lista from "../components/ListarEntidades.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home
  },
  {
    path: "/Listar",
    name: "Lista",
    component: Lista  
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;
