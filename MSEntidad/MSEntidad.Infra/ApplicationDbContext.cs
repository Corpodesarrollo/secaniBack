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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<ContactoEntidad>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    var entity = entry.Entity;
                    entity.DateCreated = DateTime.UtcNow;
                    entity.CreatedByUserId = "1";
                    entity.IsDeleted = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    var entity = entry.Entity;
                    entity.DateUpdated = DateTime.UtcNow;
                    entity.UpdatedByUserId = "2";
                }

                if (entry.State == EntityState.Deleted)
                {
                    var entity = entry.Entity;
                    entity.DateDeleted = DateTime.UtcNow;
                    entity.DeletedByUserId = "3";
                    entity.IsDeleted = true;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
