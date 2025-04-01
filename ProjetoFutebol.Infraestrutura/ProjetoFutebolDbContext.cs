using Microsoft.EntityFrameworkCore;
using ProjetoFutebol.Dominio.Entidades;
using ProjetoFutebol.Infraestrutura.Mappings;

namespace ProjetoFutebol.Infraestrutura
{
    public class ProjetoFutebolDbContext : DbContext
    {
        public ProjetoFutebolDbContext(DbContextOptions<ProjetoFutebolDbContext> options) : base(options)
        {
        }

        public DbSet<Competicao> Competicao { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
        public DbSet<EquipeCompeticao> EquipeCompeticao { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Partida> Partida { get; set; }
        public DbSet<Placar> Placar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompeticaoMap());
            modelBuilder.ApplyConfiguration(new EquipeMap());
            modelBuilder.ApplyConfiguration(new EquipeCompeticaoMap());
            modelBuilder.ApplyConfiguration(new PaisMap());
            modelBuilder.ApplyConfiguration(new PartidaMap());
            modelBuilder.ApplyConfiguration(new PlacarMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}