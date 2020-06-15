using Microsoft.EntityFrameworkCore.Migrations;

namespace EntidadesBancarias.Web.Migrations
{
    public partial class AddImagenEntidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "fileLogo",
                table: "EntidadBancaria",
                type: "image",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fileLogo",
                table: "EntidadBancaria");
        }
    }
}
