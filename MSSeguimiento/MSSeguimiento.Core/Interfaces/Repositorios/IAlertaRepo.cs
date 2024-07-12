using MSSeguimiento.Core.Modelos;
using MSSeguimiento.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Core.Interfaces.Repositorios
{
    public interface IAlertaRepo
    {
        public string CrearAlertaSeguimiento(CrearAlertaSeguimientoRequest request);
        public string GestionarAlerta(GestionarAlertaRequest request);
        public List<AlertaSeguimiento> ConsultarAlertaSeguimiento(ConsultarAlertasRequest request);

        public List<AlertaSeguimiento> ConsultarAlertaEstados(ConsultarAlertasEstadosRequest request);
    }
}
