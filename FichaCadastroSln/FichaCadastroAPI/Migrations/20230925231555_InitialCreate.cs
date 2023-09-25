using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FichaCadastroAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ficha",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ficha", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Detalhe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback = table.Column<string>(type: "VARCHAR(500)", maxLength: 500, nullable: false),
                    Nota = table.Column<int>(type: "int", nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    FichaId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalhe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalhe_Ficha_FichaId",
                        column: x => x.FichaId,
                        principalTable: "Ficha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ddd = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false),
                    Ative = table.Column<bool>(type: "bit", nullable: false),
                    FichaId = table.Column<int>(type: "int", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefone_Ficha_FichaId",
                        column: x => x.FichaId,
                        principalTable: "Ficha",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Ficha",
                columns: new[] { "Id", "DataCadastro", "DataNascimento", "Email", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 25, 20, 15, 54, 562, DateTimeKind.Local).AddTicks(9571), new DateTime(1998, 9, 25, 20, 15, 54, 562, DateTimeKind.Local).AddTicks(9590), "joao@example.com", "João" },
                    { 2, new DateTime(2023, 9, 25, 20, 15, 54, 562, DateTimeKind.Local).AddTicks(9600), new DateTime(1978, 9, 25, 20, 15, 54, 562, DateTimeKind.Local).AddTicks(9603), "maria@example.com", "Maria" }
                });

            migrationBuilder.InsertData(
                table: "Detalhe",
                columns: new[] { "Id", "DataCadastro", "Feedback", "FichaId", "Nota", "Situacao" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 25, 20, 15, 54, 563, DateTimeKind.Local).AddTicks(380), "Bom trabalho!", 1, 5, true },
                    { 2, new DateTime(2023, 9, 25, 20, 15, 54, 563, DateTimeKind.Local).AddTicks(393), "Precisa melhorar", 2, 3, false }
                });

            migrationBuilder.InsertData(
                table: "Telefone",
                columns: new[] { "Id", "Ative", "DataCadastro", "Ddd", "FichaId", "Number" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 9, 25, 20, 15, 54, 563, DateTimeKind.Local).AddTicks(445), "123", 1, "555-1234" },
                    { 2, true, new DateTime(2023, 9, 25, 20, 15, 54, 563, DateTimeKind.Local).AddTicks(450), "456", 2, "555-5678" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalhe_FichaId",
                table: "Detalhe",
                column: "FichaId");

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_FichaId",
                table: "Telefone",
                column: "FichaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalhe");

            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Ficha");
        }
    }
}
