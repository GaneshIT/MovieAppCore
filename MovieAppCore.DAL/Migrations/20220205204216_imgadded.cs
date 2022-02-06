using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAppCore.DAL.Migrations
{
    public partial class imgadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImgPoster",
                table: "movie",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPoster",
                table: "movie");
        }
    }
}
