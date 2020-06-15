using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EntidadesBancarias.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;

        public TokenController(IConfiguration configuration)
        {
            _config = configuration;
        }

        // POST: api/Token/
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Token(string usuario)
        {
            if (usuario == "Pruebas")
            {
                return Ok(new { token = GenerarTokenJWT(usuario) });
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerarTokenJWT(string usuario)
        {
            //Generar un token estático para las pruebas.
            // CREAMOS EL HEADER //
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config["JWT:Key"])
                );
            SigningCredentials signingCredentials = new SigningCredentials(
                    symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            JwtHeader header = new JwtHeader(signingCredentials);

            // CREAMOS LOS CLAIMS //
            Claim[] claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario)
            };

            // CREAMOS EL PAYLOAD //
            JwtPayload payload = new JwtPayload(
                    issuer: _config["JWT:Issuer"],
                    audience: _config["JWT:Audience"],
                    claims: claims,
                    notBefore: null,
                    expires: null
                );

            // GENERAMOS EL TOKEN //
            var token = new JwtSecurityToken(
                    header,
                    payload
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}