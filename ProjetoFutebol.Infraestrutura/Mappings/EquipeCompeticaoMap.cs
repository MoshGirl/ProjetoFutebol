using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProjetoFutebol.Dominio.Entidades;

namespace ProjetoFutebol.Infraestrutura.Mappings
{
    public class EquipeCompeticaoMap : IEntityTypeConfiguration<EquipeCompeticao>
    {
        public void Configure(EntityTypeBuilder<EquipeCompeticao> builder)
        {
            builder.ToTable("EquipesCompeticoes");

            builder.HasKey(ec => new { ec.EquipeID, ec.CompeticaoID });

            builder.HasOne(ec => ec.Equipe)
                   .WithMany(e => e.Competicoes)
                   .HasForeignKey(ec => ec.EquipeID);

            builder.HasOne(ec => ec.Competicao)
                   .WithMany(c => c.EquipesCompeticao)
                   .HasForeignKey(ec => ec.CompeticaoID);
        }
    }
}