using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mart.Web.Migrations
{
    /// <inheritdoc />
    public partial class ProductTableUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductAgeGroupId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductBrandId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryCategoryId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductColorId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductAgeGroupId",
                table: "Products",
                column: "ProductAgeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryCategoryId",
                table: "Products",
                column: "ProductCategoryCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductColorId",
                table: "Products",
                column: "ProductColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductAgeGroups_ProductAgeGroupId",
                table: "Products",
                column: "ProductAgeGroupId",
                principalTable: "ProductAgeGroups",
                principalColumn: "ProductAgeGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                table: "Products",
                column: "ProductBrandId",
                principalTable: "ProductBrands",
                principalColumn: "ProductBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCategoryId",
                table: "Products",
                column: "ProductCategoryCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductColors_ProductColorId",
                table: "Products",
                column: "ProductColorId",
                principalTable: "ProductColors",
                principalColumn: "ProductColorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductAgeGroups_ProductAgeGroupId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductBrands_ProductBrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductColors_ProductColorId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductAgeGroupId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryCategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductColorId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductAgeGroupId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductBrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductCategoryCategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductColorId",
                table: "Products");
        }
    }
}
