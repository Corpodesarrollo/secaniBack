using MSSeguimiento.Core.Interfaces.Repositorios;
using MSSeguimiento.Core.Modelos;
using MSSeguimiento.Core.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Infra.Repositorios
{
    public class NotificacionRepo : INotificacionRepo
    {
        private readonly ApplicationDbContext _context;

        public NotificacionRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<GetNotificacionResponse> GetNotificacionUsuario(string AgenteDestinoId)
        {
            List<GetNotificacionResponse> response = (from un in _context.NotificacionesUsuarios
                                                      join uDestino in _context.AspNetUsers on un.AgenteDestinoId equals uDestino.Id
                                                      join uOrigen in _context.AspNetUsers on un.AgenteDestinoId equals uOrigen.Id
                                                      where un.AgenteDestinoId == AgenteDestinoId && !un.IsDeleted
                                                            select new GetNotificacionResponse()
                                                            {
                                                                TextoNotificacion = string.Join("","El Agente de seguimiento ",uOrigen.FullName,
                                                                " le ha asignado el caso No. ",un.SeguimientoId)
                                                            }).ToList();

            return response;
        }

        public int GetNumeroNotificacionUsuario(string AgenteDestinoId)
        {
            List<GetNotificacionResponse> response = (from un in _context.NotificacionesUsuarios
                                                      join uDestino in _context.AspNetUsers on un.AgenteDestinoId equals uDestino.Id
                                                      join uOrigen in _context.AspNetUsers on un.AgenteDestinoId equals uOrigen.Id
                                                      where un.AgenteDestinoId == AgenteDestinoId && !un.IsDeleted
                                                      select new GetNotificacionResponse()
                                                      {
                                                          TextoNotificacion = string.Join("", "El Agente de seguimiento ", uOrigen.FullName,
                                                          " le ha asignado el caso No. ", un.SeguimientoId)
                                                      }).ToList();

            return response.Count;
        }
    }
}
