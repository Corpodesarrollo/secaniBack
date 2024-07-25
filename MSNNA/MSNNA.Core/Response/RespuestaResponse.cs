using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSNNA.Core.Response
{
    public class RespuestaResponse<T>
    {
        public bool? Estado;
        public string? Descripcion;
        public List<T>? Datos;
    }
}
