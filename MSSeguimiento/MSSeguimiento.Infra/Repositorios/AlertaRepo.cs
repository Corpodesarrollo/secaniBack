using MSSeguimiento.Core.Interfaces.Repositorios;
using MSSeguimiento.Core.Modelos;
using MSSeguimiento.Core.Request;
using MSSeguimiento.Core.response;
using MSSeguimiento.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Infra.Repositorios
{
    public class AlertaRepo:IAlertaRepo
    {
        private readonly ApplicationDbContext _context;

        public AlertaRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public string CrearAlertaSeguimiento(CrearAlertaSeguimientoRequest request)
        {
            try
            {
                AspNetUsers? user = (from users in _context.AspNetUsers 
                                     where users.UserName == request.Username
                                     select users).FirstOrDefault();

                if (user == null)
                {
                    return "Usuario no encontrado";
                }
                else
                {
                    AlertaSeguimiento alertaSeguimiento = new AlertaSeguimiento()
                    {
                        CreatedByUserId = user.Id,
                        DateCreated = new DateTime(),
                        EstadoId = request.EstadoId,
                        AlertaId = request.AlertaId,
                        Observaciones = request.Observaciones,
                        SeguimientoId = request.SeguimientoId,
                        UltimaFechaSeguimiento = new DateTime(),
                    };

                    _context.AlertaSeguimientos.Add(alertaSeguimiento);
                    _context.SaveChanges();

                    return "Alerta creada exitosamente";
                }
            }
            catch (Exception ex)
            {
                return "Se presento un problema al crear la alerta";
            }
        }

        public string GestionarAlerta(GestionarAlertaRequest request)
        {
            try
            {
                AspNetUsers? user = (from users in _context.AspNetUsers
                                     where users.UserName == request.UserName
                                     select users).FirstOrDefault();

                if (user == null)
                {
                    return "Usuario no encontrado";
                }
                else
                {
                    AlertaSeguimiento? seguimiento = (from aSeguimiento in _context.AlertaSeguimientos
                                                     where aSeguimiento.Id == request.IdSeguimiento
                                                     select aSeguimiento).FirstOrDefault();

                    if (seguimiento == null)
                    {
                        AlertaSeguimiento alertaSeguimiento = new AlertaSeguimiento()
                        {
                            AlertaId = request.IdAlerta,
                            CreatedByUserId = user.Id,
                            DateCreated = new DateTime(),
                            EstadoId = request.IdEstado,
                            Observaciones = request.Observacion,
                            UltimaFechaSeguimiento = new DateTime()
                        };
                        _context.AlertaSeguimientos.Add(alertaSeguimiento);
                        _context.SaveChanges();

                        return "Seguimiento registrado exitosamente";
                    }
                    else
                    {
                        seguimiento.Observaciones = request.Observacion;
                        seguimiento.EstadoId = request.IdEstado;
                        seguimiento.DateUpdated = new DateTime();
                        seguimiento.UltimaFechaSeguimiento = new DateTime();
                        seguimiento.UpdatedByUserId = user.Id;

                        _context.Update(seguimiento);
                        _context.SaveChanges();

                        return "Seguimiento actualizado exitosamente";
                    }

                }
            } catch (Exception ex) {
                return "Se presento un problema al gestionar el seguimiento";
            }
        }

        public List<AlertaSeguimiento> ConsultarAlertaSeguimiento(ConsultarAlertasRequest request)
        {
            List<AlertaSeguimiento> response = (from aseg in _context.AlertaSeguimientos
                                                where aseg.SeguimientoId == request.IdSeguimiento
                                                select aseg).ToList();

            return response;
        }

        public List<ConsultarAlertaEstadoResponse> ConsultarAlertaEstados(ConsultarAlertasEstadosRequest request)
        {
            List<ConsultarAlertaEstadoResponse> alertasSeguimiento = (from aseg in _context.AlertaSeguimientos
                                                                      where request.estados.Contains(aseg.EstadoId)
                                                                      select new ConsultarAlertaEstadoResponse()
                                                                      {
                                                                          AlertaId = aseg.AlertaId,
                                                                          EstadoId = aseg.EstadoId,
                                                                          Observaciones = aseg.Observaciones,
                                                                          SeguimientoId = aseg.SeguimientoId,
                                                                          UltimaFechaSeguimiento = aseg.UltimaFechaSeguimiento,
                                                                          AlertaSeguimientoId = aseg.Id
                                                                      }).ToList();

            foreach(ConsultarAlertaEstadoResponse consultarAlertaEstadoResponse in alertasSeguimiento)
            {
                consultarAlertaEstadoResponse.consultarAlertaDetalles = (from notent in _context.NotificacionesEntidad
                                                                         join ent in _context.Entidades on notent.EntidadId equals ent.Id
                                                                         where notent.AlertaSeguimientoId == consultarAlertaEstadoResponse.AlertaSeguimientoId
                                                                         select new ConsultarAlertaDetalleResponse()
                                                                         {
                                                                             Asunto = notent.Asunto,
                                                                             EntidadId = notent.EntidadId,
                                                                             EntidadNombre = ent.Nombre,
                                                                             FechaEnvio = notent.FechaEnvio
                                                                         }).ToList();
            }




            return alertasSeguimiento;
        }
    }
}
