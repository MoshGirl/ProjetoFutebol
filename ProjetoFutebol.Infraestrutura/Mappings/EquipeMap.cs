using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Infraestrutura.Mappings
{
    public class EquipeMap : IEntityTypeConfiguration<Equipe>
    {
        public void Configure(EntityTypeBuilder<Equipe> builder)
        {
            builder.ToTable("Equipes");

            builder.HasKey(e => e.EquipeID);

            builder.Property(e => e.NomeEquipe)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(e => e.NomeAbreviado)
                   .HasMaxLength(50);

            builder.Property(e => e.Sigla)
                   .HasMaxLength(10);

            builder.Property(e => e.Escudo)
                   .HasMaxLength(255);
        }
    }
}