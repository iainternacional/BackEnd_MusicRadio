using MusicRadio.BackEnd.Domain.Entities.Seguridad;
using MusicRadio.BackEnd.Domain.Entities.Seguridad.ValueObjects;
using MusicRadio.BackEnd.Infrastructure.Framework.Instrumentation.Exceptions;
using MusicRadio.BackEnd.Infrastructure.Framework.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRadio.BackEnd.Application.Services.Seguridad
{
    public class ServicioSeguridad : IServicioSeguridad
    {
        readonly IRepository<ClienteVO> _usuarioRepositorio;

        public ServicioSeguridad(IRepository<ClienteVO> usuarioRepositorio)
        {
            this._usuarioRepositorio = usuarioRepositorio;
        }

        public Task<ClienteVO> Autenticar(string nombreUsuario, string clave)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(clave))
                    throw new UsuarioNoExisteException();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
