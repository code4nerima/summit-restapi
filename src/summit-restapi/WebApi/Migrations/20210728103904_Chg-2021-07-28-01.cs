using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CfjSummit.WebApi.Migrations
{
    public partial class Chg2021072801 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramLink",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<long>(type: "bigint", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Title_Ja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Zh_Tw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Zh_Cn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramLink_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgramPresenterLink",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramPresenterId = table.Column<long>(type: "bigint", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    Title_Ja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Zh_Tw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title_Zh_Cn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramPresenterLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramPresenterLink_ProgramPresenters_ProgramPresenterId",
                        column: x => x.ProgramPresenterId,
                        principalTable: "ProgramPresenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramLink_ProgramId",
                table: "ProgramLink",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramPresenterLink_ProgramPresenterId",
                table: "ProgramPresenterLink",
                column: "ProgramPresenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramLink");

            migrationBuilder.DropTable(
                name: "ProgramPresenterLink");
        }
    }
}
