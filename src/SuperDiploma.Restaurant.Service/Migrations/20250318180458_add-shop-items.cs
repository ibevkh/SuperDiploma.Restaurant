using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperDiploma.Restaurant.Service.Migrations
{
    /// <inheritdoc />
    public partial class addshopitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "md");

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
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
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
                columns: new[] { "Id", "CategoryId", "CreatedBy", "Description", "Image", "ModifiedBy", "Name", "StateId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Якийсь опис 1", null, 1, "Товар 1", 0 },
                    { 2, 1, 1, "Якийсь опис 2", null, 1, "Товар 2", 0 },
                    { 3, 1, 1, "Якийсь опис 3", null, 1, "Товар 3", 0 },
                    { 4, 1, 1, "Якийсь опис 4", null, 1, "Товар 4", 0 },
                    { 5, 1, 1, "Якийсь опис 5", null, 1, "Товар 5", 0 },
                    { 6, 1, 1, "Якийсь опис 6", null, 1, "Товар 6", 0 },
                    { 7, 2, 1, "Якийсь опис 7", null, 1, "Товар 7", 0 },
                    { 8, 2, 1, "Якийсь опис 8", null, 1, "Товар 8", 0 },
                    { 9, 2, 1, "Якийсь опис 9", null, 1, "Товар 9", 0 },
                    { 10, 2, 1, "Якийсь опис 10", null, 1, "Товар 10", 0 },
                    { 11, 2, 1, "Якийсь опис 11", null, 1, "Товар 11", 0 },
                    { 12, 2, 1, "Якийсь опис 12", null, 1, "Товар 12", 0 },
                    { 13, 2, 1, "Якийсь опис 13", null, 1, "Товар 13", 0 },
                    { 14, 2, 1, "Якийсь опис 14", null, 1, "Товар 14", 0 },
                    { 15, 2, 1, "Якийсь опис 15", null, 1, "Товар 15", 0 }
                });

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
                name: "ShopItems",
                schema: "md");

            migrationBuilder.DropTable(
                name: "ShopItemCategories",
                schema: "md");
        }
    }
}
