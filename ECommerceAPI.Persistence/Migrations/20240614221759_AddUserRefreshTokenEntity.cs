using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRefreshTokenEntity : Migration
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
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 475, DateTimeKind.Utc).AddTicks(5332),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 604, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 475, DateTimeKind.Utc).AddTicks(4869),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 604, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 477, DateTimeKind.Utc).AddTicks(4832),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(881));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 477, DateTimeKind.Utc).AddTicks(3998),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 474, DateTimeKind.Utc).AddTicks(9862),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 474, DateTimeKind.Utc).AddTicks(9306),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 474, DateTimeKind.Utc).AddTicks(2149),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(2041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 474, DateTimeKind.Utc).AddTicks(1343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 467, DateTimeKind.Utc).AddTicks(2738),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 467, DateTimeKind.Utc).AddTicks(1846),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 468, DateTimeKind.Utc).AddTicks(3983),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 468, DateTimeKind.Utc).AddTicks(3162),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 466, DateTimeKind.Utc).AddTicks(8021),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 466, DateTimeKind.Utc).AddTicks(7348),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7222));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 466, DateTimeKind.Utc).AddTicks(3374),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 466, DateTimeKind.Utc).AddTicks(2695),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 465, DateTimeKind.Utc).AddTicks(5026),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(7124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 465, DateTimeKind.Utc).AddTicks(4137),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(6516));

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 476, DateTimeKind.Utc).AddTicks(1851)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 476, DateTimeKind.Utc).AddTicks(2698)),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
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
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 475, DateTimeKind.Utc).AddTicks(5332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 604, DateTimeKind.Utc).AddTicks(2103),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 475, DateTimeKind.Utc).AddTicks(4869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(881),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 477, DateTimeKind.Utc).AddTicks(4832));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 477, DateTimeKind.Utc).AddTicks(3998));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 474, DateTimeKind.Utc).AddTicks(9862));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 474, DateTimeKind.Utc).AddTicks(9306));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(2041),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 474, DateTimeKind.Utc).AddTicks(2149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(1545),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 474, DateTimeKind.Utc).AddTicks(1343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(1073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 467, DateTimeKind.Utc).AddTicks(2738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(571),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 467, DateTimeKind.Utc).AddTicks(1846));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 468, DateTimeKind.Utc).AddTicks(3983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 468, DateTimeKind.Utc).AddTicks(3162));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 466, DateTimeKind.Utc).AddTicks(8021));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7222),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 466, DateTimeKind.Utc).AddTicks(7348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 466, DateTimeKind.Utc).AddTicks(3374));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4022),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 466, DateTimeKind.Utc).AddTicks(2695));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(7124),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 465, DateTimeKind.Utc).AddTicks(5026));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(6516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 14, 22, 17, 58, 465, DateTimeKind.Utc).AddTicks(4137));
        }
    }
}
