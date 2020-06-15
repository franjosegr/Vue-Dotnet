using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EntidadesBancarias.Entidades;
using EntidadesBancarias.Web.Models.EntidadBancaria;

namespace EntidadesBancarias.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntidadesBancariasController : ControllerBase
    {
        private readonly IEntidadBancaria _entidadBancaria;
        private readonly IConfiguration _config;
        private IHostingEnvironment _hostingEnvironment;

        public EntidadesBancariasController(IEntidadBancaria entidadBancaria, IConfiguration config, IHostingEnvironment environment)
        {
            _entidadBancaria = entidadBancaria;
            _config = config;
            _hostingEnvironment = environment;
        }

        // GET: api/EntidadesPruebas/Listar
        [HttpGet("[action]")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<EntidadBancariaView>>> Listar()
        {
            return await _entidadBancaria.Listar();
        }

        // POST: api/EntidadesPruebas/Crear
        [HttpPost("[action]")]
        public async Task<ActionResult<EntidadBancaria>> Crear([FromForm] PostEntidadBancariaView entidadBancaria)
        {
            // Implementar interfaz
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _entidadBancaria.Crear(entidadBancaria);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
