using Microsoft.EntityFrameworkCore.Migrations;

namespace ASPNet_Dukcapil_CRUD.Migrations
{
    public partial class udpatemaritaliddatatypeindukcapilsmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaritalID",
                table: "Dukcapils",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MaritalID",
                table: "Dukcapils",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
