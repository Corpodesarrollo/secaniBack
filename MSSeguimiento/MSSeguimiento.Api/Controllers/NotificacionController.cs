﻿using Microsoft.AspNetCore.Mvc;
using MSSeguimiento.Core.Interfaces.Repositorios;
using MSSeguimiento.Core.request;
using MSSeguimiento.Core.response;

namespace MSSeguimiento.Api.Controllers
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
