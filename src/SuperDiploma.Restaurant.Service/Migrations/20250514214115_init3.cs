using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperDiploma.Restaurant.Service.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopItemId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShopItemId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShopItemId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                column: "ShopItemId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                column: "ShopItemId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShopItemId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                column: "ShopItemId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                column: "ShopItemId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                column: "ShopItemId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9,
                column: "ShopItemId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 10,
                column: "ShopItemId",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopItemId",
                table: "Order");
        }
    }
}
