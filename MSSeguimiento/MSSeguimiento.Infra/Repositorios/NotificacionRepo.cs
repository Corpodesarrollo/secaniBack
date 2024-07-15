using MSSeguimiento.Core.Interfaces.Repositorios;
using MSSeguimiento.Core.Modelos;
using MSSeguimiento.Core.Request;
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
                                                      join uOrigen in _context.AspNetUsers on un.AgenteOrigenId equals uOrigen.Id
                                                      where un.AgenteDestinoId == AgenteDestinoId && !un.IsDeleted
                                                      select new GetNotificacionResponse()
                                                      {
                                                          TextoNotificacion = string.Join("", "El Agente de seguimiento ", uOrigen.FullName ?? string.Empty,
                                                          " le ha asignado el caso No. ", un.SeguimientoId.ToString() ?? "N/A")
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

        public string GenerarOficioNotificacion(OficioNotificacionRequest request)
        {
            NotificacionEntidad? notificacionEntidad = (from ne in _context.NotificacionesEntidad
                                                       where ne.Id == request.Id
                                                       select ne).FirstOrDefault();

            Entidad? entidad = (from ent in _context.Entidades
                               where ent.Id == request.IdEntidad
                               select ent).FirstOrDefault();

            AlertaSeguimiento? alerta = (from als in _context.AlertaSeguimientos
                                        where als.Id == request.IdAlertaSeguimiento
                                        select als).FirstOrDefault();

            NNA? nna = (from Tnna in _context.NNAs
                        where Tnna.Id == request.IdNNA
                        select Tnna).FirstOrDefault();


            if (entidad == null) {
                return "La entidad no existe";
            }

            if (alerta == null) {
                return "La alerta no existe";
            }
            
            if(notificacionEntidad == null)
            {
                notificacionEntidad = new NotificacionEntidad();
            }

            notificacionEntidad.EntidadId = request.IdEntidad;
            notificacionEntidad.Entidad = entidad;
            notificacionEntidad.Ciudad = request.Ciudad;
            notificacionEntidad.AlertaSeguimiento = alerta;
            notificacionEntidad.Asunto = request.Asunto;
            notificacionEntidad.Cierre = request.Cierre;
            notificacionEntidad.CiudadEnvio = request.CiudadEnvio;
            notificacionEntidad.FechaEnvio = request.FechaEnvio;
            notificacionEntidad.Membrete = request.Membrete;
            notificacionEntidad.Ciudad = request.Ciudad;
            notificacionEntidad.Mensaje = request.Mensaje;
            notificacionEntidad.Comentario = request.Comentario;
            notificacionEntidad.NNA = nna;
            notificacionEntidad.Firmajpg = request.FirmaJpg;

            return "Oficio creado correctamente";
        }

    }
}
