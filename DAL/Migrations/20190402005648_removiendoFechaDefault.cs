using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class removiendoFechaDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Libros",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 3, 31, 21, 41, 51, 294, DateTimeKind.Local).AddTicks(3344));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Libros",
                nullable: false,
                defaultValue: new DateTime(2019, 3, 31, 21, 41, 51, 294, DateTimeKind.Local).AddTicks(3344),
                oldClrType: typeof(DateTime));
        }
    }
}
