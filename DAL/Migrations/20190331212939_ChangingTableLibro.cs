using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class ChangingTableLibro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Libros",
                newName: "Titulo");

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Libros",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Libros");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Libros",
                newName: "Nombre");
        }
    }
}
