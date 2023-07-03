using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalBank.Migrations
{
    /// <inheritdoc />
    public partial class CriandoContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumeroDaConta = table.Column<int>(type: "int", maxLength: 8, nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contas_NumeroDaConta",
                table: "Contas",
                column: "NumeroDaConta",
                unique: true);

            migrationBuilder.InsertData(
                table: "Contas",
                columns: new[] { "Id", "Nome", "NumeroDaConta", "Saldo" },
                values: new object[,]
                {
                    {1, "Eduardo", 1234, 102 },
                    {2, "Pedro", 1000, 100000 },
                    {3, "Jasmine", 2000, 296 },
                    {4, "Maria", 3000, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
