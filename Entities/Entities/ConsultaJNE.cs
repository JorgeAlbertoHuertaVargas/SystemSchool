using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
  public  class ConsultaJNE
    {
       public string mensajeRespuesta { get; set; }

        public static implicit operator Task<object>(ConsultaJNE v)
        {
            throw new NotImplementedException();
        }

        public class DatoJNESolictud
        {
            public string CODDNI { get; set; }
        }
        public class DatoJNERespuesta
        {
            public string data { get; set; }
            public bool success { get; set; }
            public string mensaje { get; set; }

            public static implicit operator DatoJNERespuesta(string v)
            {
                throw new NotImplementedException();
            }
        }

        public class DatoExterno1Solicitud
        {
            public string _token { get; set; }
            public string dni { get; set; }
        }
    }
}
