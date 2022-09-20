using Microsoft.EntityFrameworkCore;
using WepApiComputadoras.Entidades;

namespace WepApiComputadoras
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Computadora> Computadoras { get; set; }
        public DbSet<Caracteristicas> Caracteristicas { get; set; }
    }
}
