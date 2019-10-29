using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.WebApi.Models;
using Biblioteca.WebApi.Models.Entidades;
using Biblioteca.WebApi.Models.IRepositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Biblioteca.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IRepositorioUsuario repositorio;
        private readonly TokenManagement _tokenManagement;
        private readonly ILogger _logger;

        public LoginController(IRepositorioUsuario _repositorio, IOptions<TokenManagement> tokenManagement, ILogger<LoginController> logger)
        {
            repositorio = _repositorio;
            _tokenManagement = tokenManagement.Value;
            _logger = logger;
        }


        [AllowAnonymous]
        [Route("ValidarUsuario")]
        [HttpPost]
        public async Task<IActionResult> ValidarUsuario([FromBody] UsuarioLogin request)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuario usuario = await repositorio.ValidarUsuario(request.Usuario, request.Password);

            if (usuario == default)
            {
                _logger.LogDebug("el usuario no es valido = ", request.Usuario, request.Password);
                return Ok(new { token = string.Empty });
            }

            var claim = new[]
            {
                new Claim(ClaimTypes.Name, request.Usuario)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                _tokenManagement.Issuer,
                _tokenManagement.Audience,
                claim,
                expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
                signingCredentials: credentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            _logger.LogDebug("Usario valido, token ", request.Usuario, request.Password, token);

            _logger.Log(LogLevel.Information, "prueba", request.Password);
            return Ok(new { token = token });

        }
    }
}