using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CfjSummit.WebApi.Migrations
{
    public partial class Chg2021082201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProgramGrareco",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramId = table.Column<long>(type: "bigint", nullable: true),
                    ProgramGrarecoGuid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_Ja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_Ja_Kana = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_Zh_Tw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name_Zh_Cn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization_Ja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization_Zh_Tw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization_Zh_Cn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_Ja = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_Zh_Tw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description_Zh_Cn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStamp = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramGrareco", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramGrareco_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgramGrareco_ProgramId",
                table: "ProgramGrareco",
                column: "ProgramId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgramGrareco");
        }
    }
}
