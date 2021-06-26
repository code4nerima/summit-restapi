using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CfjSummit.WebApi.Migrations
{
    public partial class Chg2021062602 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramUserProfile_Programs_ProgramId",
                table: "ProgramUserProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramUserProfile_UserProfiles_UserProfileId",
                table: "ProgramUserProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramUserProfile",
                table: "ProgramUserProfile");

            migrationBuilder.RenameTable(
                name: "ProgramUserProfile",
                newName: "ProgramUserProfiles");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramUserProfile_UserProfileId",
                table: "ProgramUserProfiles",
                newName: "IX_ProgramUserProfiles_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramUserProfile_ProgramId",
                table: "ProgramUserProfiles",
                newName: "IX_ProgramUserProfiles_ProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramUserProfiles",
                table: "ProgramUserProfiles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreGuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_Ja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_Zh_Tw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_Zh_Cn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramGenres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<long>(type: "bigint", nullable: false),
                    GenreId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramGenres_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramGenres_GenreId",
                table: "ProgramGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramGenres_ProgramId",
                table: "ProgramGenres",
                column: "ProgramId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramUserProfiles_Programs_ProgramId",
                table: "ProgramUserProfiles",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramUserProfiles_UserProfiles_UserProfileId",
                table: "ProgramUserProfiles",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProgramUserProfiles_Programs_ProgramId",
                table: "ProgramUserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramUserProfiles_UserProfiles_UserProfileId",
                table: "ProgramUserProfiles");

            migrationBuilder.DropTable(
                name: "ProgramGenres");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProgramUserProfiles",
                table: "ProgramUserProfiles");

            migrationBuilder.RenameTable(
                name: "ProgramUserProfiles",
                newName: "ProgramUserProfile");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramUserProfiles_UserProfileId",
                table: "ProgramUserProfile",
                newName: "IX_ProgramUserProfile_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ProgramUserProfiles_ProgramId",
                table: "ProgramUserProfile",
                newName: "IX_ProgramUserProfile_ProgramId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProgramUserProfile",
                table: "ProgramUserProfile",
                column: "Id");

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
    }
}
