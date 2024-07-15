using Microsoft.AspNetCore.Mvc;
using MSNNA.Core.Interfaces.Repositorios;
using MSNNA.Core.Modelos;
using MSNNA.Core.Request;
using MSNNA.Core.Response;

namespace MSNNA.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NNAController : ControllerBase
    {
        private INNARepo _nNARepo;

        public NNAController(INNARepo nNARepo)
        {
            _nNARepo= nNARepo;
        }

        [HttpPost("ContactoNNACrear")]
        public RespuestaResponse<ContactoNNA> ContactoNNACrear(ContactoNNARequest request)
        {
            var contactoNNA = new ContactoNNA();
            contactoNNA.Nombres = request.Nombres;
            contactoNNA.ParentescoId = request.ParentescoId;
            contactoNNA.Email = request.Email;
            contactoNNA.Telefonos = request.Telefonos;
            contactoNNA.TelefnosInactivos = request.TelefnosInactivos;

            var response = _nNARepo.CrearContactoNNA(contactoNNA);
            return response; ;
        }

        [HttpPut("ContactoNNAActualizar")]
        public RespuestaResponse<ContactoNNA> ContactoNNAActualizar(ContactoNNARequest request)
        {
            var contactoNNA = new ContactoNNA();
            contactoNNA.Nombres= request.Nombres;
            contactoNNA.ParentescoId = request.ParentescoId;
            contactoNNA.Email = request.Email;
            contactoNNA.Telefonos = request.Telefonos;
            contactoNNA.TelefnosInactivos = request.TelefnosInactivos;

            var response = _nNARepo.ActualizarContactoNNA(contactoNNA);
            return response;
        }

        [HttpGet("ContactoNNAGetById/{id}")]
        public RespuestaResponse<ContactoNNA> ContactoNNAGetById(long id)
        {
            var response = _nNARepo.ObtenerContactoPorId(id);
            return response;
        }

        [HttpPost("ConsultarNNAFiltro")]
        public RespuestaResponse<FiltroNNA> ConsultarNNAFiltro(FiltroNNARequest request)
        {
            var response = _nNARepo.ConsultarNNAFiltro(request);
            return response; ;
        }
    }
}
