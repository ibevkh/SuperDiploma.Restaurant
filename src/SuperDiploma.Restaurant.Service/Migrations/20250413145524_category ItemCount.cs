using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperDiploma.Restaurant.Service.Migrations
{
    /// <inheritdoc />
    public partial class categoryItemCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TableDbo",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "md",
                table: "ShopItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ItemCount",
                schema: "md",
                table: "ShopItemCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 7,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 8,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 9,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 10,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 11,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 12,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 13,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 14,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItemCategories",
                keyColumn: "Id",
                keyValue: 15,
                column: "ItemCount",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "StateId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "StateId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "StateId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "StateId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "StateId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "StateId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "StateId",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "StateId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "StateId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "StateId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "StateId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "StateId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "StateId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "StateId",
                value: 1);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "StateId",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemCount",
                schema: "md",
                table: "ShopItemCategories");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "md",
                table: "ShopItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Перші страви" },
                    { 2, "Другі страви" },
                    { 3, "Десерти" },
                    { 4, "Салати" }
                });

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 9,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 11,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 12,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 13,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 14,
                column: "StateId",
                value: 0);

            migrationBuilder.UpdateData(
                schema: "md",
                table: "ShopItems",
                keyColumn: "Id",
                keyValue: 15,
                column: "StateId",
                value: 0);

            migrationBuilder.InsertData(
                table: "TableDbo",
                columns: new[] { "Id", "Capacity", "IsAvailable", "TableNumber" },
                values: new object[,]
                {
                    { 1, 4, true, 1 },
                    { 2, 4, true, 2 },
                    { 3, 4, true, 3 },
                    { 4, 4, true, 4 },
                    { 5, 6, true, 5 },
                    { 6, 6, true, 6 },
                    { 7, 6, true, 7 },
                    { 8, 8, true, 8 },
                    { 9, 8, true, 9 },
                    { 10, 2, true, 10 },
                    { 11, 2, true, 11 }
                });
        }
    }
}
