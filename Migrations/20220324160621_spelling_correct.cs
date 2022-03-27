using Microsoft.EntityFrameworkCore.Migrations;

namespace FlipZoneApi.Migrations
{
    public partial class spelling_correct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "gmail",
                table: "Customers",
                newName: "email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Customers",
                newName: "gmail");
        }
    }
}
