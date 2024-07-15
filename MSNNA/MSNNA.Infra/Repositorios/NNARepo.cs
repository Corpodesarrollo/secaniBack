using Microsoft.EntityFrameworkCore;
using MSNNA.Core.Interfaces.Repositorios;
using MSNNA.Core.Response;
using MSNNA.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MSNNA.Core.Request;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data.Common;

namespace MSNNA.Infra.Repositorios
{
    public class NNARepo : INNARepo
    {
        private readonly ApplicationDbContext _context;

        public NNARepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public RespuestaResponse<ContactoNNA> CrearContactoNNA(ContactoNNA contactoNNA)
        {
            var response = new RespuestaResponse<ContactoNNA>();

            try
            {
                _context.Set<ContactoNNA>().Add(contactoNNA);
                _context.SaveChangesAsync();
                response.Estado = true;
                response.Descripcion = "Contacto creado con éxito.";
                response.Datos = null;  // Aquí puedes devolver el objeto creado si es necesario.
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Descripcion = $"Error al crear el contacto: {ex.Message}";
                response.Datos = null;
            }

            return response;
        }

        public RespuestaResponse<ContactoNNA> ActualizarContactoNNA(ContactoNNA contactoNNA)
        {
            var response = new RespuestaResponse<ContactoNNA>();

            try
            {
                _context.Set<ContactoNNA>().Update(contactoNNA);
                _context.SaveChangesAsync();
                response.Estado = true;
                response.Descripcion = "Contacto actualizado con éxito.";
                response.Datos = null;  // Aquí puedes devolver el objeto creado si es necesario.
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Descripcion = $"Error al actualizar el contacto: {ex.Message}";
                response.Datos = null;
            }

            return response;
        }

        public RespuestaResponse<ContactoNNA> ObtenerContactoPorId(long NNAId)
        {
            var response = new RespuestaResponse<ContactoNNA>();
            List<ContactoNNA> li = new List<ContactoNNA>();

            try
            {
                var contacto = _context.ContactoNNAs.Find(NNAId);

                if (contacto != null)
                {
                    response.Estado = true;
                    response.Descripcion = "Contacto obtenido con éxito.";
                    li.Add(contacto);
                    response.Datos = li;
                }
                else
                {
                    response.Estado = false;
                    response.Descripcion = "No se encontró el contacto con el ID especificado.";
                    response.Datos = null;
                }
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Descripcion = $"Error al obtener el contacto: {ex.Message}";
                response.Datos = null;
            }

            return response;
        }

        public RespuestaResponse<FiltroNNA> ConsultarNNAFiltro(FiltroNNARequest entrada)
        {
            var response = new RespuestaResponse<FiltroNNA>();
            List<FiltroNNA> lista = new List<FiltroNNA>();

            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@Estado", entrada.Estado),
                    new SqlParameter("@Agente", entrada.Agente ?? (object)DBNull.Value),
                    new SqlParameter("@Buscar", entrada.Buscar ?? (object)DBNull.Value),
                    new SqlParameter("@Orden", entrada.Orden)
                };

                var results = _context.FiltroNNAs.FromSqlRaw(
                    "EXEC dbo.sp_consulta_nna_filtro @Estado, @Agente, @Buscar, @Orden",
                    parameters
                ).ToList();
                if (results != null)
                {
                    response.Estado = true;
                    response.Descripcion = "Consulta realizada con éxito.";
                    response.Datos = results;
                }
                else
                {
                    response.Estado = true;
                    response.Descripcion = "No trae información.";
                    response.Datos = null;
                }
                
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Descripcion = $"Error al realizar la consulta: {ex.Message}";
                response.Datos = null;
            }

            return response;
        }
    }

}