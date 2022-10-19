using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAppCore.DAL.Migrations
{
    public partial class roleadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "userInfo",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "userInfo");
        }
    }
}
