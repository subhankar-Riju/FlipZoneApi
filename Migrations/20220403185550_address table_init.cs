using Microsoft.EntityFrameworkCore.Migrations;

namespace FlipZoneApi.Migrations
{
    public partial class addresstable_init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    addr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    district = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    mobile = table.Column<long>(type: "bigint", nullable: false),
                    pin = table.Column<long>(type: "bigint", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
