using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aliquota.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplicacoes",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataDaAplicacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorRetido = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplicacoes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplicacoes");
        }
    }
}
