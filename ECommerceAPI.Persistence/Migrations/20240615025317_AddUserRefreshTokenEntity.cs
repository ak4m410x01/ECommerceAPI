using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceAPI.Persistence.Migrations
{
    /// <inheritdoc/>
    public partial class AddUserRefreshTokenEntity : Migration
    {
        /// <inheritdoc/>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 56, DateTimeKind.Utc).AddTicks(2784),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 604, DateTimeKind.Utc).AddTicks(2448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 56, DateTimeKind.Utc).AddTicks(546),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 604, DateTimeKind.Utc).AddTicks(2103));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 57, DateTimeKind.Utc).AddTicks(8357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(881));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 57, DateTimeKind.Utc).AddTicks(5860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 55, DateTimeKind.Utc).AddTicks(5142),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 55, DateTimeKind.Utc).AddTicks(4628),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 54, DateTimeKind.Utc).AddTicks(9298),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(2041));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 54, DateTimeKind.Utc).AddTicks(7015),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 47, DateTimeKind.Utc).AddTicks(9433),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(1073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 47, DateTimeKind.Utc).AddTicks(8763),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 49, DateTimeKind.Utc).AddTicks(3130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 49, DateTimeKind.Utc).AddTicks(2547),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(171));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 47, DateTimeKind.Utc).AddTicks(4596),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7661));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 47, DateTimeKind.Utc).AddTicks(3980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7222));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 47, DateTimeKind.Utc).AddTicks(219),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 46, DateTimeKind.Utc).AddTicks(9653),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4022));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 46, DateTimeKind.Utc).AddTicks(3472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(7124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 46, DateTimeKind.Utc).AddTicks(2863),
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
                    IsExpired = table.Column<bool>(type: "bit", nullable: false, computedColumnSql: "CASE WHEN [ExpiresAt] <= GETUTCDATE() THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END"),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, computedColumnSql: "CASE WHEN [RevokedAt] IS NULL AND [ExpiresAt] > GETUTCDATE() THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 56, DateTimeKind.Utc).AddTicks(6288)),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 56, DateTimeKind.Utc).AddTicks(6767)),
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

        /// <inheritdoc/>
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
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 56, DateTimeKind.Utc).AddTicks(2784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 604, DateTimeKind.Utc).AddTicks(2103),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 56, DateTimeKind.Utc).AddTicks(546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(881),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 57, DateTimeKind.Utc).AddTicks(8357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "User",
                table: "UserAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 605, DateTimeKind.Utc).AddTicks(419),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 57, DateTimeKind.Utc).AddTicks(5860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6937),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 55, DateTimeKind.Utc).AddTicks(5142));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(6406),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 55, DateTimeKind.Utc).AddTicks(4628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(2041),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 54, DateTimeKind.Utc).AddTicks(9298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductVariants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 603, DateTimeKind.Utc).AddTicks(1545),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 54, DateTimeKind.Utc).AddTicks(7015));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(1073),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 47, DateTimeKind.Utc).AddTicks(9433));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 597, DateTimeKind.Utc).AddTicks(571),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 47, DateTimeKind.Utc).AddTicks(8763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(789),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 49, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 598, DateTimeKind.Utc).AddTicks(171),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 49, DateTimeKind.Utc).AddTicks(2547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 47, DateTimeKind.Utc).AddTicks(4596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(7222),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 47, DateTimeKind.Utc).AddTicks(3980));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 47, DateTimeKind.Utc).AddTicks(219));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Discounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 596, DateTimeKind.Utc).AddTicks(4022),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 46, DateTimeKind.Utc).AddTicks(9653));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(7124),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 46, DateTimeKind.Utc).AddTicks(3472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Product",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 2, 23, 26, 50, 595, DateTimeKind.Utc).AddTicks(6516),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 15, 2, 53, 17, 46, DateTimeKind.Utc).AddTicks(2863));
        }
    }
}