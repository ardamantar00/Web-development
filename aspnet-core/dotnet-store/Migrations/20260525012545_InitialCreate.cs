using System;
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
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    CityRow = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Telephone = table.Column<string>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<double>(type: "REAL", nullable: false),
                    OrderNote = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItem_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
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
                table: "Sliders",
                columns: new[] { "Id", "Description", "Image", "Index", "IsActive", "Title" },
                values: new object[,]
                {
                    { 1, "En yeni ürünler sizi bekliyor", "slider-1.jpeg", 0, true, "Yaz Koleksiyonu" },
                    { 2, "Teknolojide en iyi fiyatlar", "slider-2.jpeg", 1, true, "Elektronik Fırsatları" },
                    { 3, "Sezonun en şık modelleri", "slider-3.jpeg", 2, true, "Giyim Kampanyası" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Image", "IsActive", "IsHome", "Price", "ProductName" },
                values: new object[,]
                {
                    { 1, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p1.jpeg", true, true, 74999.0, "Apple iPhone 15 Pro" },
                    { 2, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p2.jpeg", true, true, 64999.0, "Samsung Galaxy S24 Ultra" },
                    { 3, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p3.jpeg", true, true, 34999.0, "Xiaomi 14 Pro" },
                    { 4, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p4.jpeg", true, false, 54999.0, "Apple iPhone 14" },
                    { 5, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p5.jpeg", true, false, 19999.0, "Samsung Galaxy A54" },
                    { 6, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p6.jpeg", true, false, 39999.0, "OnePlus 12" },
                    { 7, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p7.jpeg", true, false, 49999.0, "Google Pixel 8 Pro" },
                    { 8, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p8.jpeg", true, false, 44999.0, "Huawei P60 Pro" },
                    { 9, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p9.jpeg", true, false, 24999.0, "Realme GT 5 Pro" },
                    { 10, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p10.jpeg", true, false, 21999.0, "Motorola Edge 50 Pro" },
                    { 11, 1, "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.", "p11.jpeg", true, false, 29999.0, "Apple iPhone SE 3. Nesil" },
                    { 12, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p12.jpeg", true, true, 24999.0, "Bosch Çamaşır Makinesi 9 kg" },
                    { 13, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p13.jpeg", true, true, 34999.0, "Arçelik No-Frost Buzdolabı" },
                    { 14, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p14.jpeg", true, false, 21999.0, "Samsung Bulaşık Makinesi" },
                    { 15, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p15.jpeg", true, false, 14999.0, "Vestel Solo Fırın" },
                    { 16, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p16.jpeg", true, false, 29999.0, "LG Inverter Klima 12000 BTU" },
                    { 17, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p17.jpeg", true, false, 27999.0, "Siemens Çamaşır Kurutma Makinesi" },
                    { 18, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p18.jpeg", true, false, 17999.0, "Bosch Derin Dondurucu" },
                    { 19, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p19.jpeg", true, false, 39999.0, "Arçelik Alttan Donduruculu Buzdolabı" },
                    { 20, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p20.jpeg", true, false, 17999.0, "Beko Bulaşık Makinesi" },
                    { 21, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p21.jpeg", true, false, 54999.0, "Miele Çamaşır Makinesi" },
                    { 22, 2, "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.", "p22.jpeg", true, false, 22999.0, "Tefal Ankastre Fırın" },
                    { 23, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p23.jpeg", true, true, 4999.0, "Nike Air Force 1 Sneaker" },
                    { 24, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p24.jpeg", true, true, 3499.0, "Adidas Originals Hoodie" },
                    { 25, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p25.jpeg", true, false, 4499.0, "Levi's 501 Original Jeans" },
                    { 26, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p26.jpeg", true, false, 2999.0, "Tommy Hilfiger Polo Tişört" },
                    { 27, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p27.jpeg", true, false, 7999.0, "Zara Erkek Blazer Ceket" },
                    { 28, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p28.jpeg", true, false, 3499.0, "Mango Midi Elbise" },
                    { 29, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p29.jpeg", true, false, 3999.0, "H&M Kaban" },
                    { 30, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p30.jpeg", true, false, 2499.0, "Nike Dri-FIT Eşofman Altı" },
                    { 31, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p31.jpeg", true, false, 4499.0, "Adidas Stan Smith Sneaker" },
                    { 32, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p32.jpeg", true, false, 1499.0, "LC Waikiki Oversize Sweatshirt" },
                    { 33, 3, "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.", "p33.jpeg", true, false, 2499.0, "Marks & Spencer Slim Fit Gömlek" },
                    { 34, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p34.jpeg", true, true, 849.0, "La Roche-Posay Güneş Kremi SPF50" },
                    { 35, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p35.jpeg", true, true, 1199.0, "Clinique Moisture Surge 100H Krem" },
                    { 36, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p36.jpeg", true, false, 599.0, "MAC Retro Matte Kırmızı Ruj" },
                    { 37, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p37.jpeg", true, false, 3499.0, "Dior Sauvage Erkek Parfüm 100ml" },
                    { 38, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p38.jpeg", true, false, 4999.0, "Chanel No.5 Eau de Parfum 100ml" },
                    { 39, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p39.jpeg", true, false, 349.0, "Maybelline Sky High Maskara" },
                    { 40, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p40.jpeg", true, false, 249.0, "L'Oreal Elvive Argan Şampuan 400ml" },
                    { 41, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p41.jpeg", true, false, 449.0, "Nivea Q10 Plus Gece Kremi" },
                    { 42, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p42.jpeg", true, false, 1199.0, "NARS Natural Radiant Longwear Fondöten" },
                    { 43, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p43.jpeg", true, false, 549.0, "Vichy Micellar Su Hassas Cilt 400ml" },
                    { 44, 4, "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.", "p44.jpeg", true, false, 3999.0, "Estee Lauder Advanced Night Repair Serum" },
                    { 45, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p45.jpeg", true, true, 119999.0, "Apple MacBook Pro 14 inc M3 Pro" },
                    { 46, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p46.jpeg", true, true, 54999.0, "Samsung QLED 55 inc 4K Smart TV" },
                    { 47, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p47.jpeg", true, false, 8499.0, "Sony WH-1000XM5 Kablosuz Kulaklık" },
                    { 48, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p48.jpeg", true, false, 64999.0, "Apple iPad Pro 12.9 inc M2" },
                    { 49, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p49.jpeg", true, false, 84999.0, "Dell XPS 15 Intel Core i7 Laptop" },
                    { 50, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p50.jpeg", true, false, 3499.0, "Logitech MX Master 3S Mouse" },
                    { 51, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p51.jpeg", true, false, 8499.0, "Apple AirPods Pro 2. Nesil" },
                    { 52, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p52.jpeg", true, false, 34999.0, "Canon EOS R50 Aynasız Fotoğraf Makinesi" },
                    { 53, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p53.jpeg", true, false, 24999.0, "Sony PlayStation 5 Disk Sürücülü" },
                    { 54, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p54.jpeg", true, false, 17999.0, "LG UltraGear 27 inc QHD 165Hz Monitör" },
                    { 55, 5, "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.", "p55.jpeg", true, false, 15999.0, "Apple Watch Series 9 GPS 45mm" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
