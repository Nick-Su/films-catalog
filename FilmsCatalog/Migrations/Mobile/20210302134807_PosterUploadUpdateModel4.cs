using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsCatalog.Migrations.Mobile
{
    public partial class PosterUploadUpdateModel4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosterPath",
                table: "Films",
                newName: "Poster");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Poster",
                table: "Films",
                newName: "PosterPath");
        }
    }
}
