using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventarioAPI.Migrations
{
    public partial class InitDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artículos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion_P = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cantidad_S = table.Column<int>(type: "int", nullable: false),
                    Precio_V = table.Column<float>(type: "real", nullable: false),
                    Fecha_C = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fecha_E = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artículos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artículos");
        }
    }
}
