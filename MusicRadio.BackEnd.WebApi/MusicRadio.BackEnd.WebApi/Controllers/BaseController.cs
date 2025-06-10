using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MusicRadio.BackEnd.WebApi.Extensiones;
using System;

namespace MusicRadio.BackEnd.WebApi.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-CO");
        }
        
        public int IdUsuario
        {
            get
            {
                return !string.IsNullOrEmpty(User.GetUserId()) ? Convert.ToInt32(User.GetUserId()) : 0;
            }
        }

    }
}
