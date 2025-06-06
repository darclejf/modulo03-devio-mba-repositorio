using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlataformaEducacaoOnline.Financeiro.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plataformaead_pagamentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Valor = table.Column<decimal>(type: "TEXT", nullable: false),
                    NomeCartao = table.Column<string>(type: "varchar(250)", nullable: false),
                    NumeroCartao = table.Column<string>(type: "varchar(16)", nullable: false),
                    ExpiracaoCartao = table.Column<string>(type: "varchar(10)", nullable: false),
                    CvvCartao = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plataformaead_pagamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "plataformaead_transacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PagamentoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false),
                    StatusTransacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plataformaead_transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_plataformaead_transacoes_plataformaead_pagamentos_PagamentoId",
                        column: x => x.PagamentoId,
                        principalTable: "plataformaead_pagamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_plataformaead_transacoes_PagamentoId",
                table: "plataformaead_transacoes",
                column: "PagamentoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plataformaead_transacoes");

            migrationBuilder.DropTable(
                name: "plataformaead_pagamentos");
        }
    }
}
