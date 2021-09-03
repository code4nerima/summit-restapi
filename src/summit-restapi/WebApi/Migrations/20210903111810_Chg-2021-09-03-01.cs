using Microsoft.EntityFrameworkCore.Migrations;

namespace CfjSummit.WebApi.Migrations
{
    public partial class Chg2021090301 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Memo",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UdtalkSrURL",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Memo",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "UdtalkSrURL",
                table: "Tracks");
        }
    }
}
