using Microsoft.EntityFrameworkCore.Migrations;

namespace CfjSummit.WebApi.Migrations
{
    public partial class Chg2021071102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramPresenter_Programs_ProgramId",
                table: "ProgramPresenter");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramPresenter",
                table: "ProgramPresenter");

            migrationBuilder.RenameTable(
                name: "ProgramPresenter",
                newName: "ProgramPresenters");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramPresenter_ProgramId",
                table: "ProgramPresenters",
                newName: "IX_ProgramPresenters_ProgramId");

            migrationBuilder.AddColumn<string>(
                name: "Name_Ja_Kana",
                table: "ProgramPresenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramPresenters",
                table: "ProgramPresenters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramPresenters_Programs_ProgramId",
                table: "ProgramPresenters",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramPresenters_Programs_ProgramId",
                table: "ProgramPresenters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramPresenters",
                table: "ProgramPresenters");

            migrationBuilder.DropColumn(
                name: "Name_Ja_Kana",
                table: "ProgramPresenters");

            migrationBuilder.RenameTable(
                name: "ProgramPresenters",
                newName: "ProgramPresenter");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramPresenters_ProgramId",
                table: "ProgramPresenter",
                newName: "IX_ProgramPresenter_ProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramPresenter",
                table: "ProgramPresenter",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramPresenter_Programs_ProgramId",
                table: "ProgramPresenter",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
