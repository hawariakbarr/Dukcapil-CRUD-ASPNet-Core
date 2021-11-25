using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNet_Dukcapil_CRUD.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    MaritalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaritalDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.MaritalID);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    ReligionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReligionName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.ReligionID);
                });

            migrationBuilder.CreateTable(
                name: "Dukcapils",
                columns: table => new
                {
                    DukcapilID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIK = table.Column<int>(type: "int", maxLength: 16, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaidenName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrithDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReligionID = table.Column<int>(type: "int", nullable: false),
                    MaritalID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatusMaritalID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dukcapils", x => x.DukcapilID);
                    table.ForeignKey(
                        name: "FK_Dukcapils_MaritalStatuses_MaritalStatusMaritalID",
                        column: x => x.MaritalStatusMaritalID,
                        principalTable: "MaritalStatuses",
                        principalColumn: "MaritalID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dukcapils_Religions_ReligionID",
                        column: x => x.ReligionID,
                        principalTable: "Religions",
                        principalColumn: "ReligionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dukcapils_MaritalStatusMaritalID",
                table: "Dukcapils",
                column: "MaritalStatusMaritalID");

            migrationBuilder.CreateIndex(
                name: "IX_Dukcapils_ReligionID",
                table: "Dukcapils",
                column: "ReligionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dukcapils");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "Religions");
        }
    }
}
