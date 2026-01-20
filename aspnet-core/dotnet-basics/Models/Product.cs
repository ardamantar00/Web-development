namespace dotnet_basics.Models;
 public class Product
{      
         public int? Id { get; set; }
        public string? ProductTitle { get; set; }
        public string? ProductDescription { get; set; }
        public double ProductPrice { get; set; }
        public string? Image { get; set; }
        public bool IsProductOnSale { get; set; }
        public int StockCount { get; set; }
        public bool IsHome { get; set; }
}
