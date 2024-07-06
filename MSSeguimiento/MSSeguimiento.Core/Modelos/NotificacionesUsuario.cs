using MSSeguimiento.Core.Modelos.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Core.Modelos
{
    [Table("NotificacionesUsuario")]
    public class NotificacionesUsuario : BaseEntity
    {
        //Enum
        public int TipoNotificacionId { get; set; }
        //Nro de Caso
        public long SeguimientoId { get; set; }
        //UsuarioId del agente origen
        public string AgenteOrigenId { get; set; }
        // UsuarioId del agente destino
        public string AgenteDestinoId { get; set; }
        public DateTime FechaNotificacion { get; set; }
        public string Accion { get; set; }
        public bool CoordinadorOAdministrador { get; set; }
    }
}
