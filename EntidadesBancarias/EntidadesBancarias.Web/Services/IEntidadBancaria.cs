using Microsoft.AspNetCore.Mvc;
using EntidadesBancarias.Web.Models.EntidadBancaria;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EntidadesBancarias.Entidades
{
    public interface IEntidadBancaria
    {
        Task<ActionResult<IEnumerable<EntidadBancariaView>>> Listar();

        Task Crear([FromForm] PostEntidadBancariaView entidadBancaria);

    }
}
