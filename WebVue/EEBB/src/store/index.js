import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    token: null,
    usuario: "Pruebas"
  },
  mutations: {
    setToken(state, token) {
      state.token = token;
    }
  },
  actions: {
    guardarToken({ commit }, token) {
      commit("setToken", token);
      localStorage.setItem("token", token);
    }
  },
  modules: {}
});
