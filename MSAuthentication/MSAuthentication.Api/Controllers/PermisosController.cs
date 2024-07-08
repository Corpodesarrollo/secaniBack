using Microsoft.AspNetCore.Mvc;
using MSAuthentication.Core.Interfaces.Repositorios;
using MSAuthentication.Core.request;
using MSAuthentication.Core.response;

namespace MSAuthentication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermisosController : ControllerBase
    {
        private IPermisosRepo permisosRepo;

        public PermisosController(IPermisosRepo _permisos)
        {
            permisosRepo = _permisos;
        }
        [HttpPost("MenuXRolId")]
        public List<GetVwMenuResponse> MenuXRolId(GetVwMenuRequest request)
        {
            List<GetVwMenuResponse> response = new List<GetVwMenuResponse>();

            response = permisosRepo.MenuXRolId(request);

            return response;
        }
    }
}
