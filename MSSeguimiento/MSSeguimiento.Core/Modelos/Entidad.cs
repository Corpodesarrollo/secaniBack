using MSSeguimiento.Core.Modelos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Core.Modelos
{
    public class Entidad : BaseEntity
    {
        public int TipoEntidadId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<ContactoEntidad> ContactosEntidad { get; set; }
    }
}
