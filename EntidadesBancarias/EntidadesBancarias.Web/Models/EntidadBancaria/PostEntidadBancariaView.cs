using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EntidadesBancarias.Web.Models.EntidadBancaria
{
    public class PostEntidadBancariaView
    {
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(250)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(100)]
        public string Poblacion { get; set; }
        [Required]
        [StringLength(100)]
        public string Provincia { get; set; }
        [Required]
        [StringLength(5)]
        public string CodPostal { get; set; }
        [Required]
        public int Telefono { get; set; }
        [Required]
        [StringLength(100)]
        public string Mail { get; set; }
        public string Logo { get; set; }
        public IFormFile fileLogo { get; set; }
        [StringLength(50)]
        public string Pais { get; set; }
        public bool EstadoActivo { get; set; }
        [Required]
        public int GrupoEntidadId { get; set; }
    }
}
