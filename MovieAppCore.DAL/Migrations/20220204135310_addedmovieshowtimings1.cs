using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAppCore.DAL.Migrations
{
    public partial class addedmovieshowtimings1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieShoTimeId",
                table: "movieShowTimings",
                newName: "MovieShowTimeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieShowTimeId",
                table: "movieShowTimings",
                newName: "MovieShoTimeId");
        }
    }
}
