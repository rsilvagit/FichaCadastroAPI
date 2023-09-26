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
                    { 1, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2682), new DateTime(1998, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2702), "joao@example.com", "João" },
                    { 2, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2718), new DateTime(1978, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2722), "maria@example.com", "Maria" },
                    { 3, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2729), new DateTime(1998, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2734), "joaquim@example.com", "Joaquim" },
                    { 4, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2740), new DateTime(1938, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2744), "mario@example.com", "Mario" },
                    { 5, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2751), new DateTime(2008, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2756), "junior@example.com", "Junior" },
                    { 6, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2762), new DateTime(1998, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(2767), "marina@example.com", "Marina" }
                });

            migrationBuilder.InsertData(
                table: "Detalhe",
                columns: new[] { "Id", "DataCadastro", "Feedback", "FichaId", "Nota", "Situacao" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3328), "Bom trabalho!", 5, 5, true },
                    { 2, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3335), "Precisa melhorar", 2, 3, false },
                    { 3, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3339), "Bom trabalho!", 3, 5, true },
                    { 4, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3342), "Precisa melhorar", 2, 3, false },
                    { 5, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3347), "Bom trabalho!", 1, 5, true },
                    { 6, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3350), "Precisa melhorar", 3, 3, false },
                    { 7, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3353), "Bom trabalho!", 1, 5, true },
                    { 8, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3356), "Precisa melhorar", 4, 3, false }
                });

            migrationBuilder.InsertData(
                table: "Telefone",
                columns: new[] { "Id", "Ative", "DataCadastro", "Ddd", "FichaId", "Number" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3408), "123", 1, "555-1234" },
                    { 2, true, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3413), "456", 2, "555-5678" },
                    { 3, true, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3416), "123", 5, "555-1234" },
                    { 4, true, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3419), "456", 4, "555-5578" },
                    { 5, true, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3422), "123", 1, "555-1234" },
                    { 6, true, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3425), "456", 3, "555-5678" },
                    { 7, true, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3427), "123", 1, "555-1004" },
                    { 8, true, new DateTime(2023, 9, 26, 18, 11, 8, 129, DateTimeKind.Local).AddTicks(3430), "456", 2, "555-5008" }
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
