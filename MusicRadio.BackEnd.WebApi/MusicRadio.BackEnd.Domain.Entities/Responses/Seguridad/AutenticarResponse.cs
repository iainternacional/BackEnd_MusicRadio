using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRadio.BackEnd.Domain.Entities.Responses.Seguridad
{
    public class AutenticarResponse : BaseResponse
    {
        public string Token { get; set; }
        public int IdUsuario { get; set; }
        public string CodUsuario { get; set; }
        public string Identificacion { get; set; }
        public string Nombreusu { get; set; }
        public int ClaveOK { get; set; }
        public int IdEstado { get; set; }
        public string RutaImg { get; set; }
        public int IdSucursalDefecto { get; set; }
        public string Email { get; set; }
    }
}
