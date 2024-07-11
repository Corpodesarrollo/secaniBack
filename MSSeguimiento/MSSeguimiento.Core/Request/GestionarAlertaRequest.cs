using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Core.Request
{
    public class GestionarAlertaRequest
    {
        public int IdAlerta { get; set; }
        public string UserName { get; set; }
        public int IdEstado { get; set; }
        public string Observacion { get; set; }
        public int IdSeguimiento { get; set; }
    }
}
