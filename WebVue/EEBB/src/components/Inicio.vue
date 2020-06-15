<template>
  <v-container>
    <v-row>
      <v-col class="mb-4">
        <h1 class="display-2 font-weight-bold mb-3">
          GESTIÓN DE ENTIDADES BANCARIAS
        </h1>
        <p class="subheading font-weight-regular">
          API REST en ASP.NET Core y un frontend en vuejs (cli).
        </p>
        <p class="subheading font-weight-regular">
          La entidad bancaria tiene las siguientes propiedades básicas:
        </p>
        <p class="subheading font-weight-regular">
          ID, Nombre, Dirección, Población, Provincia, Cod. Postal, Teléfono,
          Mail, Logo, Grupo Entidad, Pais, Estado_Activo.
        </p>
        <p class="subheading font-weight-regular">
          Un grupo entidad tiene las siguientes:
        </p>
        <p class="subheading font-weight-regular">Id, Nombre, Color</p>
        <p class="subheading font-weight-regular">
          La columna estado_activo es un filtro global booleano que indica si
          debe mostrar ese registro o no.
        </p>
      </v-col>

      <v-col class="mb-5" cols="12">
        <h2 class="headline font-weight-bold mb-3">
          Las opciones que se deben implementar son:
        </h2>

        <ul>
          <li>Crear la base de datos relacional de las entidades.</li>
          <li>
            Modelar el contexto de datos de estas tablas en Entity Framework
            Core 2.2.
          </li>
          <li>
            Crear una API básica que tenga las siguientes operaciones:
            <ul>
              <li>
                Listado de entidades, con al menos dos filtros opcionales y
                ordenación por Id
              </li>
              <li>Inserción de nueva entidad</li>
            </ul>
          </li>
          <li>
            Crear un frontend en Vue que muestre el listado de entidades como
            una tabla donde se muestre las entidades junto con el nombre de su
            grupo y un modal para insertar una nueva entidad.
          </li>
        </ul>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import axios from "axios";
export default {
  name: "Inicio",

  data: () => ({}),
  created() {
    if (this.$store.state.token === null) {
      this.ObtenerToken();
    }
  },
  methods: {
    ObtenerToken() {
      let that = this;
      // Simulo una llamada de "login" para obtener el token de autorización
      axios
        .post("/api/Token?usuario=Pruebas")
        .then(function(response) {
          return response.data;
        })
        .then(function(data) {
          that.$store.dispatch("guardarToken", data.token);
        })
        .catch(function(error) {
          console.log(error);
        });
    }
  }
};
</script>
