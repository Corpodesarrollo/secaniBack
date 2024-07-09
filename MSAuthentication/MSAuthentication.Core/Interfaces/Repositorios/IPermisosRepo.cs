using MSAuthentication.Core.request;
using MSAuthentication.Core.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAuthentication.Core.Interfaces.Repositorios
{
    public interface IPermisosRepo
    {
        public List<GetVwMenuResponse> MenuXRolId(GetVwMenuRequest request);
    }
}
