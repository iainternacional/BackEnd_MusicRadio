using MusicRadio.BackEnd.Domain.Entities.Seguridad.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRadio.BackEnd.Application.Services.Seguridad
{
    public interface IServicioSeguridad
    {
        Task<ClienteVO> Autenticar(string nombreUsuario, string clave);
    }
}
