using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesBancarias.Entidades
{
    public class EntidadBancaria
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Poblacion { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string CodPostal { get; set; }
        [Required]
        public int Telefono { get; set; }
        [Required]
        public string Mail { get; set; }
        public string Logo { get; set; }
        public byte[] fileLogo { get; set; }
        public string Pais { get; set; }
        public bool EstadoActivo { get; set; }
        [Required]
        public int? GrupoEntidadID { get; set; }
        public virtual GrupoEntidad GrupoEntidad { get; set; }

    }
}
