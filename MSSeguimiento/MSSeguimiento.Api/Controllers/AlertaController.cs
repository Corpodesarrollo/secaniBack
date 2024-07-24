using Microsoft.AspNetCore.Mvc;
using MSSeguimiento.Core.Interfaces.Repositorios;
using MSSeguimiento.Core.Modelos;
using MSSeguimiento.Core.request;
using MSSeguimiento.Core.Request;
using MSSeguimiento.Core.response;
using MSSeguimiento.Infra.Repositorios;

namespace MSSeguimiento.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly IAlertaRepo alertaRepo;

        public AlertaController(IAlertaRepo alerta)
        {
            alertaRepo = alerta;
        }

        [HttpPost("CrearAlertaSeguimiento")]
        public string CrearAlerta(CrearAlertaSeguimientoRequest request)
        {
            return alertaRepo.CrearAlertaSeguimiento(request);
        }

        [HttpPost("GestionarAlerta")]
        public string GestionarAlerta(GestionarAlertaRequest request)
        {
            return alertaRepo.GestionarAlerta(request);
        }

        [HttpPost("ConsultarAlertasSeguimiento")]
        public List<AlertaSeguimiento> ConsultarAlertaSeguimiento(ConsultarAlertasRequest request)
        {
            return alertaRepo.ConsultarAlertaSeguimiento(request);
        }

        [HttpPost("ConsultarAlertasEstados")]
        public List<AlertaSeguimiento> ConsultarAlertaEstados(ConsultarAlertasEstadosRequest request)
        {
            return alertaRepo.ConsultarAlertaEstados(request);
        }
    }
}
