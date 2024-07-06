using Microsoft.AspNetCore.Mvc;
using MSAuthentication.Core.Interfaces.Repositorios;
using MSAuthentication.Core.request;
using MSAuthentication.Core.response;

namespace MSAuthentication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificacionController : ControllerBase
    {
        private INotificacionRepo notificacionRepo;

        public NotificacionController(INotificacionRepo notificacion)
        {
            notificacionRepo = notificacion;
        }
        [HttpPost("GetNotification")]
        public List<GetNotificacionResponse> GetNotifications(GetNotificacionRequest request)
        {
            List<GetNotificacionResponse> response = new List<GetNotificacionResponse>();

            response = notificacionRepo.GetNotificacionUsuario(request.AgenteDestinoId);

            return response;
        }

        [HttpPost("GetNumeroNotification")]
        public int GetNumeroNotifications(GetNotificacionRequest request)
        {
            return notificacionRepo.GetNumeroNotificacionUsuario(request.AgenteDestinoId);
        }
    }
}
