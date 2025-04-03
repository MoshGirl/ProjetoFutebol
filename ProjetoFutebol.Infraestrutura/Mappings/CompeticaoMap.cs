using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Infraestrutura.Mappings
{
    public class CompeticaoMap : IEntityTypeConfiguration<Competicao>
    {
        public void Configure(EntityTypeBuilder<Competicao> builder)
        {
            builder.ToTable("Competicoes");

            builder.HasKey(c => c.CompeticaoID);

            builder.Property(c => c.NomeCompeticao)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Codigo)
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(c => c.Emblema);

            builder.HasOne(c => c.Pais)
                   .WithMany(p => p.Competicoes)
                   .HasForeignKey(c => c.PaisID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}