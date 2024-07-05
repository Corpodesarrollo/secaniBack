using Microsoft.EntityFrameworkCore;
using MSEntidad.Core.Modelos;

namespace MSEntidad.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<ContactoEntidad> ContactoEntidades { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Notificacion> Notificacions { get; set; }
    }
}
