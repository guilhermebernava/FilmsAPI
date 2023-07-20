using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class removing_constraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Genre_Name",
                table: "Genre");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Film_Title",
                table: "Film");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Actor_Name",
                table: "Actor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Genre_Name",
                table: "Genre",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Film_Title",
                table: "Film",
                column: "Title");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Actor_Name",
                table: "Actor",
                column: "Name");
        }
    }
}
