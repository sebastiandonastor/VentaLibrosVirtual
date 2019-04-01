using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class agregandoAutoresLibros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LibrosAutores",
                columns: table => new
                {
                    IdAutor = table.Column<int>(nullable: false),
                    IdLibro = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosAutores", x => new { x.IdAutor, x.IdLibro });
                    table.ForeignKey(
                        name: "FK_LibrosAutores_Autores_IdAutor",
                        column: x => x.IdAutor,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibrosAutores_Libros_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibrosAutores_IdLibro",
                table: "LibrosAutores",
                column: "IdLibro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrosAutores");
        }
    }
}
