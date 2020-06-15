using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntidadesBancarias.Entidades
{
    public class GrupoEntidad
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Color { get; set; }


        public ICollection<EntidadBancaria> EntidadBancaria { get; set; }
    }
}
