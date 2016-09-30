using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SKMBingo.Migrations
{
    public partial class InitModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "field",
                columns: table => new
                {
                    fldid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    fldno = table.Column<int>(nullable: false),
                    fldactive = table.Column<bool>(nullable: false),
                    fldname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_field", x => x.fldid);
                });

            migrationBuilder.CreateTable(
                name: "bingorecord",
                columns: table => new
                {
                    birid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGeneratedOnAdd", true),
                    birdate = table.Column<DateTime>(nullable: false),
                    birfldid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bingorecord", x => x.birid);
                    table.ForeignKey(
                        name: "FK_bingorecord_field_birfldid",
                        column: x => x.birfldid,
                        principalTable: "field",
                        principalColumn: "fldid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bingorecord_birfldid",
                table: "bingorecord",
                column: "birfldid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bingorecord");

            migrationBuilder.DropTable(
                name: "field");
        }
    }
}
