using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class ProductEditModel
{
    public int Id { get; set; }
    [Display(Name = "Ürün Adı")]
    public string ProductName { get; set; } = null!;
    [Display(Name = "Fiyat")]
    public double Price { get; set; }
    [Display(Name = "Ürün Açıklaması")]
    public string? Description { get; set; }
    public string? ImageName { get; set; }
    public IFormFile? ImageFile { get; set; }
    public bool IsActive { get; set; }
    public bool IsHome { get; set; }
    public int CategoryId { get; set; }

}