using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsCatalog.Migrations.Mobile
{
    public partial class PosterUploadUpdateModel3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Poster",
                table: "Films",
                newName: "PosterPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosterPath",
                table: "Films",
                newName: "Poster");
        }
    }
}
