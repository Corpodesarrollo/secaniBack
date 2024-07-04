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
    }
}
