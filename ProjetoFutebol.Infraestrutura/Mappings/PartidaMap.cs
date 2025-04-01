using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Infraestrutura.Mappings
{
    public class PartidaMap : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.ToTable("Partidas");

            builder.HasKey(p => p.PartidaID);

            builder.Property(p => p.DataPartida)
                   .IsRequired();

            builder.HasOne(p => p.Competicao)
                   .WithMany(c => c.Partidas)
                   .HasForeignKey(p => p.CompeticaoID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.TimeDaCasa)
                   .WithMany()
                   .HasForeignKey(p => p.TimeDaCasaID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.TimeVisitante)
                   .WithMany()
                   .HasForeignKey(p => p.TimeVisitanteID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Placar)
                   .WithOne(pl => pl.Partida)
                   .HasForeignKey<Placar>(pl => pl.PartidaID)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
