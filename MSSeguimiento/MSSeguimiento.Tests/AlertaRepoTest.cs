using Microsoft.EntityFrameworkCore;
using MSSeguimiento.Core.Modelos;
using MSSeguimiento.Core.response;
using MSSeguimiento.Infra.Repositorios;
using MSSeguimiento.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSSeguimiento.Core.Request;

namespace MSSeguimiento.Tests
{
    public class AlertaRepoTest
    {
        private AlertaRepo AlertaRepo;
        private readonly ApplicationDbContext Context;

        public AlertaRepoTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

            Context = new ApplicationDbContext(options);
            AlertaRepo = new AlertaRepo(Context);
        }

        [Fact]
        public void CrearAlerta_Exitoso()
        {
            Context.AspNetUsers.Add(new AspNetUsers { Id = "prueba3", FullName = "Giovanny Romero", Telefonos = "",UserName= "user.externo@yopmail.com" });

            Context.SaveChanges();
            // Inicializar datos de prueba
            CrearAlertaSeguimientoRequest request = new CrearAlertaSeguimientoRequest()
            {
                AlertaId = 1,
                EstadoId = 2,
                Observaciones = "observacion",
                SeguimientoId = 1,
                Username = "user.externo@yopmail.com"
            };
            string response = AlertaRepo.CrearAlertaSeguimiento(request);

            Assert.NotNull(response);
            Assert.Equal("Alerta creada exitosamente", response);
        }
    }
}
