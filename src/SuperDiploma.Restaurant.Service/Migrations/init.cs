using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperDiploma.Restaurant.Service.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "md");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Entrance = table.Column<int>(type: "int", nullable: false),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShopItemCategories",
                schema: "md",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopItems",
                schema: "md",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopItems_ShopItemCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "md",
                        principalTable: "ShopItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemDbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ShopItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemDbo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItemDbo_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItemDbo_ShopItems_ShopItemId",
                        column: x => x.ShopItemId,
                        principalSchema: "md",
                        principalTable: "ShopItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Address", "ApartmentNumber", "CreatedAt", "CreatedBy", "Entrance", "IsDeleted", "ModifiedAt", "ModifiedBy", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Вулиця №1", 11, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 1, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Клієнт 1", "12345000 + i" },
                    { 2, "Вулиця №2", 12, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 2, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Клієнт 2", "12345000 + i" },
                    { 3, "Вулиця №3", 13, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 3, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Клієнт 3", "12345000 + i" },
                    { 4, "Вулиця №4", 14, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 4, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Клієнт 4", "12345000 + i" },
                    { 5, "Вулиця №5", 15, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, 5, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, "Клієнт 5", "12345000 + i" }
                });

            migrationBuilder.InsertData(
                schema: "md",
                table: "ShopItemCategories",
                columns: new[] { "Id", "CreatedBy", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Якийсь опис 1", 1, "Категорія 1" },
                    { 2, 1, "Якийсь опис 2", 1, "Категорія 2" },
                    { 3, 1, "Якийсь опис 3", 1, "Категорія 3" },
                    { 4, 1, "Якийсь опис 4", 1, "Категорія 4" },
                    { 5, 1, "Якийсь опис 5", 1, "Категорія 5" },
                    { 6, 1, "Якийсь опис 6", 1, "Категорія 6" },
                    { 7, 1, "Якийсь опис 7", 1, "Категорія 7" },
                    { 8, 1, "Якийсь опис 8", 1, "Категорія 8" },
                    { 9, 1, "Якийсь опис 9", 1, "Категорія 9" },
                    { 10, 1, "Якийсь опис 10", 1, "Категорія 10" },
                    { 11, 1, "Якийсь опис 11", 1, "Категорія 11" },
                    { 12, 1, "Якийсь опис 12", 1, "Категорія 12" },
                    { 13, 1, "Якийсь опис 13", 1, "Категорія 13" },
                    { 14, 1, "Якийсь опис 14", 1, "Категорія 14" },
                    { 15, 1, "Якийсь опис 15", 1, "Категорія 15" }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CustomerAddress", "CustomerId", "CustomerName", "CustomerPhoneNumber", "IsDeleted", "ModifiedAt", "ModifiedBy" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 2, null, null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 3, null, null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 4, null, null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 5, null, null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 1, null, null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 6, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 2, null, null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 7, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 3, null, null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 8, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 4, null, null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 9, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 5, null, null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 },
                    { 10, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1, null, 1, null, null, false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 1 }
                });

            migrationBuilder.InsertData(
                schema: "md",
                table: "ShopItems",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "Description", "Image", "ModifiedBy", "Name", "Price", "StateId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Якийсь опис 1", null, 1, "Товар 1", 100m, 2 },
                    { 2, 1, 1, "Якийсь опис 2", null, 1, "Товар 2", 100m, 2 },
                    { 3, 1, 1, "Якийсь опис 3", null, 1, "Товар 3", 100m, 2 },
                    { 4, 1, 1, "Якийсь опис 4", null, 1, "Товар 4", 100m, 2 },
                    { 5, 1, 1, "Якийсь опис 5", null, 1, "Товар 5", 100m, 2 },
                    { 6, 1, 1, "Якийсь опис 6", null, 1, "Товар 6", 100m, 2 },
                    { 7, 2, 1, "Якийсь опис 7", null, 1, "Товар 7", 100m, 2 },
                    { 8, 2, 1, "Якийсь опис 8", null, 1, "Товар 8", 100m, 1 },
                    { 9, 2, 1, "Якийсь опис 9", null, 1, "Товар 9", 100m, 1 },
                    { 10, 2, 1, "Якийсь опис 10", null, 1, "Товар 10", 100m, 1 },
                    { 11, 2, 1, "Якийсь опис 11", null, 1, "Товар 11", 100m, 1 },
                    { 12, 2, 1, "Якийсь опис 12", null, 1, "Товар 12", 100m, 1 },
                    { 13, 2, 1, "Якийсь опис 13", null, 1, "Товар 13", 100m, 1 },
                    { 14, 2, 1, "Якийсь опис 14", null, 1, "Товар 14", 100m, 1 },
                    { 15, 2, 1, "Якийсь опис 15", null, 1, "Товар 15", 100m, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderItemDbo",
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
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDbo_OrderId",
                table: "OrderItemDbo",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemDbo_ShopItemId",
                table: "OrderItemDbo",
                column: "ShopItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItems_CategoryId",
                schema: "md",
                table: "ShopItems",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItemDbo");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ShopItems",
                schema: "md");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "ShopItemCategories",
                schema: "md");
        }
    }
}
