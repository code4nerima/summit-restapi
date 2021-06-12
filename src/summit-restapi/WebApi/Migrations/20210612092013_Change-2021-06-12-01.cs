using Microsoft.EntityFrameworkCore.Migrations;

namespace CfjSummit.WebApi.Migrations
{
    public partial class Change2021061201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BroadcastingURL",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetingId",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetingPasscode",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeetingUrl",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Station",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreamKey",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreamUrl",
                table: "Tracks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BroadcastingURL",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "MeetingId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "MeetingPasscode",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "MeetingUrl",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "Station",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "StreamKey",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "StreamUrl",
                table: "Tracks");
        }
    }
}
