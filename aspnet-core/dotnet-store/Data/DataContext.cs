using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Models;

public class DataContext : IdentityDbContext<AppUser,AppRole,int>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet <Order> Orders { get; set; } 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Slider>().HasData(
            new Slider { Id = 1, Title = "Yaz Koleksiyonu", Description = "En yeni ürünler sizi bekliyor", Image = "slider-1.jpeg", Index = 0, IsActive = true },
            new Slider { Id = 2, Title = "Elektronik Fırsatları", Description = "Teknolojide en iyi fiyatlar", Image = "slider-2.jpeg", Index = 1, IsActive = true },
            new Slider { Id = 3, Title = "Giyim Kampanyası", Description = "Sezonun en şık modelleri", Image = "slider-3.jpeg", Index = 2, IsActive = true }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, CategoryName = "Telefon", Url = "telefon" },
            new Category { Id = 2, CategoryName = "Beyaz Eşya", Url = "beyaz-esya" },
            new Category { Id = 3, CategoryName = "Giyim", Url = "giyim" },
            new Category { Id = 4, CategoryName = "Kozmetik", Url = "kozmetik" },
            new Category { Id = 5, CategoryName = "Elektronik", Url = "elektronik" }
        );

        var phoneDesc = "En son işlemci teknolojisi ve gelişmiş kamera sistemiyle donatılmış premium akıllı telefon. 5G bağlantı desteği, uzun pil ömrü ve yüksek yenileme hızlı ekranıyla günlük kullanımda üstün deneyim sunar.";
        var applianceDesc = "Enerji tasarruflu A+++ sınıfı inverter motor teknolojisiyle donatılmış ev elektroniği. Akıllı programlar, sessiz çalışma modu ve uzun ömürlü yapısıyla evinizde maksimum konfor sağlar.";
        var clothingDesc = "Premium kalite doğal kumaştan üretilen bu parça; şık kesimi ve konforlu yapısıyla öne çıkar. Günlük kullanımdan özel günlere kadar her stile uyum sağlayan çok yönlü bir seçim.";
        var cosmeticDesc = "Dermatolojik testlerden geçmiş, hipoalerjenik formülüyle tüm cilt tiplerine uygundur. Aktif bileşenleri ve nemlendirici içerikleriyle cildinizi besler, korur ve güzelleştirir.";
        var electronicsDesc = "Son nesil işlemci ve yüksek çözünürlüklü ekranıyla üstün performans sunar. Uzun pil ömrü, gelişmiş bağlantı seçenekleri ve ergonomik tasarımıyla hem iş hem eğlence için idealdir.";

        modelBuilder.Entity<Product>().HasData(
            // ── TELEFON ──
            new Product { Id = 1,  ProductName = "Apple iPhone 15 Pro",                     Price = 74999,  IsActive = true, Image = "p1.jpeg",  IsHome = true,  CategoryId = 1, Description = phoneDesc },
            new Product { Id = 2,  ProductName = "Samsung Galaxy S24 Ultra",                 Price = 64999,  IsActive = true, Image = "p2.jpeg",  IsHome = true,  CategoryId = 1, Description = phoneDesc },
            new Product { Id = 3,  ProductName = "Xiaomi 14 Pro",                            Price = 34999,  IsActive = true, Image = "p3.jpeg",  IsHome = true,  CategoryId = 1, Description = phoneDesc },
            new Product { Id = 4,  ProductName = "Apple iPhone 14",                          Price = 54999,  IsActive = true, Image = "p4.jpeg",  IsHome = false, CategoryId = 1, Description = phoneDesc },
            new Product { Id = 5,  ProductName = "Samsung Galaxy A54",                       Price = 19999,  IsActive = true, Image = "p5.jpeg",  IsHome = false, CategoryId = 1, Description = phoneDesc },
            new Product { Id = 6,  ProductName = "OnePlus 12",                               Price = 39999,  IsActive = true, Image = "p6.jpeg",  IsHome = false, CategoryId = 1, Description = phoneDesc },
            new Product { Id = 7,  ProductName = "Google Pixel 8 Pro",                       Price = 49999,  IsActive = true, Image = "p7.jpeg",  IsHome = false, CategoryId = 1, Description = phoneDesc },
            new Product { Id = 8,  ProductName = "Huawei P60 Pro",                           Price = 44999,  IsActive = true, Image = "p8.jpeg",  IsHome = false, CategoryId = 1, Description = phoneDesc },
            new Product { Id = 9,  ProductName = "Realme GT 5 Pro",                          Price = 24999,  IsActive = true, Image = "p9.jpeg",  IsHome = false, CategoryId = 1, Description = phoneDesc },
            new Product { Id = 10, ProductName = "Motorola Edge 50 Pro",                     Price = 21999,  IsActive = true, Image = "p10.jpeg", IsHome = false, CategoryId = 1, Description = phoneDesc },
            new Product { Id = 11, ProductName = "Apple iPhone SE 3. Nesil",                 Price = 29999,  IsActive = true, Image = "p11.jpeg", IsHome = false, CategoryId = 1, Description = phoneDesc },

            // ── BEYAZ EŞYA ──
            new Product { Id = 12, ProductName = "Bosch Çamaşır Makinesi 9 kg",             Price = 24999,  IsActive = true, Image = "p12.jpeg", IsHome = true,  CategoryId = 2, Description = applianceDesc },
            new Product { Id = 13, ProductName = "Arçelik No-Frost Buzdolabı",               Price = 34999,  IsActive = true, Image = "p13.jpeg", IsHome = true,  CategoryId = 2, Description = applianceDesc },
            new Product { Id = 14, ProductName = "Samsung Bulaşık Makinesi",                 Price = 21999,  IsActive = true, Image = "p14.jpeg", IsHome = false, CategoryId = 2, Description = applianceDesc },
            new Product { Id = 15, ProductName = "Vestel Solo Fırın",                        Price = 14999,  IsActive = true, Image = "p15.jpeg", IsHome = false, CategoryId = 2, Description = applianceDesc },
            new Product { Id = 16, ProductName = "LG Inverter Klima 12000 BTU",              Price = 29999,  IsActive = true, Image = "p16.jpeg", IsHome = false, CategoryId = 2, Description = applianceDesc },
            new Product { Id = 17, ProductName = "Siemens Çamaşır Kurutma Makinesi",        Price = 27999,  IsActive = true, Image = "p17.jpeg", IsHome = false, CategoryId = 2, Description = applianceDesc },
            new Product { Id = 18, ProductName = "Bosch Derin Dondurucu",                    Price = 17999,  IsActive = true, Image = "p18.jpeg", IsHome = false, CategoryId = 2, Description = applianceDesc },
            new Product { Id = 19, ProductName = "Arçelik Alttan Donduruculu Buzdolabı",    Price = 39999,  IsActive = true, Image = "p19.jpeg", IsHome = false, CategoryId = 2, Description = applianceDesc },
            new Product { Id = 20, ProductName = "Beko Bulaşık Makinesi",                   Price = 17999,  IsActive = true, Image = "p20.jpeg", IsHome = false, CategoryId = 2, Description = applianceDesc },
            new Product { Id = 21, ProductName = "Miele Çamaşır Makinesi",                  Price = 54999,  IsActive = true, Image = "p21.jpeg", IsHome = false, CategoryId = 2, Description = applianceDesc },
            new Product { Id = 22, ProductName = "Tefal Ankastre Fırın",                     Price = 22999,  IsActive = true, Image = "p22.jpeg", IsHome = false, CategoryId = 2, Description = applianceDesc },

            // ── GİYİM ──
            new Product { Id = 23, ProductName = "Nike Air Force 1 Sneaker",                Price = 4999,   IsActive = true, Image = "p23.jpeg", IsHome = true,  CategoryId = 3, Description = clothingDesc },
            new Product { Id = 24, ProductName = "Adidas Originals Hoodie",                 Price = 3499,   IsActive = true, Image = "p24.jpeg", IsHome = true,  CategoryId = 3, Description = clothingDesc },
            new Product { Id = 25, ProductName = "Levi's 501 Original Jeans",               Price = 4499,   IsActive = true, Image = "p25.jpeg", IsHome = false, CategoryId = 3, Description = clothingDesc },
            new Product { Id = 26, ProductName = "Tommy Hilfiger Polo Tişört",              Price = 2999,   IsActive = true, Image = "p26.jpeg", IsHome = false, CategoryId = 3, Description = clothingDesc },
            new Product { Id = 27, ProductName = "Zara Erkek Blazer Ceket",                 Price = 7999,   IsActive = true, Image = "p27.jpeg", IsHome = false, CategoryId = 3, Description = clothingDesc },
            new Product { Id = 28, ProductName = "Mango Midi Elbise",                       Price = 3499,   IsActive = true, Image = "p28.jpeg", IsHome = false, CategoryId = 3, Description = clothingDesc },
            new Product { Id = 29, ProductName = "H&M Kaban",                               Price = 3999,   IsActive = true, Image = "p29.jpeg", IsHome = false, CategoryId = 3, Description = clothingDesc },
            new Product { Id = 30, ProductName = "Nike Dri-FIT Eşofman Altı",              Price = 2499,   IsActive = true, Image = "p30.jpeg", IsHome = false, CategoryId = 3, Description = clothingDesc },
            new Product { Id = 31, ProductName = "Adidas Stan Smith Sneaker",               Price = 4499,   IsActive = true, Image = "p31.jpeg", IsHome = false, CategoryId = 3, Description = clothingDesc },
            new Product { Id = 32, ProductName = "LC Waikiki Oversize Sweatshirt",          Price = 1499,   IsActive = true, Image = "p32.jpeg", IsHome = false, CategoryId = 3, Description = clothingDesc },
            new Product { Id = 33, ProductName = "Marks & Spencer Slim Fit Gömlek",         Price = 2499,   IsActive = true, Image = "p33.jpeg", IsHome = false, CategoryId = 3, Description = clothingDesc },

            // ── KOZMETİK ──
            new Product { Id = 34, ProductName = "La Roche-Posay Güneş Kremi SPF50",       Price = 849,    IsActive = true, Image = "p34.jpeg", IsHome = true,  CategoryId = 4, Description = cosmeticDesc },
            new Product { Id = 35, ProductName = "Clinique Moisture Surge 100H Krem",       Price = 1199,   IsActive = true, Image = "p35.jpeg", IsHome = true,  CategoryId = 4, Description = cosmeticDesc },
            new Product { Id = 36, ProductName = "MAC Retro Matte Kırmızı Ruj",            Price = 599,    IsActive = true, Image = "p36.jpeg", IsHome = false, CategoryId = 4, Description = cosmeticDesc },
            new Product { Id = 37, ProductName = "Dior Sauvage Erkek Parfüm 100ml",        Price = 3499,   IsActive = true, Image = "p37.jpeg", IsHome = false, CategoryId = 4, Description = cosmeticDesc },
            new Product { Id = 38, ProductName = "Chanel No.5 Eau de Parfum 100ml",        Price = 4999,   IsActive = true, Image = "p38.jpeg", IsHome = false, CategoryId = 4, Description = cosmeticDesc },
            new Product { Id = 39, ProductName = "Maybelline Sky High Maskara",             Price = 349,    IsActive = true, Image = "p39.jpeg", IsHome = false, CategoryId = 4, Description = cosmeticDesc },
            new Product { Id = 40, ProductName = "L'Oreal Elvive Argan Şampuan 400ml",     Price = 249,    IsActive = true, Image = "p40.jpeg", IsHome = false, CategoryId = 4, Description = cosmeticDesc },
            new Product { Id = 41, ProductName = "Nivea Q10 Plus Gece Kremi",               Price = 449,    IsActive = true, Image = "p41.jpeg", IsHome = false, CategoryId = 4, Description = cosmeticDesc },
            new Product { Id = 42, ProductName = "NARS Natural Radiant Longwear Fondöten", Price = 1199,   IsActive = true, Image = "p42.jpeg", IsHome = false, CategoryId = 4, Description = cosmeticDesc },
            new Product { Id = 43, ProductName = "Vichy Micellar Su Hassas Cilt 400ml",    Price = 549,    IsActive = true, Image = "p43.jpeg", IsHome = false, CategoryId = 4, Description = cosmeticDesc },
            new Product { Id = 44, ProductName = "Estee Lauder Advanced Night Repair Serum", Price = 3999, IsActive = true, Image = "p44.jpeg", IsHome = false, CategoryId = 4, Description = cosmeticDesc },

            // ── ELEKTRONİK ──
            new Product { Id = 45, ProductName = "Apple MacBook Pro 14 inc M3 Pro",        Price = 119999, IsActive = true, Image = "p45.jpeg", IsHome = true,  CategoryId = 5, Description = electronicsDesc },
            new Product { Id = 46, ProductName = "Samsung QLED 55 inc 4K Smart TV",        Price = 54999,  IsActive = true, Image = "p46.jpeg", IsHome = true,  CategoryId = 5, Description = electronicsDesc },
            new Product { Id = 47, ProductName = "Sony WH-1000XM5 Kablosuz Kulaklık",     Price = 8499,   IsActive = true, Image = "p47.jpeg", IsHome = false, CategoryId = 5, Description = electronicsDesc },
            new Product { Id = 48, ProductName = "Apple iPad Pro 12.9 inc M2",             Price = 64999,  IsActive = true, Image = "p48.jpeg", IsHome = false, CategoryId = 5, Description = electronicsDesc },
            new Product { Id = 49, ProductName = "Dell XPS 15 Intel Core i7 Laptop",       Price = 84999,  IsActive = true, Image = "p49.jpeg", IsHome = false, CategoryId = 5, Description = electronicsDesc },
            new Product { Id = 50, ProductName = "Logitech MX Master 3S Mouse",             Price = 3499,   IsActive = true, Image = "p50.jpeg", IsHome = false, CategoryId = 5, Description = electronicsDesc },
            new Product { Id = 51, ProductName = "Apple AirPods Pro 2. Nesil",              Price = 8499,   IsActive = true, Image = "p51.jpeg", IsHome = false, CategoryId = 5, Description = electronicsDesc },
            new Product { Id = 52, ProductName = "Canon EOS R50 Aynasız Fotoğraf Makinesi", Price = 34999, IsActive = true, Image = "p52.jpeg", IsHome = false, CategoryId = 5, Description = electronicsDesc },
            new Product { Id = 53, ProductName = "Sony PlayStation 5 Disk Sürücülü",       Price = 24999,  IsActive = true, Image = "p53.jpeg", IsHome = false, CategoryId = 5, Description = electronicsDesc },
            new Product { Id = 54, ProductName = "LG UltraGear 27 inc QHD 165Hz Monitör", Price = 17999,  IsActive = true, Image = "p54.jpeg", IsHome = false, CategoryId = 5, Description = electronicsDesc },
            new Product { Id = 55, ProductName = "Apple Watch Series 9 GPS 45mm",           Price = 15999,  IsActive = true, Image = "p55.jpeg", IsHome = false, CategoryId = 5, Description = electronicsDesc }
        );
    }
}
