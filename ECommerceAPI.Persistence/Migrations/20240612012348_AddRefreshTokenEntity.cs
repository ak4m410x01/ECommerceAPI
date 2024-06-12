using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 58, DateTimeKind.Utc).AddTicks(7663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 604, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 58, DateTimeKind.Utc).AddTicks(7347),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 604, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 59, DateTimeKind.Utc).AddTicks(9999),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(881));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 59, DateTimeKind.Utc).AddTicks(9560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 58, DateTimeKind.Utc).AddTicks(2912),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 58, DateTimeKind.Utc).AddTicks(2398),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 57, DateTimeKind.Utc).AddTicks(8035),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(2041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 57, DateTimeKind.Utc).AddTicks(7596),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 53, DateTimeKind.Utc).AddTicks(4064),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 53, DateTimeKind.Utc).AddTicks(3592),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 54, DateTimeKind.Utc).AddTicks(1541),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 54, DateTimeKind.Utc).AddTicks(1024),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 53, DateTimeKind.Utc).AddTicks(1153),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 53, DateTimeKind.Utc).AddTicks(759),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7222));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 52, DateTimeKind.Utc).AddTicks(8011),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 52, DateTimeKind.Utc).AddTicks(7675),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 52, DateTimeKind.Utc).AddTicks(2086),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(7124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 52, DateTimeKind.Utc).AddTicks(1560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(6516));

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 59, DateTimeKind.Utc).AddTicks(2164)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 59, DateTimeKind.Utc).AddTicks(2594)),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => new { x.Id, x.UserId });
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "User",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                schema: "User",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens",
                schema: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 604, DateTimeKind.Utc).AddTicks(2448),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 58, DateTimeKind.Utc).AddTicks(7663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 604, DateTimeKind.Utc).AddTicks(2103),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 58, DateTimeKind.Utc).AddTicks(7347));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(881),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 59, DateTimeKind.Utc).AddTicks(9999));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 59, DateTimeKind.Utc).AddTicks(9560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 58, DateTimeKind.Utc).AddTicks(2912));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 58, DateTimeKind.Utc).AddTicks(2398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(2041),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 57, DateTimeKind.Utc).AddTicks(8035));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(1545),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 57, DateTimeKind.Utc).AddTicks(7596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(1073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 53, DateTimeKind.Utc).AddTicks(4064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(571),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 53, DateTimeKind.Utc).AddTicks(3592));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 54, DateTimeKind.Utc).AddTicks(1541));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 54, DateTimeKind.Utc).AddTicks(1024));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 53, DateTimeKind.Utc).AddTicks(1153));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7222),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 53, DateTimeKind.Utc).AddTicks(759));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 52, DateTimeKind.Utc).AddTicks(8011));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4022),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 52, DateTimeKind.Utc).AddTicks(7675));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(7124),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 52, DateTimeKind.Utc).AddTicks(2086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(6516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 12, 1, 23, 48, 52, DateTimeKind.Utc).AddTicks(1560));
        }
    }
}
