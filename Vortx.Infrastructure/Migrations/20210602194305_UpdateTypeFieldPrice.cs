using Microsoft.EntityFrameworkCore.Migrations;

namespace Vortx.Infrastructure.Migrations
{
    public partial class UpdateTypeFieldPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DddOrigin",
                table: "Prices",
                type: "varchar",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "DddDestination",
                table: "Prices",
                type: "varchar",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DddOrigin",
                table: "Prices",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "DddDestination",
                table: "Prices",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldMaxLength: 3);
        }
    }
}
