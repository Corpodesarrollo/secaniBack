using MSAuthentication.Core.Interfaces.Repositorios;
using MSAuthentication.Core.Modelos;
using MSAuthentication.Core.request;
using MSAuthentication.Core.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAuthentication.Infra.Repositorios
{
    public class PermisosRepo : IPermisosRepo
    {
        private readonly ApplicationDbContext _context;

        public PermisosRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<GetVwMenuResponse> MenuXRolId(GetVwMenuRequest request)
        {
            var dataResponse = _context.VwMenu
                                      .Where(v => v.RolId == request.RolId)
                                      .OrderBy(v => v.MenuOrden)
                                      .ThenBy(v => v.SubMenuOrden)
                                      .Select(v => new GetVwMenuResponse
                                      {
                                          PermisoId = v.PermisoId,
                                          ModuloId = v.ModuloId,
                                          ModuloIdPadre = v.ModuloIdPadre,
                                          Menu = v.Menu,
                                          MenuPath = v.MenuPath,
                                          SubMenu = v.SubMenu,
                                          SubMenuPath = v.SubMenuPath,
                                          Rol = v.Rol,
                                          RolId = v.RolId,
                                          ModuloTipo = v.ModuloTipo,
                                          ModuloTipoId = v.ModuloTipoId,
                                          MenuOrden = v.MenuOrden,
                                          SubMenuOrden = v.SubMenuOrden
                                      })
                                      .ToList();

            return dataResponse;
        }
    }
}
