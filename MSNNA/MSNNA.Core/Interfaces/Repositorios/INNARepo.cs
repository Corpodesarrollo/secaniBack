using MSNNA.Core.Dto;
using MSNNA.Core.Modelos;
using MSNNA.Core.Request;
using MSNNA.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSNNA.Core.Interfaces.Repositorios
{
    public interface INNARepo
    {
        public RespuestaResponse<ContactoNNA> CrearContactoNNA(ContactoNNA contactoNNA);

        public RespuestaResponse<ContactoNNA> ActualizarContactoNNA(ContactoNNA contactoNNA);

        public RespuestaResponse<ContactoNNA> ObtenerContactoPorId(long NNAId);

        public RespuestaResponse<FiltroNNADto> ConsultarNNAFiltro(FiltroNNARequest entrada);
    }
}
