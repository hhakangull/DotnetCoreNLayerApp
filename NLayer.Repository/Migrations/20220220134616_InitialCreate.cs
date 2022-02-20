using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeature",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeature_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Kalemler Description", "Kalemler", null },
                    { 2, "Defterler Description", "Defterler", null },
                    { 3, "Çantalar Description", "Çantalar", null },
                    { 4, "Kılıflar Description", "Kılıflar", null },
                    { 5, "Oyun Hamurları Description", "Oyun Hamurları", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "IsActive", "IsDeleted", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 2, 20, 16, 46, 16, 158, DateTimeKind.Local).AddTicks(1826), "Tükenmez Kalem Description", true, false, "Tükenmez Kalem", 10m, 10000, null },
                    { 2, 2, new DateTime(2022, 2, 20, 16, 46, 16, 158, DateTimeKind.Local).AddTicks(1838), "Çizgisiz Defter Description", true, false, "Çizgisiz Defter", 200m, 200, null },
                    { 3, 3, new DateTime(2022, 2, 20, 16, 46, 16, 158, DateTimeKind.Local).AddTicks(1839), "Spor Çantası Description", true, false, "Spor Çantası", 31m, 3300, null },
                    { 4, 4, new DateTime(2022, 2, 20, 16, 46, 16, 158, DateTimeKind.Local).AddTicks(1840), "Kılıf Description", true, false, "Kılıf", 250m, 6400, null },
                    { 5, 5, new DateTime(2022, 2, 20, 16, 46, 16, 158, DateTimeKind.Local).AddTicks(1841), "Play Doh Oyun Hamuru Description", true, false, "Play Doh Oyun Hamuru", 420m, 1300, null }
                });

            migrationBuilder.InsertData(
                table: "ProductFeature",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[] { 1, "Kırmızı", 100, 1, 200 });

            migrationBuilder.InsertData(
                table: "ProductFeature",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[] { 2, "Siyah", 200, 2, 300 });

            migrationBuilder.InsertData(
                table: "ProductFeature",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[] { 3, "Yeşil", 300, 3, 400 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeature_ProductId",
                table: "ProductFeature",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeature");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
