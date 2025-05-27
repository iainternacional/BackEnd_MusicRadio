using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicRadio.BackEnd.Domain.Entities.Responses
{
    public class BaseResponse
    {
        public bool Error { get; set; }
        public string MensajeError { get; set; }
        public string ErrorInterno { get; set; }
        public int StatusCode { get; set; }
    }
    public class Response : BaseResponse
    {

        public object Data { get; set; }

    }
}
