using Microsoft.EntityFrameworkCore;
using MSSeguimiento.Infra;

namespace MSSeguimiento.Api.Extensions
{
    internal static class StartupExtensions
    {
        public static WebApplicationBuilder CustomConfigureServices(this WebApplicationBuilder pBuilder)
        {
            //registrar el dbcontext y las interfaces
            pBuilder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(pBuilder.Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            ));

            return pBuilder;
        }
    }
}
