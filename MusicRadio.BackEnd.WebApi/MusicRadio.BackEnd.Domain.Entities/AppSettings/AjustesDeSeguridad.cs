using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRadio.BackEnd.Domain.Entities.AppSettings
{
    public class AjustesDeSeguridad
    {
        public string Secret { get; set; }
        public bool TestMode { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenExpirationTime { get; set; }
    }
}
