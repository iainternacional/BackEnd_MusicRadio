using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRadio.BackEnd.Domain.Entities.Seguridad.ValueObjects
{
    public class UsuarioVO
    {
        public int IdUsuario { get; set; }
        public string CodUsuario { get; set; }
        public int IdTercero { get; set; }
        public string Identificacion { get; set; }
        public string Nombreusu { get; set; }
        public int ClaveOK { get; set; }
        public int IdEstado { get; set; }
        public string RutaImg { get; set; }
        public int IdSucursalDefecto { get; set; }
        public string Clave1 { get; set; }
        public string Email { get; set; }
        public int? TotalRegistros { get; set; }
    }
}
