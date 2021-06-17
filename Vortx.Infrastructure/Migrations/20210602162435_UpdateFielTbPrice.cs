using Microsoft.EntityFrameworkCore.Migrations;

namespace Vortx.Infrastructure.Migrations
{
    public partial class UpdateFielTbPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PriceMinute",
                table: "Prices",
                newName: "Minute");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Minute",
                table: "Prices",
                newName: "PriceMinute");
        }
    }
}
