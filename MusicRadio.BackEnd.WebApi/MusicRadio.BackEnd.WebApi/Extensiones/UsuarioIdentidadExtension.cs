using System.Security.Claims;
using System.Security.Principal;

namespace MusicRadio.BackEnd.WebApi.Extensiones
{
    public static class UsuarioIdentidadExtension
    {
        public static string GetUserId(this IPrincipal user)
        {
            var claim = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.NameIdentifier);
            return claim == null ? null : claim.Value;
        }
    }
}
