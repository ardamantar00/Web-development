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
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Image", "IsActive", "IsHome", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "1.jpeg", true, true, 40000.0, "Apple Watch 7" },
                    { 2, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "1.jpeg", true, false, 50000.0, "Apple Watch 8" },
                    { 3, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "1.jpeg", false, true, 60000.0, "Apple Watch 9" },
                    { 4, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "1.jpeg", false, true, 70000.0, "Apple Watch 10" },
                    { 5, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "1.jpeg", true, false, 80000.0, "Apple Watch 11" },
                    { 6, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "1.jpeg", true, true, 85000.0, "Apple Watch 12" },
                    { 7, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "1.jpeg", true, false, 90000.0, "Apple Watch 13" },
                    { 8, "Lorem ipsum dolor sit amet consectetur, adipisicing elit. Eius explicabo voluptatibus aperiam voluptate dignissimos expedita aspernatur similique vero exercitationem dicta, tempore repudiandae alias? Expedita, debitis ratione voluptates in fugiat exercitationem?", "1.jpeg", false, true, 95000.0, "Apple Watch 14" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
