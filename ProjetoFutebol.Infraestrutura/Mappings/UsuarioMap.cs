using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Infraestrutura.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(c => c.UsuarioID);

            builder.Property(c => c.Email)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(c => c.SenhaHash)
                   .IsRequired();
        }
    }
}