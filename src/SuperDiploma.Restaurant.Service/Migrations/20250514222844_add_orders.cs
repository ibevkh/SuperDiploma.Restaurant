using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperDiploma.Restaurant.Service.Migrations
{
    /// <inheritdoc />
    public partial class add_orders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopItemId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "CustomerAddress",
                table: "Order",
                newName: "DeliveryAddress");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DeliveryTime",
                table: "Order",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeliveryTime",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2,
                column: "DeliveryTime",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3,
                column: "DeliveryTime",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 4,
                column: "DeliveryTime",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 5,
                column: "DeliveryTime",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 6,
                column: "DeliveryTime",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 7,
                column: "DeliveryTime",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 8,
                column: "DeliveryTime",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 9,
                column: "DeliveryTime",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 10,
                column: "DeliveryTime",
                value: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryTime",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddress",
                table: "Order",
                newName: "CustomerAddress");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
