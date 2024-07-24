using MSSeguimiento.Core.Request;
using MSSeguimiento.Core.response;
using MSSeguimiento.Core.Response;
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
        public Task<string> EnviarOficioNotificacion(EnviarOficioNotifcacionRequest request);
        public VerOficioNotificacionResponse VerOficioNotificacion(VerOficioNotificacionRequest request);
    }
}
