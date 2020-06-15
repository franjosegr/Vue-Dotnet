using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EntidadesBancarias.Datos;
using EntidadesBancarias.Entidades;

namespace EntidadesBancarias.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposEntidadesController : ControllerBase
    {
        private readonly EntidadesBancariasContext _context;
        //Crear interfaces
        public GruposEntidadesController(EntidadesBancariasContext context)
        {
            _context = context;
        }

        // GET: api/GruposEntidades/GetGrupos
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<GrupoEntidad>>> GetGrupos()
        {
            return await _context.Grupos.ToListAsync();
        }
    }
}
