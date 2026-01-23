using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dotnet_store.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "Url" },
                values: new object[,]
                {
                    { 1, "Telefon", "telefon" },
                    { 2, "Beyaz Eşya", "beyaz-esya" },
                    { 3, "Giyim", "giyim" },
                    { 4, "Kozmetik", "kozmetik" },
                    { 5, "Elektronik", "elektronik" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "IsActive", "IsHome", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "1.jpeg", true, true, 40000.0, "Apple Watch 7" },
                    { 2, 2, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "2.jpeg", true, false, 50000.0, "Apple Watch 8" },
                    { 3, 2, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "3.jpeg", false, true, 60000.0, "Apple Watch 9" },
                    { 4, 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "4.jpeg", false, true, 70000.0, "sApple Watch 10" },
                    { 5, 4, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "5.jpeg", true, false, 80000.0, "Apsple Watch 11" },
                    { 6, 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "6.jpeg", true, true, 85000.0, "Apple Watch 12" },
                    { 7, 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "7.jpeg", true, false, 90000.0, "Apple Watch 13" },
                    { 8, 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "8.jpeg", false, true, 95000.0, "Apple Watch 14" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
