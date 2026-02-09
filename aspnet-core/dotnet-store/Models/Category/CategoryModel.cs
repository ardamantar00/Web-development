using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class CategoryModel
{
    [Required(ErrorMessage = "{0} Alanı zorunlu")]
    [StringLength(20)]
    [Display(Name = "Kategori Adı")]
    public string CategoryName { get; set; }  = null!;
    [Display(Name = "URL")]
    [Required(ErrorMessage = "{0} alanı zorunlu")]
    [StringLength(30)]
    public string Url { get; set; } = null!;
}