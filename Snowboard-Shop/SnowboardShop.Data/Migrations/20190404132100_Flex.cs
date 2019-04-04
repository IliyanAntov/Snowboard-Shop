using Microsoft.EntityFrameworkCore.Migrations;

namespace SnowboardShop.Data.Migrations
{
    public partial class Flex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "Flex",
                table: "Snowboards",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Flex",
                table: "Snowboards",
                nullable: false,
                oldClrType: typeof(byte));
        }
    }
}
