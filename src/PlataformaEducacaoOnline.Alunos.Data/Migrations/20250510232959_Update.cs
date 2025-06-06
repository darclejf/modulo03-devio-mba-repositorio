using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlataformaEducacaoOnline.Alunos.Data.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plataformaead_matriculas_historico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    MatriculaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AulaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Concluido = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plataformaead_matriculas_historico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_plataformaead_matriculas_historico_plataformaead_matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "plataformaead_matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_plataformaead_matriculas_historico_MatriculaId",
                table: "plataformaead_matriculas_historico",
                column: "MatriculaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plataformaead_matriculas_historico");
        }
    }
}
