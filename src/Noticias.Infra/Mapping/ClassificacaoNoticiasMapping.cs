using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaNoticias.Domain.Entities;

namespace SistemaNoticias.Infra.Mapping
{
    public class ClassificacaoNoticiasMapping : IEntityTypeConfiguration<ClassificacaoNoticias>
    {
        public void Configure(EntityTypeBuilder<ClassificacaoNoticias> builder)
        {
            builder.HasKey(a => new { a.NoticiaId, a.ClassificacaoId });
            builder.Property(a => a.NoticiaId)
                .IsRequired()
                .HasColumnName("NoticiaId");
            builder.Property(a => a.ClassificacaoId)
                .IsRequired()
                .HasColumnName("ClassificacaoId");

            builder.ToTable("ClassificacaoNoticias");
        }
    }
}
