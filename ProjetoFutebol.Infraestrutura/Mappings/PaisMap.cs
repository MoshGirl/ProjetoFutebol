using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Infraestrutura.Mappings
{
    public class PaisMap : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder.ToTable("Paises");

            builder.HasKey(p => p.PaisID);

            builder.Property(p => p.NomePais)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(p => p.CodigoPais)
                   .HasMaxLength(15)
                   .IsRequired();
        }
    }
}