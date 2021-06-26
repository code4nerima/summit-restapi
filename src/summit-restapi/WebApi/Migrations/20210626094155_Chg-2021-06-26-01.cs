using Microsoft.EntityFrameworkCore.Migrations;

namespace CfjSummit.WebApi.Migrations
{
    public partial class Chg2021062601 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramUserProfile_Programs_ProgramId",
                table: "ProgramUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramUserProfile_UserProfiles_UserProfileId",
                table: "ProgramUserProfile");

            migrationBuilder.AddColumn<string>(
                name: "PhotoURL",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UserProfileId",
                table: "ProgramUserProfile",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProgramId",
                table: "ProgramUserProfile",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramUserProfile_Programs_ProgramId",
                table: "ProgramUserProfile",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramUserProfile_UserProfiles_UserProfileId",
                table: "ProgramUserProfile",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramUserProfile_Programs_ProgramId",
                table: "ProgramUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramUserProfile_UserProfiles_UserProfileId",
                table: "ProgramUserProfile");

            migrationBuilder.DropColumn(
                name: "PhotoURL",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<long>(
                name: "UserProfileId",
                table: "ProgramUserProfile",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ProgramId",
                table: "ProgramUserProfile",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramUserProfile_Programs_ProgramId",
                table: "ProgramUserProfile",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramUserProfile_UserProfiles_UserProfileId",
                table: "ProgramUserProfile",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
