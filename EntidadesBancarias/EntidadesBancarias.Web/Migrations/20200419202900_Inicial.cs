using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntidadesBancarias.Web.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrupoEntidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Color = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoEntidad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntidadBancaria",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(maxLength: 250, nullable: false),
                    Poblacion = table.Column<string>(maxLength: 100, nullable: false),
                    Provincia = table.Column<string>(maxLength: 100, nullable: false),
                    CodPostal = table.Column<string>(maxLength: 5, nullable: false),
                    Telefono = table.Column<int>(nullable: false),
                    Mail = table.Column<string>(maxLength: 100, nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(maxLength: 50, nullable: true),
                    EstadoActivo = table.Column<bool>(nullable: false),
                    GrupoEntidadID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadBancaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntidadBancaria_GrupoEntidad_GrupoEntidadID",
                        column: x => x.GrupoEntidadID,
                        principalTable: "GrupoEntidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntidadBancaria_GrupoEntidadID",
                table: "EntidadBancaria",
                column: "GrupoEntidadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntidadBancaria");

            migrationBuilder.DropTable(
                name: "GrupoEntidad");
        }
    }
}
