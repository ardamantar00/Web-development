using dotnet_basics.Models;
using Microsoft.AspNetCore.Mvc;
namespace dotnet_basics.Controllers;
    public class ProductsController : Controller
    {
         List<Product> products = new List<Product>
            {
              new Product{ Id = 1,ProductTitle = "Samsung Galaxy S24 Fe",ProductDescription = "Samsung Galaxy S24 Fe 256 GB 8 GB Ram (Samsung Türkiye Garantili) Grafit",ProductPrice = 32000,Image = "samsung.png",IsProductOnSale = true,StockCount = 200,IsHome = true},
              new Product {Id = 2, ProductTitle = "Apple iPhone 17 Pro Max",ProductDescription = "Apple iPhone 17 Pro Max 256 GB Kozmik Turuncu",ProductPrice = 118000,Image = "iphone.png",IsProductOnSale = false,StockCount = 0,IsHome = false},
              new Product {Id = 3, ProductTitle = "Apple iPhone 17 Pro Max",ProductDescription = "Apple iPhone 17 Pro Max 256 GB Kozmik Turuncu",ProductPrice = 118000,Image = "iphone.png",IsProductOnSale = true,StockCount = 0,IsHome = false},
              new Product {Id = 4, ProductTitle = "Apple iPhone 17 Pro Max",ProductDescription = "Apple iPhone 17 Pro Max 256 GB Kozmik Turuncu",ProductPrice = 118000,Image = "iphone.png",IsProductOnSale = true,StockCount = 200,IsHome = false},
              new Product {Id = 5, ProductTitle = "Apple iPhone 17 Pro Max",ProductDescription = "Apple iPhone 17 Pro Max 256 GB Kozmik Turuncu",ProductPrice = 118000,Image = "iphone.png",IsProductOnSale = true,StockCount = 200,IsHome = true},
              new Product {Id = 6, ProductTitle = "Apple iPhone 17 Pro Max",ProductDescription = "Apple iPhone 17 Pro Max 256 GB Kozmik Turuncu",ProductPrice = 118000,Image = "iphone.png",IsProductOnSale = true,StockCount = 200,IsHome = true},   
            };
        public ActionResult Index()
        {
            List<Product> filterProducts = products.Where(p=>p.IsHome).ToList();
            return View(filterProducts);
        }
        public ActionResult List()
        {
            return View(products);
        }
        public ActionResult Details(int id)
        {
            Product? product  = products.Where(x=>x.Id == id).FirstOrDefault();
            return View(product);
        }
    }
