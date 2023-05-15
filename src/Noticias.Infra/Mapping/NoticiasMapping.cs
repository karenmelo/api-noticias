using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNoticias.Domain.Entities;

namespace SistemaNoticias.Infra.Mapping
{
    public class NoticiasMapping : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(x => x.Conteudo)
                   .IsRequired()
                   .HasColumnType("varchar(3000)");

            builder.Property(x => x.DataCadastro)
                   .HasColumnType("date");

            builder.HasMany(e => e.Classificacoes)
                  .WithOne(e => e.Noticia)
                  .HasPrincipalKey(e => e.Id);

            builder.ToTable("Noticias");
        }
    }
}
