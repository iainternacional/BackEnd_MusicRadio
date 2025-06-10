using MusicRadio.BackEnd.Domain.Entities.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRadio.BackEnd.Application.Services.Seguridad
{
    public class ServicioSeguridad : IServicioSeguridad
    {
        readonly IRepositorio<ClienteVO> _usuarioRepositorio;

        public ServicioSeguridad(IRepositorio<ClienteVO> usuarioRepositorio)
        {

        }
    }
}
