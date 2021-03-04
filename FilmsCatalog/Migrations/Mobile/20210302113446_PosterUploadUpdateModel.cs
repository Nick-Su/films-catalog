using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsCatalog.Migrations.Mobile
{
    public partial class PosterUploadUpdateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilmPicture",
                table: "Films",
                newName: "Poster");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Poster",
                table: "Films",
                newName: "FilmPicture");
        }
    }
}
