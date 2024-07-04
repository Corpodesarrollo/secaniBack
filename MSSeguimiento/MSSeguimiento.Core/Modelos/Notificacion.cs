using MSSeguimiento.Core.Modelos.Common;

namespace MSSeguimiento.Core.Modelos
{
    public class Notificacion : BaseEntity
    {
        public long AlertaSeguimientoId { get; set; }
        public DateTime FechaNotificacion { get; set; }
        public DateTime FechaRespuesta { get; set; }
        public string RespuestaEntidad { get; set; }
        public long EntidadId { get; set; }
    }
}
