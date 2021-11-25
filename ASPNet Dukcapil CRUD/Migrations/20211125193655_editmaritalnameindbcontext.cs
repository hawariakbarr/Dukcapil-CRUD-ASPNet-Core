using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNet_Dukcapil_CRUD.Migrations
{
    public partial class editmaritalnameindbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dukcapils_MaritalStatuses_MaritalID",
                table: "Dukcapils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaritalStatuses",
                table: "MaritalStatuses");

            migrationBuilder.RenameTable(
                name: "MaritalStatuses",
                newName: "Maritals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Maritals",
                table: "Maritals",
                column: "MaritalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dukcapils_Maritals_MaritalID",
                table: "Dukcapils",
                column: "MaritalID",
                principalTable: "Maritals",
                principalColumn: "MaritalID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dukcapils_Maritals_MaritalID",
                table: "Dukcapils");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Maritals",
                table: "Maritals");

            migrationBuilder.RenameTable(
                name: "Maritals",
                newName: "MaritalStatuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaritalStatuses",
                table: "MaritalStatuses",
                column: "MaritalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dukcapils_MaritalStatuses_MaritalID",
                table: "Dukcapils",
                column: "MaritalID",
                principalTable: "MaritalStatuses",
                principalColumn: "MaritalID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
