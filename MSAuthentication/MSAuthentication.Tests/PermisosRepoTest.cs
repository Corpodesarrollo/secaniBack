using Microsoft.EntityFrameworkCore;
using MSAuthentication.Core.Modelos;
using MSAuthentication.Core.request;
using MSAuthentication.Core.response;
using MSAuthentication.Infra;
using MSAuthentication.Infra.Repositorios;
using NSubstitute;
using System;
using Xunit;

namespace MSAuthentication.Tests
{
    public class PermisosRepoTest
    {
        private PermisosRepo permisosRepo;
        private readonly ApplicationDbContext context;

        public PermisosRepoTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;

            context = new ApplicationDbContext(options);
            permisosRepo = new PermisosRepo(context);
        }

        [Fact]
        public void MenuXRolId_ReturnList()
        {
            // Inicializar datos de prueba
            var request = new GetVwMenuRequest
            {
                RoleId = "14CDDEA5-FA06-4331-8359-036E101C5046"
            };


            List<GetVwMenuResponse> response = permisosRepo.MenuXRolId(request);

            foreach (var item in response)
            {
                Console.WriteLine($"{item.PermisoId} - {item.MenuId} - {item.MenuNombre} - {item.MenuPath} - {item.MenuIcon} ");
            }
            Console.WriteLine($"Total lista MenuXRolId_ReturnList: {response.Count()}");
            Assert.NotNull(response);
            Assert.True(response.Count() > 0);
        }

    }
}
