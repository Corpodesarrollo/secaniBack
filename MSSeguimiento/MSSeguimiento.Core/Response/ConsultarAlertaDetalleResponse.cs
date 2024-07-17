using MSSeguimiento.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Core.Response
{
    public class ConsultarAlertaDetalleResponse
    {
        public long EntidadId { get; set; }
        public string EntidadNombre { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Asunto { get; set; }
        public DateTime FechaRespuesta {  get; set; } 
    }
}
