using Microsoft.EntityFrameworkCore;
using MSSeguimiento.Core.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguimiento.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Alerta> Alertas { get; set; }
        public DbSet<AlertaSeguimiento> AlertaSeguimientos { get; set; }
        public DbSet<Notificacion> Notificacions { get; set; }
         public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<UsuarioAsignado> UsuarioAsignados { get; set; }
        public DbSet<NotificacionesUsuario> NotificacionesUsuarios { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }
    }
}
