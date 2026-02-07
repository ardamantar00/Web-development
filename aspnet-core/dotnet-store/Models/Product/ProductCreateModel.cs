using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class ProductCreateModel
{
    [Display(Name = "Ürün Adı")]
     public string ProductName { get; set; } = null!;
     [Display(Name = "Fiyat")]
     public double Price { get; set; }
     [Display(Name = "Ürün Açıklaması")]
     public string? Description { get; set; }
     public IFormFile? Image { get; set; }

     public bool IsActive { get; set; }
     public bool IsHome { get; set; }
     public int CategoryId{ get; set; }

}