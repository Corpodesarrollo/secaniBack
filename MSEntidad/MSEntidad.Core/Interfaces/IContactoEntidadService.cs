using MSEntidad.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MSEntidad.Core.Interfaces
{
    public interface IContactoEntidadService
    {
        //Queries
        Task<ContactoEntidadResponse> GetByIdAsync(long id, CancellationToken cancellationToken);
        Task<ContactoEntidadResponse> GetByEmailAsync(string email, CancellationToken cancellationToken);
        Task<IEnumerable<ContactoEntidadResponse>> GetAllAsync(CancellationToken cancellationToken);
        Task<(int totalRegistros, IEnumerable<ContactoEntidadResponse> registros)> GetByPageAsync(int pageIndex, int pageSize, string search, bool Ascending, PropertyInfo propertyInfo);

        //Commands
        Task<(bool, ContactoEntidadResponse)> AddAsync(ContactoEntidadRequest entity, CancellationToken cancellationToken);
        Task<(bool, ContactoEntidadResponse)> UpdateAsync(ContactoEntidadResponse entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(ContactoEntidadResponse entity, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(long id, CancellationToken cancellationToken);
    }
}
