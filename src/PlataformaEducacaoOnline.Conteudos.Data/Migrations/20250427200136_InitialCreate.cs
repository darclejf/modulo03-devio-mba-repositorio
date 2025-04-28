using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlataformaEducacaoOnline.Conteudos.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plataformaead_cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "varchar(150)", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plataformaead_cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "plataformaead_aulas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Ordem = table.Column<int>(type: "INTEGER", nullable: false),
                    Conteudo_Titulo = table.Column<string>(type: "varchar(150)", nullable: false),
                    Conteudo_Descricao = table.Column<string>(type: "varchar(5000)", nullable: false),
                    Conteudo_Tipo = table.Column<string>(type: "varchar(20)", nullable: false),
                    Conteudo_Url = table.Column<string>(type: "varchar(400)", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plataformaead_aulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_plataformaead_aulas_plataformaead_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "plataformaead_cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_plataformaead_aulas_CursoId",
                table: "plataformaead_aulas",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plataformaead_aulas");

            migrationBuilder.DropTable(
                name: "plataformaead_cursos");
        }
    }
}
