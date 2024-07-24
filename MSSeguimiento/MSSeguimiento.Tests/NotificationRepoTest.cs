using Microsoft.EntityFrameworkCore;
using MSSeguimiento.Core.Modelos;
using MSSeguimiento.Core.Request;
using MSSeguimiento.Core.response;
using MSSeguimiento.Core.Response;
using MSSeguimiento.Infra;
using MSSeguimiento.Infra.Repositorios;
using NSubstitute;
using System;
using Xunit;

namespace MSSeguimiento.Tests
{
    public class NotificationRepoTest
    {
        private readonly NotificacionRepo NotificacionRepo;
        private readonly ApplicationDbContext Context;

        public NotificationRepoTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

            Context = new ApplicationDbContext(options);
            NotificacionRepo = new NotificacionRepo(Context);
        } 

        [Fact]
        public void GetNotificacionUsuario_ReturnLista()
        {
            // Inicializar datos de prueba
            Context.AspNetUsers.Add(new AspNetUsers { Id = "prueba4", FullName = "Giovanny Romero", Telefonos = "" });

            Context.NotificacionesUsuarios.Add(new NotificacionesUsuario
            {
                AgenteDestinoId = "prueba1",
                AgenteOrigenId = "prueba1",
                SeguimientoId = 123,
                IsDeleted = false,
                Accion = "",
                CreatedByUserId = "giovanny.romero"
            });

            Context.SaveChanges();
            List<GetNotificacionResponse> response = NotificacionRepo.GetNotificacionUsuario("prueba1");

            Assert.NotNull(response);
            Assert.Single(response);
        }

        [Fact]
        public void GetNumeroNotificacionUsuario_ReturnUno()
        {
            Context.AspNetUsers.Add(new AspNetUsers { Id = "prueba3", FullName = "Giovanny Romero", Telefonos = "" });

            Context.NotificacionesUsuarios.Add(new NotificacionesUsuario
            {
                AgenteDestinoId = "prueba2",
                AgenteOrigenId = "prueba2",
                SeguimientoId = 123,
                IsDeleted = false,
                Accion = "",
                CreatedByUserId = "giovanny.romero"
            });

            Context.SaveChanges();
            int response = NotificacionRepo.GetNumeroNotificacionUsuario("prueba2");
            Assert.Equal(1, response);
        }
    }
}
