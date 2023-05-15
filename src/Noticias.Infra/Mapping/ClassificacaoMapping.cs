using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNoticias.Domain.Entities;

namespace SistemaNoticias.Infra.Mapping
{
    public class ClassificacaoMapping : IEntityTypeConfiguration<Classificacao>
    {
        public void Configure(EntityTypeBuilder<Classificacao> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(50)");

            builder.ToTable("Classificacao");
        }
    }
}
