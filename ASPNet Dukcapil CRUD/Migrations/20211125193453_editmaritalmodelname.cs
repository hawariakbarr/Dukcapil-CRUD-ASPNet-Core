using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNet_Dukcapil_CRUD.Migrations
{
    public partial class editmaritalmodelname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dukcapils_MaritalStatuses_MaritalStatusMaritalID",
                table: "Dukcapils");

            migrationBuilder.DropIndex(
                name: "IX_Dukcapils_MaritalStatusMaritalID",
                table: "Dukcapils");

            migrationBuilder.DropColumn(
                name: "MaritalStatusMaritalID",
                table: "Dukcapils");

            migrationBuilder.CreateIndex(
                name: "IX_Dukcapils_MaritalID",
                table: "Dukcapils",
                column: "MaritalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dukcapils_MaritalStatuses_MaritalID",
                table: "Dukcapils",
                column: "MaritalID",
                principalTable: "MaritalStatuses",
                principalColumn: "MaritalID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dukcapils_MaritalStatuses_MaritalID",
                table: "Dukcapils");

            migrationBuilder.DropIndex(
                name: "IX_Dukcapils_MaritalID",
                table: "Dukcapils");

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatusMaritalID",
                table: "Dukcapils",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dukcapils_MaritalStatusMaritalID",
                table: "Dukcapils",
                column: "MaritalStatusMaritalID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dukcapils_MaritalStatuses_MaritalStatusMaritalID",
                table: "Dukcapils",
                column: "MaritalStatusMaritalID",
                principalTable: "MaritalStatuses",
                principalColumn: "MaritalID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
