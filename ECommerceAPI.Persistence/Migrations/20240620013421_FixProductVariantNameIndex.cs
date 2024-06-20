using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixProductVariantNameIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_Name",
                schema: "Product",
                table: "ProductVariants");

            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_ProductId",
                schema: "Product",
                table: "ProductVariants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 503, DateTimeKind.Utc).AddTicks(9626),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 308, DateTimeKind.Utc).AddTicks(9923));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 503, DateTimeKind.Utc).AddTicks(8513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 308, DateTimeKind.Utc).AddTicks(9467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 506, DateTimeKind.Utc).AddTicks(8219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 310, DateTimeKind.Utc).AddTicks(3186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 506, DateTimeKind.Utc).AddTicks(6428),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 310, DateTimeKind.Utc).AddTicks(2595));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 503, DateTimeKind.Utc).AddTicks(1426),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 308, DateTimeKind.Utc).AddTicks(4221));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 503, DateTimeKind.Utc).AddTicks(785),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 308, DateTimeKind.Utc).AddTicks(3717));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 504, DateTimeKind.Utc).AddTicks(6711),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 309, DateTimeKind.Utc).AddTicks(3688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 504, DateTimeKind.Utc).AddTicks(6047),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 309, DateTimeKind.Utc).AddTicks(3215));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 508, DateTimeKind.Utc).AddTicks(839),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 310, DateTimeKind.Utc).AddTicks(8487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 507, DateTimeKind.Utc).AddTicks(8630),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 310, DateTimeKind.Utc).AddTicks(7860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 502, DateTimeKind.Utc).AddTicks(654),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 307, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 501, DateTimeKind.Utc).AddTicks(9731),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 307, DateTimeKind.Utc).AddTicks(8176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 493, DateTimeKind.Utc).AddTicks(640),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 302, DateTimeKind.Utc).AddTicks(2947));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 492, DateTimeKind.Utc).AddTicks(9816),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 302, DateTimeKind.Utc).AddTicks(2141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 494, DateTimeKind.Utc).AddTicks(4974),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 303, DateTimeKind.Utc).AddTicks(3204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 494, DateTimeKind.Utc).AddTicks(4090),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 303, DateTimeKind.Utc).AddTicks(2597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 492, DateTimeKind.Utc).AddTicks(5708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 301, DateTimeKind.Utc).AddTicks(8818));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 492, DateTimeKind.Utc).AddTicks(4490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 301, DateTimeKind.Utc).AddTicks(8271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 491, DateTimeKind.Utc).AddTicks(9369),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 301, DateTimeKind.Utc).AddTicks(4941));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 491, DateTimeKind.Utc).AddTicks(8727),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 301, DateTimeKind.Utc).AddTicks(4457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 490, DateTimeKind.Utc).AddTicks(8738),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 300, DateTimeKind.Utc).AddTicks(7396));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 490, DateTimeKind.Utc).AddTicks(7934),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 300, DateTimeKind.Utc).AddTicks(6674));

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId_Name",
                schema: "Product",
                table: "ProductVariants",
                columns: new[] { "ProductId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductVariants_ProductId_Name",
                schema: "Product",
                table: "ProductVariants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 308, DateTimeKind.Utc).AddTicks(9923),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 503, DateTimeKind.Utc).AddTicks(9626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 308, DateTimeKind.Utc).AddTicks(9467),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 503, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 310, DateTimeKind.Utc).AddTicks(3186),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 506, DateTimeKind.Utc).AddTicks(8219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 310, DateTimeKind.Utc).AddTicks(2595),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 506, DateTimeKind.Utc).AddTicks(6428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 308, DateTimeKind.Utc).AddTicks(4221),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 503, DateTimeKind.Utc).AddTicks(1426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 308, DateTimeKind.Utc).AddTicks(3717),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 503, DateTimeKind.Utc).AddTicks(785));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 309, DateTimeKind.Utc).AddTicks(3688),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 504, DateTimeKind.Utc).AddTicks(6711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "RefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 309, DateTimeKind.Utc).AddTicks(3215),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 504, DateTimeKind.Utc).AddTicks(6047));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 310, DateTimeKind.Utc).AddTicks(8487),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 508, DateTimeKind.Utc).AddTicks(839));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "Profiles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 310, DateTimeKind.Utc).AddTicks(7860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 507, DateTimeKind.Utc).AddTicks(8630));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 307, DateTimeKind.Utc).AddTicks(8793),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 502, DateTimeKind.Utc).AddTicks(654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 307, DateTimeKind.Utc).AddTicks(8176),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 501, DateTimeKind.Utc).AddTicks(9731));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 302, DateTimeKind.Utc).AddTicks(2947),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 493, DateTimeKind.Utc).AddTicks(640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 302, DateTimeKind.Utc).AddTicks(2141),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 492, DateTimeKind.Utc).AddTicks(9816));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 303, DateTimeKind.Utc).AddTicks(3204),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 494, DateTimeKind.Utc).AddTicks(4974));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 303, DateTimeKind.Utc).AddTicks(2597),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 494, DateTimeKind.Utc).AddTicks(4090));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 301, DateTimeKind.Utc).AddTicks(8818),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 492, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 301, DateTimeKind.Utc).AddTicks(8271),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 492, DateTimeKind.Utc).AddTicks(4490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 301, DateTimeKind.Utc).AddTicks(4941),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 491, DateTimeKind.Utc).AddTicks(9369));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 301, DateTimeKind.Utc).AddTicks(4457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 491, DateTimeKind.Utc).AddTicks(8727));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 300, DateTimeKind.Utc).AddTicks(7396),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 490, DateTimeKind.Utc).AddTicks(8738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 16, 4, 7, 48, 300, DateTimeKind.Utc).AddTicks(6674),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 20, 1, 34, 20, 490, DateTimeKind.Utc).AddTicks(7934));

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_Name",
                schema: "Product",
                table: "ProductVariants",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVariants_ProductId",
                schema: "Product",
                table: "ProductVariants",
                column: "ProductId");
        }
    }
}
