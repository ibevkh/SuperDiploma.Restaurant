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
                name: "AdminDbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminDbo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Entrance = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrders", x => x.Id);
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
                name: "TableDbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableNumber = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableDbo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryDboId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_Categories_CategoryDboId",
                        column: x => x.CategoryDboId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dishes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
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
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_CustomerOrders_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_TableDbo_TableId",
                        column: x => x.TableId,
                        principalTable: "TableDbo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderOrders_CustomerOrders_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderOrders_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    DishMenuItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Dishes_DishMenuItemId",
                        column: x => x.DishMenuItemId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_OrderOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                schema: "md",
                table: "ShopItems",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "Description", "Image", "ModifiedBy", "Name", "Price", "StateId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Якийсь опис 1", null, 1, "Товар 1", 0m, 2 },
                    { 2, 1, 1, "Якийсь опис 2", null, 1, "Товар 2", 0m, 2 },
                    { 3, 1, 1, "Якийсь опис 3", null, 1, "Товар 3", 0m, 2 },
                    { 4, 1, 1, "Якийсь опис 4", null, 1, "Товар 4", 0m, 2 },
                    { 5, 1, 1, "Якийсь опис 5", null, 1, "Товар 5", 0m, 2 },
                    { 6, 1, 1, "Якийсь опис 6", null, 1, "Товар 6", 0m, 2 },
                    { 7, 2, 1, "Якийсь опис 7", null, 1, "Товар 7", 0m, 2 },
                    { 8, 2, 1, "Якийсь опис 8", null, 1, "Товар 8", 0m, 1 },
                    { 9, 2, 1, "Якийсь опис 9", null, 1, "Товар 9", 0m, 1 },
                    { 10, 2, 1, "Якийсь опис 10", null, 1, "Товар 10", 0m, 1 },
                    { 11, 2, 1, "Якийсь опис 11", null, 1, "Товар 11", 0m, 1 },
                    { 12, 2, 1, "Якийсь опис 12", null, 1, "Товар 12", 0m, 1 },
                    { 13, 2, 1, "Якийсь опис 13", null, 1, "Товар 13", 0m, 1 },
                    { 14, 2, 1, "Якийсь опис 14", null, 1, "Товар 14", 0m, 1 },
                    { 15, 2, 1, "Якийсь опис 15", null, 1, "Товар 15", 0m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryDboId",
                table: "Dishes",
                column: "CategoryDboId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CategoryId",
                table: "Dishes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_DishMenuItemId",
                table: "OrderItems",
                column: "DishMenuItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrders_CustomerId",
                table: "OrderOrders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderOrders_ReservationId",
                table: "OrderOrders",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TableId",
                table: "Reservations",
                column: "TableId");

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
                name: "AdminDbo");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ShopItems",
                schema: "md");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "OrderOrders");

            migrationBuilder.DropTable(
                name: "ShopItemCategories",
                schema: "md");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "CustomerOrders");

            migrationBuilder.DropTable(
                name: "TableDbo");
        }
    }
}
