using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesBancarias.Entidades;
using EntidadesBancarias.Web.Models.EntidadBancaria;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EntidadesBancarias.Tests
{
    [TestClass]
    public class TestEntidades
    {
        private static TestContext _context;
        private static HttpClient userHttpCient;
        private static TestServer server;
        private static IConfiguration _config;

        [ClassInitialize()]
        public static void Setup(TestContext context)
        {
            _context = context;
            server = new TestServer(new WebHostBuilder().UseStartup<StartupFake>());
            _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }


        private string GenerarTokenJWT(string usuario)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_config["JWT:Key"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.UniqueName, usuario)
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: _config["JWT:Issuer"],
                    audience: _config["JWT:Audience"],
                    claims: _Claims,
                    notBefore: null,
                    expires: null
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }


        [TestMethod]
        public async Task ListarConToken()
        {
            string token = GenerarTokenJWT("Pruebas");
            userHttpCient = server.CreateClient();
            userHttpCient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await userHttpCient.GetAsync("api/EntidadesBancarias/Listar");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var entidades = JsonConvert.DeserializeObject<IEnumerable<EntidadBancariaView>>(responseString);

            Xunit.Assert.NotEmpty(entidades);
        }

        [TestMethod]
        public async Task ListarSinToken()
        {
            userHttpCient = server.CreateClient();
            var response = await userHttpCient.GetAsync("api/EntidadesBancarias/Listar");
            Xunit.Assert.Equal(System.Net.HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
