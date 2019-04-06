using Microsoft.EntityFrameworkCore.Migrations;

namespace SnowboardShop.Data.Migrations
{
    public partial class ItemOrderPlaced : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Placed",
                table: "CartItems",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placed",
                table: "CartItems");
        }
    }
}
