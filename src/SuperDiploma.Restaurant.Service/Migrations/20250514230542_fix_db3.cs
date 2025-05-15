using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperDiploma.Restaurant.Service.Migrations
{
    /// <inheritdoc />
    public partial class fix_db3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 20);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                columns: new[] { "OrderId", "ShopItemId" });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderId", "ShopItemId", "Quantity" },
                values: new object[,]
                {
                    { 1, 6, 3 },
                    { 1, 11, 2 },
                    { 2, 2, 2 },
                    { 2, 12, 3 },
                    { 3, 3, 3 },
                    { 3, 13, 1 },
                    { 4, 4, 1 },
                    { 4, 14, 2 },
                    { 5, 5, 2 },
                    { 5, 15, 3 },
                    { 6, 1, 1 },
                    { 6, 6, 3 },
                    { 7, 2, 2 },
                    { 7, 7, 1 },
                    { 8, 3, 3 },
                    { 8, 8, 2 },
                    { 9, 4, 1 },
                    { 9, 9, 3 },
                    { 10, 5, 2 },
                    { 10, 10, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 3, 13 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumns: new[] { "OrderId", "ShopItemId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "OrderId", "Quantity", "ShopItemId" },
                values: new object[,]
                {
                    { 1, 2, 2, 2 },
                    { 2, 3, 3, 3 },
                    { 3, 4, 1, 4 },
                    { 4, 5, 2, 5 },
                    { 5, 6, 3, 6 },
                    { 6, 7, 1, 7 },
                    { 7, 8, 2, 8 },
                    { 8, 9, 3, 9 },
                    { 9, 10, 1, 10 },
                    { 10, 1, 2, 11 },
                    { 11, 2, 3, 12 },
                    { 12, 3, 1, 13 },
                    { 13, 4, 2, 14 },
                    { 14, 5, 3, 15 },
                    { 15, 6, 1, 1 },
                    { 16, 7, 2, 2 },
                    { 17, 8, 3, 3 },
                    { 18, 9, 1, 4 },
                    { 19, 10, 2, 5 },
                    { 20, 1, 3, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }
    }
}
