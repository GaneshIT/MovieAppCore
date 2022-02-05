using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAppCore.DAL.Migrations
{
    public partial class addedmovieshowtimings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movieShowTimings",
                columns: table => new
                {
                    MovieShoTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ShowDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieShowTimings", x => x.MovieShoTimeId);
                    table.ForeignKey(
                        name: "FK_movieShowTimings_movie_MovieId",
                        column: x => x.MovieId,
                        principalTable: "movie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_movieShowTimings_MovieId",
                table: "movieShowTimings",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movieShowTimings");
        }
    }
}
