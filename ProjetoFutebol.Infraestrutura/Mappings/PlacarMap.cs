using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ProjetoFutebol.Dominio.Entidades
{
    public class PlacarMap : IEntityTypeConfiguration<Placar>
    {
        public void Configure(EntityTypeBuilder<Placar> builder)
        {
            builder.ToTable("Placares");

            builder.HasKey(p => p.PlacarID);

            builder.Property(p => p.PlacarVisitante)
                   .IsRequired();

            builder.Property(p => p.PlacarTimeDaCasa)
                   .IsRequired();

            builder.HasOne(p => p.Partida)
                   .WithOne(pt => pt.Placar)
                   .HasForeignKey<Placar>(p => p.PartidaID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Vencedor)
                   .WithMany()
                   .HasForeignKey(p => p.VencedorID)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}