using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MusicRadio.BackEnd.Domain.Entities.AppSettings;
using MusicRadio.BackEnd.Domain.Entities.Requests.Seguridad;
using MusicRadio.BackEnd.Domain.Entities.Responses.Seguridad;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using System.Net;
using MusicRadio.BackEnd.Infrastructure.Framework.Instrumentation.Exceptions;

namespace MusicRadio.BackEnd.WebApi.Controllers.Security
{
    [Route("api/seguridad/[controller]")]
    [ApiController]
    public class SeguridadController : BaseController
    {
        readonly AjustesDeSeguridad _ajustesDeSeguridad;
        readonly IMapper _mapper;
        readonly IServicioSeguridad _servicioSeguridad;
        public SeguridadController(IServicioSeguridad servicioSeguridad,
            AjustesDeSeguridad ajustesDeSeguridad, IMapper mapper)
        {
            this._ajustesDeSeguridad = ajustesDeSeguridad;
            this._mapper = mapper;

        }

        [HttpPost("autenticar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] AutenticarRequest usuarioRequest)
        {
            AutenticarResponse respuestaAutenticar;
            try
            {
                var usuario = await _servicioSeguridad.Autenticar(usuarioRequest.NombreUsuario, usuarioRequest.Password);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_ajustesDeSeguridad.Secret));
                var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuarioRequest.NombreUsuario)

                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: _ajustesDeSeguridad.Issuer,
                    audience: _ajustesDeSeguridad.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_ajustesDeSeguridad.TokenExpirationTime),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                respuestaAutenticar = _mapper.Map<AutenticarResponse>(usuario);

                respuestaAutenticar.CodUsuario = usuarioRequest.NombreUsuario;
                respuestaAutenticar.Token = tokenString;
                respuestaAutenticar.StatusCode = (int)HttpStatusCode.OK;
            }
            catch (UsuarioNoExisteException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "Usuario o clave incorrectos.");
            }
            catch (UsuarioInvalidoException)
            {
                return StatusCode((int)HttpStatusCode.NotFound, "Usuario o clave incorrectos.");
            }

            return Ok(respuestaAutenticar);
        }
    }
}
