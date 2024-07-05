using MSEntidad.Core.Modelos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSEntidad.Core.Modelos
{
    public class Notificacion: BaseEntity
    {
        public long AlertaSeguimientoId { get; set; }
        public DateTime FechaNotificacion { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public string RespuestaEntidad { get; set; }
        public long EntidadId { get; set; }
    }
}
