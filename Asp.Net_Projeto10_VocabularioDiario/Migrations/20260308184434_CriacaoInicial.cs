using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Asp.Net_Projeto10_VocabularioDiario.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Palavras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingles = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Portugues = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palavras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistroRespostas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PalavraId = table.Column<int>(type: "int", nullable: false),
                    Acertou = table.Column<bool>(type: "bit", nullable: false),
                    DataResposta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroRespostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroRespostas_Palavras_PalavraId",
                        column: x => x.PalavraId,
                        principalTable: "Palavras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroRespostas_PalavraId",
                table: "RegistroRespostas",
                column: "PalavraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroRespostas");

            migrationBuilder.DropTable(
                name: "Palavras");
        }
    }
}
