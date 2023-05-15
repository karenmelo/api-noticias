using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaNoticias.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classificacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classificacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Noticias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Conteudo = table.Column<string>(type: "varchar(3000)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Noticias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassificacaoNoticias",
                columns: table => new
                {
                    NoticiaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassificacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificacaoNoticias", x => new { x.NoticiaId, x.ClassificacaoId });
                    table.ForeignKey(
                        name: "FK_ClassificacaoNoticias_Classificacao_ClassificacaoId",
                        column: x => x.ClassificacaoId,
                        principalTable: "Classificacao",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClassificacaoNoticias_Noticias_NoticiaId",
                        column: x => x.NoticiaId,
                        principalTable: "Noticias",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassificacaoNoticias_ClassificacaoId",
                table: "ClassificacaoNoticias",
                column: "ClassificacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassificacaoNoticias");

            migrationBuilder.DropTable(
                name: "Classificacao");

            migrationBuilder.DropTable(
                name: "Noticias");
        }
    }
}
