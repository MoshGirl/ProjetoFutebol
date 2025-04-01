using Microsoft.EntityFrameworkCore;
using ProjetoFutebol.Dominio.Entidades.TimeModels;

namespace ProjetoFutebol.Infraestrutura
{
    public class ProjetoFutebolDbContext : DbContext
    {
        public ProjetoFutebolDbContext(DbContextOptions<ProjetoFutebolDbContext> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<AreaFilha> AreaFilhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Area>();
            modelBuilder.Entity<AreaFilha>();
        }
    }
}