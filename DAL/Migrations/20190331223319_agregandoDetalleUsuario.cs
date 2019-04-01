using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class agregandoDetalleUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetallesUsuario",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Premium = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesUsuario_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesUsuario");
        }
    }
}
