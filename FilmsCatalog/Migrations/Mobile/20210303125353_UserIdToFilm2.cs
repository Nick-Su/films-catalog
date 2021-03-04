using Microsoft.EntityFrameworkCore.Migrations;

namespace FilmsCatalog.Migrations.Mobile
{
    public partial class UserIdToFilm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddedByUserId",
                table: "Films",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Films");
        }
    }
}
