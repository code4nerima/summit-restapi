using Microsoft.EntityFrameworkCore.Migrations;

namespace CfjSummit.WebApi.Migrations
{
    public partial class Chg2021072802 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLink_Programs_ProgramId",
                table: "ProgramLink");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramPresenterLink_ProgramPresenters_ProgramPresenterId",
                table: "ProgramPresenterLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramPresenterLink",
                table: "ProgramPresenterLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramLink",
                table: "ProgramLink");

            migrationBuilder.RenameTable(
                name: "ProgramPresenterLink",
                newName: "ProgramPresenterLinks");

            migrationBuilder.RenameTable(
                name: "ProgramLink",
                newName: "ProgramLinks");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramPresenterLink_ProgramPresenterId",
                table: "ProgramPresenterLinks",
                newName: "IX_ProgramPresenterLinks_ProgramPresenterId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramLink_ProgramId",
                table: "ProgramLinks",
                newName: "IX_ProgramLinks_ProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramPresenterLinks",
                table: "ProgramPresenterLinks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramLinks",
                table: "ProgramLinks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLinks_Programs_ProgramId",
                table: "ProgramLinks",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramPresenterLinks_ProgramPresenters_ProgramPresenterId",
                table: "ProgramPresenterLinks",
                column: "ProgramPresenterId",
                principalTable: "ProgramPresenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramLinks_Programs_ProgramId",
                table: "ProgramLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramPresenterLinks_ProgramPresenters_ProgramPresenterId",
                table: "ProgramPresenterLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramPresenterLinks",
                table: "ProgramPresenterLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramLinks",
                table: "ProgramLinks");

            migrationBuilder.RenameTable(
                name: "ProgramPresenterLinks",
                newName: "ProgramPresenterLink");

            migrationBuilder.RenameTable(
                name: "ProgramLinks",
                newName: "ProgramLink");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramPresenterLinks_ProgramPresenterId",
                table: "ProgramPresenterLink",
                newName: "IX_ProgramPresenterLink_ProgramPresenterId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramLinks_ProgramId",
                table: "ProgramLink",
                newName: "IX_ProgramLink_ProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramPresenterLink",
                table: "ProgramPresenterLink",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramLink",
                table: "ProgramLink",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramLink_Programs_ProgramId",
                table: "ProgramLink",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramPresenterLink_ProgramPresenters_ProgramPresenterId",
                table: "ProgramPresenterLink",
                column: "ProgramPresenterId",
                principalTable: "ProgramPresenters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
