using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperDiploma.Restaurant.Service.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "md");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
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
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ShopItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.ShopItemId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ShopItems_ShopItemId",
                        column: x => x.ShopItemId,
                        principalSchema: "md",
                        principalTable: "ShopItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "CustomerId", "CustomerName", "CustomerPhoneNumber", "DeliveryAddress", "DeliveryTime", "IsDeleted", "ModifiedAt", "ModifiedBy", "TotalAmount" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 6, 23, 9, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 0, null, "Іван Іванов", "+380991112233", "м. Київ, вул. Хрещатик, 10", new DateTimeOffset(new DateTime(2025, 6, 23, 10, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 225m },
                    { 2, new DateTimeOffset(new DateTime(2025, 6, 23, 10, 5, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), 0, null, "Олена Петрівна", "+380661234567", "м. Київ, вул. Дорошенка, 5", new DateTimeOffset(new DateTime(2025, 6, 23, 10, 15, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 0, 0, 0)), false, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), 0, 210m }
                });

            migrationBuilder.InsertData(
                schema: "md",
                table: "ShopItemCategories",
                columns: new[] { "Id", "CreatedBy", "Description", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Основні гарячі страви", 0, "Гарячі страви" },
                    { 2, 0, "Свіжі овочеві салати", 0, "Салати" },
                    { 3, 0, "Солодощі на будь-який смак", 0, "Десерти" },
                    { 4, 0, "Попити щось)", 0, "Напої" }
                });

            migrationBuilder.InsertData(
                schema: "md",
                table: "ShopItems",
                columns: new[] { "Id", "CategoryId", "CreatedBy", "Description", "Image", "ModifiedBy", "Name", "Price", "StateId" },
                values: new object[,]
                {
                    { 1, 1, 0, "Традиційний український борщ", null, 0, "Борщ", 95m, 1 },
                    { 2, 1, 0, "Соковита курка з маслом", null, 0, "Котлета по-київськи", 130m, 1 },
                    { 3, 1, 0, "Картопляні млинці з хрусткою скоринкою", null, 0, "Деруни зі сметаною", 85m, 1 },
                    { 4, 1, 0, "Ароматний плов із свининою", null, 0, "Плов з м’ясом", 120m, 1 },
                    { 5, 1, 0, "Домашні вареники зі смаженою цибулькою", null, 0, "Вареники з картоплею", 90m, 1 },
                    { 6, 2, 0, "Салат з куркою, сухариками та соусом", null, 0, "Цезар", 120m, 1 },
                    { 7, 2, 0, "Класичний салат з майонезом", null, 0, "Олів’є", 100m, 1 },
                    { 8, 2, 0, "Овочевий салат з сиром фета", null, 0, "Грецький салат", 110m, 1 },
                    { 9, 2, 0, "Овочевий салат із буряком", null, 0, "Вінегрет", 85m, 1 },
                    { 10, 2, 0, "Салат із тунцем та свіжими овочами", null, 0, "Салат з тунцем", 125m, 1 },
                    { 11, 3, 0, "Домашній листковий торт", null, 0, "Наполеон", 80m, 1 },
                    { 12, 3, 0, "Ніжний сирний десерт", null, 0, "Чізкейк", 95m, 1 },
                    { 13, 3, 0, "Гарячий десерт із рідким шоколадом всередині", null, 0, "Шоколадний фондан", 110m, 1 },
                    { 14, 3, 0, "Випічка з яблуками та корицею", null, 0, "Яблучний штрудель", 90m, 1 },
                    { 15, 3, 0, "Кульки ванільного морозива з ягодами", null, 0, "Морозиво з фруктами", 70m, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderId", "ShopItemId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 1 },
                    { 2, 3, 2 },
                    { 2, 5, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ShopItemId",
                table: "OrderItems",
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
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShopItems",
                schema: "md");

            migrationBuilder.DropTable(
                name: "ShopItemCategories",
                schema: "md");
        }
    }
}
