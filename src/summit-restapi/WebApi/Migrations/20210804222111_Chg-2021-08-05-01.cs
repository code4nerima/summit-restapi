using Microsoft.EntityFrameworkCore.Migrations;

namespace CfjSummit.WebApi.Migrations
{
    public partial class Chg2021080501 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InputCompleted",
                table: "Programs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputCompleted",
                table: "Programs");
        }
    }
}
