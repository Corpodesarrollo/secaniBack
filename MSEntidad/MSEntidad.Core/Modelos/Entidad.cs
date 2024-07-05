using MSEntidad.Core.Modelos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEntidad.Core.Modelos
{
    public class Entidad: BaseEntity
    {
        public int TipoEntidadId { get; set; }
        public string Nombre { get; set; }
    }
}
