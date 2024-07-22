using MSSeguimiento.Core.Modelos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Core.Modelos
{
    public class ContactoEntidad : BaseEntity
    {
        public long EntidadId { get; set; }
        public string Nombres { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
        public string Telefonos { get; set; }
        public bool Activo { get; set; }
        public virtual Entidad Entidad { get; set; }
    }
}
