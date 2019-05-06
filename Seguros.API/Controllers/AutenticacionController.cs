using AccesoDatos.Dtos;
using AccesoDatos.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Negocio.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Seguros.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        private readonly  IDominioAutenticacion _repositorio;
        private readonly IConfiguration _configuracion;

        public AutenticacionController(IDominioAutenticacion repositorio, IConfiguration configuracion)
        {
            this._repositorio = repositorio;
            this._configuracion = configuracion;
        }     

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioRegistrar usuario)
        {
            usuario.NombreUsuario = usuario.NombreUsuario.ToLower();
            if (await _repositorio.UsuarioExiste(usuario.NombreUsuario))
            {
                return BadRequest("El usuario ya existe");
            }
            var usuarioCrear = new Usuario
            {
                NombreUsuario = usuario.NombreUsuario
            };

            var usuarioCreado = await _repositorio.Registrar(usuarioCrear, usuario.Password);
            return StatusCode(201);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login (UsuarioLogin usuario)
        {
            var usuarioRepositorio = await _repositorio.Login(usuario.NombreUsuario, usuario.Password);
            if (usuarioRepositorio == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,usuarioRepositorio.Id.ToString()),
                new Claim(ClaimTypes.Name,usuarioRepositorio.NombreUsuario)
            };

            var llave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuracion.GetSection("Appsettings:Token").Value));
            var credenciales = new SigningCredentials(llave, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = System.DateTime.Now.AddDays(1),
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}