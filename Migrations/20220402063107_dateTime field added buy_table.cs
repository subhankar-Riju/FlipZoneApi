using Microsoft.EntityFrameworkCore.Migrations;

namespace FlipZoneApi.Migrations
{
    public partial class dateTimefieldaddedbuy_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Buys",
                table: "Buys");

            migrationBuilder.AddColumn<string>(
                name: "dateTime",
                table: "Buys",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buys",
                table: "Buys",
                columns: new[] { "email", "p_id", "dateTime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Buys",
                table: "Buys");

            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "Buys");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buys",
                table: "Buys",
                columns: new[] { "email", "p_id" });
        }
    }
}
