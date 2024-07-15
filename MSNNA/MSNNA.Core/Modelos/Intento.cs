using MSNNA.Core.Modelos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSNNA.Core.Modelos
{
    public class Intento : BaseEntity
    {
        public long ContactoNNAId { get; set; }
        public string Email { get; set; }
        public DateTime FechaIntento { get; set; }
        public string Telefono { get; set; }
        public int TipoResultadoIntentoId { get; set; }
        public int TipoFallaIntentoId { get; set; }
    }
}
