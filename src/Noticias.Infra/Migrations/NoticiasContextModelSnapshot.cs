﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaNoticias.Infra.Data;

#nullable disable

namespace SistemaNoticias.Infra.Migrations
{
    [DbContext(typeof(NoticiasContext))]
    partial class NoticiasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaNoticias.Domain.Entities.Classificacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Classificacao", (string)null);
                });

            modelBuilder.Entity("SistemaNoticias.Domain.Entities.ClassificacaoNoticias", b =>
                {
                    b.Property<Guid>("NoticiaId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("NoticiaId");

                    b.Property<Guid>("ClassificacaoId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClassificacaoId");

                    b.HasKey("NoticiaId", "ClassificacaoId");

                    b.HasIndex("ClassificacaoId");

                    b.ToTable("ClassificacaoNoticias", (string)null);
                });

            modelBuilder.Entity("SistemaNoticias.Domain.Entities.Noticia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("varchar(3000)");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("date");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Noticias", (string)null);
                });

            modelBuilder.Entity("SistemaNoticias.Domain.Entities.ClassificacaoNoticias", b =>
                {
                    b.HasOne("SistemaNoticias.Domain.Entities.Classificacao", "Classificacao")
                        .WithMany()
                        .HasForeignKey("ClassificacaoId")
                        .IsRequired();

                    b.HasOne("SistemaNoticias.Domain.Entities.Noticia", "Noticia")
                        .WithMany("Classificacoes")
                        .HasForeignKey("NoticiaId")
                        .IsRequired();

                    b.Navigation("Classificacao");

                    b.Navigation("Noticia");
                });

            modelBuilder.Entity("SistemaNoticias.Domain.Entities.Noticia", b =>
                {
                    b.Navigation("Classificacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
