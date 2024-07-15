using Microsoft.EntityFrameworkCore;
using MSNNA.Core.Modelos;

namespace MSNNA.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Intento> Intentos { get; set; }
        public DbSet<ContactoNNA> ContactoNNAs { get; set; }
        public DbSet<NNA> NNAs { get; set; }
        public DbSet<FiltroNNA> FiltroNNAs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración para `ContactoNNA`
            modelBuilder.Entity<ContactoNNA>(entity =>
            {
                entity.HasKey(e => e.Id);
                // Configuración adicional
            });

            // Opción 1: Configurar `Intento` con clave primaria
            modelBuilder.Entity<Intento>(entity =>
            {
                entity.HasKey(e => e.Id);
                // Configuración adicional
            });

            modelBuilder.Entity<NNA>(entity =>
            {
                entity.HasKey(e => e.Id);
                // Configuración adicional
            });

            // Configuración para `FiltroNNA`
            modelBuilder.Entity<FiltroNNA>(entity =>
            {
                entity.HasNoKey();  // Si FiltroNNA es una entidad sin clave
                                    // Configuración adicional
            });
        }
    }
}
