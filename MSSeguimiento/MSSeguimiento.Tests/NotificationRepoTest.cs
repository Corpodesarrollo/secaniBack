using Microsoft.EntityFrameworkCore;
using MSSeguimiento.Core.Modelos;
using MSSeguimiento.Core.response;
using MSSeguimiento.Infra;
using MSSeguimiento.Infra.Repositorios;
using NSubstitute;
using System;
using Xunit;

namespace MSSeguimiento.Tests
{
    public class NotificationRepoTest
    {
        private NotificacionRepo notificacionRepo;
        private readonly ApplicationDbContext context;

        public NotificationRepoTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

            context = new ApplicationDbContext(options);
            notificacionRepo = new NotificacionRepo(context);
        } 

        [Fact]
        public void GetNotificacionUsuario_ReturnLista()
        {
            // Inicializar datos de prueba
            context.AspNetUsers.Add(new AspNetUsers { Id = "prueba1", FullName = "Giovanny Romero", Telefonos = "" });

            context.NotificacionesUsuarios.Add(new NotificacionesUsuario
            {
                AgenteDestinoId = "prueba1",
                AgenteOrigenId = "prueba1",
                SeguimientoId = 123,
                IsDeleted = false,
                Accion = "",
                CreatedByUserId = "giovanny.romero"
            });

            context.SaveChanges();
            List<GetNotificacionResponse> response = notificacionRepo.GetNotificacionUsuario("prueba1");

            Assert.NotNull(response);
            Assert.Equal(1, response.Count());
        }

        [Fact]
        public void GetNumeroNotificacionUsuario_ReturnUno()
        {
            context.AspNetUsers.Add(new AspNetUsers { Id = "prueba2", FullName = "Giovanny Romero", Telefonos = "" });

            context.NotificacionesUsuarios.Add(new NotificacionesUsuario
            {
                AgenteDestinoId = "prueba2",
                AgenteOrigenId = "prueba2",
                SeguimientoId = 123,
                IsDeleted = false,
                Accion = "",
                CreatedByUserId = "giovanny.romero"
            });

            context.SaveChanges();
            int response = notificacionRepo.GetNumeroNotificacionUsuario("prueba2");
            Console.WriteLine("la cantidad de notificaciones es ="+response);
            Assert.Equal(1, response);
        }
    }
}
