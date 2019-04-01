using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class agregandoComprasLibros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComprasLibros",
                columns: table => new
                {
                    IdCompra = table.Column<int>(nullable: false),
                    IdLibro = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasLibros", x => new { x.IdCompra, x.IdLibro });
                    table.ForeignKey(
                        name: "FK_ComprasLibros_Compras_IdCompra",
                        column: x => x.IdCompra,
                        principalTable: "Compras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprasLibros_Libros_IdLibro",
                        column: x => x.IdLibro,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComprasLibros_IdLibro",
                table: "ComprasLibros",
                column: "IdLibro");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprasLibros");
        }
    }
}
