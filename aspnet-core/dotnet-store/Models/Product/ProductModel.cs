using System.ComponentModel.DataAnnotations;
namespace dotnet_store.Models;

public class ProductModel
{
    [Display(Name = "Ürün Adı")]
    [Required(ErrorMessage = "{0} alanı zorunlu")]
    [StringLength(40,ErrorMessage = "{2} - {1} aralığında değer girmelisiniz",MinimumLength = 10)]
    public string ProductName { get; set; } = null!;
    [Display(Name = "Fiyat")]
    [Required(ErrorMessage = "{0} alanı zorunlu")]
    [Range(0.01,100000000,ErrorMessage = "{1} - {2} aralığında bir değer girmelisiniz")]
    public double? Price { get; set; }
    [Display(Name = "Ürün Açıklaması")]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Resim alanı zorunlu")]
    public IFormFile? Image { get; set; }
    public bool IsActive { get; set; }
    public bool IsHome { get; set; }
    [Display(Name = "Kategori Adı")]
    [Required(ErrorMessage = "{0} alanı zorunlu")]
    public int? CategoryId { get; set; }

}