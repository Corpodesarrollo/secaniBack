using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Core.Request
{
    public class CrearAlertaSeguimientoRequest
    {
        public int AlertaId { get; set; }
        public string Observaciones { get; set; }
        public string Username { get; set; }
        public int SeguimientoId { get; set; }
        public int EstadoId {  get; set; }
    }
}
