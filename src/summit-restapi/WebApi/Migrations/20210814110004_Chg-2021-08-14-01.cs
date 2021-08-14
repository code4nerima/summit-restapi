using Microsoft.EntityFrameworkCore.Migrations;

namespace CfjSummit.WebApi.Migrations
{
    public partial class Chg2021081401 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UdTalkAppURL",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UdTalkWebURL",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UdTalkAppURL",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "UdTalkWebURL",
                table: "Tracks");
        }
    }
}
