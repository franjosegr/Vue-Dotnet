<template>
  <v-layout align-start>
    <v-flex>
      <v-data-table
        :headers="headers"
        :items="lista"
        :search="search"
        sort-by="calories"
        class="elevation-1"
      >
        <template v-slot:top>
          <v-toolbar flat color="white">
            <v-toolbar-title>Lista de entidades bancarias</v-toolbar-title>
            <v-divider class="mx-4" inset vertical></v-divider>
            <v-spacer></v-spacer>
            <v-text-field
              v-model="search"
              append-icon="mdi-magnify"
              label="Búsqueda"
              single-line
              hide-details
            ></v-text-field>
            <v-spacer></v-spacer>
            <v-dialog v-model="dialog" max-width="800px">
              <template v-slot:activator="{ on }">
                <v-btn color="primary" dark class="mb-2" v-on="on">Añadir entidad</v-btn>
              </template>
              <v-card>
                <form enctype="multipart/form-data">
                  <v-card-title>
                    <span class="headline">{{ formTitle }}</span>
                  </v-card-title>

                  <v-card-text>
                    <v-container>
                      <v-row>
                        <v-col cols="12" sm="12" md="12">
                          <v-text-field v-model="editedItem.nombre" label="Nombre"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="12" md="12">
                          <v-text-field v-model="editedItem.direccion" label="Dirección"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="6">
                          <v-text-field v-model="editedItem.poblacion" label="Población"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="6">
                          <v-text-field v-model="editedItem.provincia" label="Provincia"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field v-model="editedItem.codPostal" label="Código postal"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field v-model="editedItem.telefono" label="Teléfono"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field v-model="editedItem.mail" label="Mail"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="12" md="12">
                          <label for="imagen">Logo:</label>
                          <input type="file" @change="cargarImagen" accept="image/*" id="imagen" />
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-select
                            v-model="editedItem.grupoEntidadId"
                            :items="grupo"
                            label="Grupo Entidad"
                          ></v-select>
                        </v-col>
                        <v-col cols="12" sm="6" md="4">
                          <v-text-field v-model="editedItem.pais" label="País"></v-text-field>
                        </v-col>
                        <v-col cols="12" sm="12" md="12" v-show="!valido">
                          <div
                            class="red--text"
                            v-for="errores in mensajeError"
                            :key="errores"
                            v-text="errores"
                          ></div>
                        </v-col>
                      </v-row>
                    </v-container>
                  </v-card-text>

                  <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="blue darken-1" text @click="cerrar"
                      >Cerrar</v-btn
                    >
                    <v-btn color="blue darken-1" text @click="guardar">Guardar</v-btn>
                  </v-card-actions>
                </form>
              </v-card>
            </v-dialog>
          </v-toolbar>
        </template>
      </v-data-table>
    </v-flex>
  </v-layout>
</template>

<script>
//Separar en 3 partes HTML / CSS / JS
// Carpeta para cada componente 
import axios from "axios";
export default {
  data: () => ({
    valido: true,
    mensajeError: [],
    lista: [],
    grupo: [],
    fileLogo: "",
    dialog: false,
    search: "",
    headers: [
      { text: "Nombre", align: "start", sortable: false, value: "nombre" },
      { text: "Dirección", value: "direccion", sortable: false },
      { text: "Población", value: "poblacion", sortable: false },
      { text: "Provincia", value: "provincia", sortable: false },
      { text: "Cod. Postal", value: "codPostal", sortable: false },
      { text: "Teléfono", value: "telefono", sortable: false },
      { text: "Mail", value: "mail", sortable: false },
      { text: "Logo", value: "logo", sortable: false },
      { text: "Grupo Entidad", value: "grupoEntidad", sortable: false },
      { text: "Pais", value: "pais", sortable: false }
    ],
    editedItem: {
      nombre: "",
      direccion: "",
      poblacion: "",
      provincia: "",
      codPostal: "",
      telefono: "",
      mail: "",
      logo: "",
      fileLogo: "",
      grupoEntidadId: "",
      pais: ""
    },
    defaultItem: {
      nombre: "",
      direccion: "",
      poblacion: "",
      provincia: "",
      codPostal: "",
      telefono: "",
      mail: "",
      logo: "",
      fileLogo: "",
      grupoEntidadId: "",
      pais: ""
    },
    id: ""
  }),
  computed: {
    formTitle() {
      return "Nueva entidad bancaria";
    }
  },

  watch: {
    dialog(val) {
      val || this.cerrar();
    }
  },

  created() {
    this.cargarLista();
    this.cargarGrupos();
  },
  methods: {
    cargarLista() {
      let that = this;
      const header = { Authorization: `Bearer ${this.$store.state.token}` };
      const configuration = { headers: header };
      axios
        .get("/api/EntidadesBancarias/Listar", configuration)
        .then(function(response) {
          that.lista = response.data;
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    cargarImagen(event) {
      this.fileLogo = event.target.files[0];
    },
    cargarGrupos() {
      let that = this;
      that.grupo = [];
      axios
        .get("/api/GruposEntidades/GetGrupos")
        .then(function(response) {
          response.data.map(function(x) {
            that.grupo.push({
              text: x.nombre,
              value: x.id
            });
          });
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    cerrar() {
      this.dialog = false;
      this.fileLogo = null;
      this.$refs.imagen.value = "";
      setTimeout(() => {
        this.editedItem = Object.assign({}, this.defaultItem);
      }, 300);
    },
    guardar() {
      if (!this.validar()) {
        return false;
      }
      let that = this;
      this.editedItem.logo = this.fileLogo.name;
      this.editedItem.fileLogo = this.fileLogo;
      const formData = new FormData();
      Object.keys(this.editedItem).forEach(function(item) {
        formData.append(item, that.editedItem[item]);
      });
      axios
        .post("api/EntidadesBancarias/Crear", formData, {
          headers: {
            "Content-Type": "multipart/form-data"
          }
        })
        .then(function() {
          that.editedItem = Object.assign({}, that.defaultItem);
          that.cargarLista();
          that.cerrar();
        })
        .catch(function(error) {
          console.log(error);
        });
    },
    validar() {
      // Pruebas de validaciones
      // Extraer a clase externa las validaciones y así no repetir en cada archivo.
      this.valido = true;
      this.mensajeError = [];

      if (
        this.editedItem.nombre.length > 100 ||
        this.editedItem.nombre.trim().length === 0
      ) {
        this.mensajeError.push(
          "El nombre es obligatorio y no puede tener más de 100 caracteres"
        );
      }

      if (
        this.editedItem.direccion.length > 250 ||
        this.editedItem.direccion.trim().length === 0
      ) {
        this.mensajeError.push(
          "La dirección es obligatoria y no puede tener más de 250 caracteres"
        );
      }

      if (
        this.editedItem.poblacion.length > 100 ||
        this.editedItem.poblacion.trim().length === 0
      ) {
        this.mensajeError.push(
          "La población es obligatoria y no puede tener más de 100 caracteres"
        );
      }

      if (
        this.editedItem.mail.length > 100 ||
        this.editedItem.mail.trim().length === 0
      ) {
        this.mensajeError.push(
          "La dirección mail es obligatoria y no puede tener más de 100 caracteres"
        );
      }

      if (
        this.editedItem.provincia.length > 100 ||
        this.editedItem.provincia.trim().length === 0
      ) {
        this.mensajeError.push(
          "La provincia es obligatoria y no puede tener más de 100 caracteres"
        );
      }

      if (this.editedItem.codPostal.trim().length !== 5) {
        this.mensajeError.push("El código postal es obligatorio");
      }

      if (this.editedItem.telefono.trim().length !== 9) {
        this.mensajeError.push("El teléfono es obligatorio");
      }

      if (this.editedItem.grupoEntidad === "") {
        this.mensajeError.push("El grupo entidad es obligatorio");
      }
      if (this.mensajeError.length > 0) {
        this.valido = false;
      }

      return this.valido;
    }
  }
};
</script>
