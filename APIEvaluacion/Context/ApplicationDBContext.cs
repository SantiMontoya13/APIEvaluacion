using Microsoft.EntityFrameworkCore;
using APIEvaluacion.Entities;

namespace APIEvaluacion.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext() { }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>
            options) : base(options) { }
        public DbSet<Destinatario> Destinatario { get; set; }
        public DbSet<Paquete> Paquete { get; set; }
    }
}
