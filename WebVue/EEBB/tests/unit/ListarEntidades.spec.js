import { mount, createLocalVue } from '@vue/test-utils';
import Vuex from "vuex";
import Entidades from "@/components/ListarEntidades.vue";
import Vue from 'vue';

const localVue = createLocalVue();
localVue.use(Vuex);

const store = new Vuex.Store({
    state: {
        token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlBydWViYXMiLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo0NDMzNy8iLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0NDMzNy9hcGkvRW50aWRhZGVzQmFuY2FyaWFzL0xpc3RhciJ9.MkOJhJdP4LvslC7G-5Gzrp83A6HvnFADovFe1a0ZDLg"
    }
})

describe('componente ListarEntidades.vue', async () => {

    it("Error no token", async (done) => {
        const wrapper = mount(Entidades, {
            store,
            localVue
        });

        // Entidades.methods.cargarLista();

        wrapper.vm.cargarLista();

        await wrapper.vm.cargarLista().then(() => {
            expect(wrapper.vm.lista.length).toBe(0);
            done();
        })


        // Esperar a que termine, comprueba antes de cargar


    });
})