using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class agregandoGenerosLibros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GenerosLibros",
                columns: table => new
                {
                    IdGenero = table.Column<int>(nullable: false),
                    IdLibro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerosLibros", x => new { x.IdGenero, x.IdLibro });
                    table.ForeignKey(
                        name: "FK_GenerosLibros_Generos_IdGenero",
                        column: x => x.IdGenero,
                        principalTable: "Generos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenerosLibros_Libros_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenerosLibros_IdLibro",
                table: "GenerosLibros",
                column: "IdLibro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenerosLibros");
        }
    }
}
