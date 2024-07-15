using MSSeguimiento.Core.Request;
using MSSeguimiento.Core.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Core.Interfaces.Repositorios
{
    public interface INotificacionRepo
    {
        public List<GetNotificacionResponse> GetNotificacionUsuario(string AgenteDestinoId);
        public int GetNumeroNotificacionUsuario(string AgenteDestinoId);
        public string GenerarOficioNotificacion(OficioNotificacionRequest request);
    }
}
