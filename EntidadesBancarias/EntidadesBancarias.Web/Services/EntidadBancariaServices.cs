using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using EntidadesBancarias.Datos;
using EntidadesBancarias.Entidades;
using EntidadesBancarias.Web.Models.EntidadBancaria;

namespace EntidadesBancarias.Web.Services
{
    public class EntidadBancariaServices : IEntidadBancaria
    {
        private readonly EntidadesBancariasContext _context;
        private IHostingEnvironment _hostingEnvironment;

        public EntidadBancariaServices(EntidadesBancariasContext context, IConfiguration config, IHostingEnvironment environment)
        {
            _context = context;
            _hostingEnvironment = environment;
        }

        public async Task<ActionResult<IEnumerable<EntidadBancariaView>>> Listar()
        {
            IEnumerable<EntidadBancaria> entidades = await _context.Entidades.Include(c => c.GrupoEntidad).ToListAsync();

            ActionResult<IEnumerable<EntidadBancariaView>> listaEntidades = (from entidad in entidades
                                                                             where entidad.EstadoActivo
                                                                             orderby entidad.Id ascending
                                                                             select new EntidadBancariaView
                                                                             {
                                                                                 Nombre = entidad.Nombre,
                                                                                 Direccion = entidad.Direccion,
                                                                                 Poblacion = entidad.Poblacion,
                                                                                 Provincia = entidad.Provincia,
                                                                                 CodPostal = entidad.CodPostal,
                                                                                 Telefono = entidad.Telefono,
                                                                                 Mail = entidad.Mail,
                                                                                 Logo = entidad.Logo,
                                                                                 Pais = entidad.Pais,
                                                                                 GrupoEntidad = entidad.GrupoEntidad.Nombre
                                                                             }).ToList();


            return listaEntidades;
        }

        public async Task Crear([FromForm] PostEntidadBancariaView entidadBancaria)
        {
            //Implementar interfaz
            GrupoEntidad grupoEntidad = await _context.Grupos.FindAsync(entidadBancaria.GrupoEntidadId);

            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
            // ¿quieren la imagen en el servidor o en la base de datos?
            var filePath = Path.Combine(uploads, entidadBancaria.fileLogo.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await entidadBancaria.fileLogo.CopyToAsync(fileStream);
            }

            EntidadBancaria entidad = new EntidadBancaria
            {
                Nombre = entidadBancaria.Nombre,
                Direccion = entidadBancaria.Direccion,
                Poblacion = entidadBancaria.Poblacion,
                Provincia = entidadBancaria.Provincia,
                Telefono = entidadBancaria.Telefono,
                Mail = entidadBancaria.Mail,
                Logo = entidadBancaria.Logo,
                GrupoEntidad = grupoEntidad,
                Pais = entidadBancaria.Pais,
                EstadoActivo = true,
                CodPostal = entidadBancaria.CodPostal,
                fileLogo = new byte[entidadBancaria.fileLogo.Length]
            };

            _context.Entidades.Add(entidad);
            await _context.SaveChangesAsync();
        }
    }
}
