namespace EntidadesBancarias.Web.Models.EntidadBancaria
{
    public class EntidadBancariaView
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public string Provincia { get; set; }
        public string CodPostal { get; set; }
        public int Telefono { get; set; }
        public string Mail { get; set; }
        public string Logo { get; set; }
        public int Entidad { get; set; }
        public string Pais { get; set; }
        public bool EstadoActivo { get; set; }
        public string GrupoEntidad { get; set; }
    }
}
