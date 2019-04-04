using Microsoft.EntityFrameworkCore.Migrations;

namespace SnowboardShop.Data.Migrations
{
    public partial class Brand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bindings_Brand_BrandId",
                table: "Bindings");

            migrationBuilder.DropForeignKey(
                name: "FK_Boots_Brand_BrandId",
                table: "Boots");

            migrationBuilder.DropForeignKey(
                name: "FK_Snowboards_Brand_BrandId",
                table: "Snowboards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brand",
                table: "Brand");

            migrationBuilder.RenameTable(
                name: "Brand",
                newName: "Brands");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brands",
                table: "Brands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bindings_Brands_BrandId",
                table: "Bindings",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boots_Brands_BrandId",
                table: "Boots",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Snowboards_Brands_BrandId",
                table: "Snowboards",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bindings_Brands_BrandId",
                table: "Bindings");

            migrationBuilder.DropForeignKey(
                name: "FK_Boots_Brands_BrandId",
                table: "Boots");

            migrationBuilder.DropForeignKey(
                name: "FK_Snowboards_Brands_BrandId",
                table: "Snowboards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brands",
                table: "Brands");

            migrationBuilder.RenameTable(
                name: "Brands",
                newName: "Brand");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brand",
                table: "Brand",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bindings_Brand_BrandId",
                table: "Bindings",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boots_Brand_BrandId",
                table: "Boots",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Snowboards_Brand_BrandId",
                table: "Snowboards",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
