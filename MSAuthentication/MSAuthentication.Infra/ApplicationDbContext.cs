using Microsoft.EntityFrameworkCore;
using MSAuthentication.Core.Modelos;


namespace MSAuthentication.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<VwMenuModel> VwMenu { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la vista VwMenu como una entidad sin clave
            modelBuilder.Entity<VwMenuModel>(eb =>
            {
                eb.HasNoKey();
                eb.ToView("VwMenu"); // Esto es válido para versiones recientes de EF Core
            });
        }
    }
}