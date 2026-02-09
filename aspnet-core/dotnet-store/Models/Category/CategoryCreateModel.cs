using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class CategoryCreateModel
{
    [Required]
    [StringLength(20)]
    [Display(Name = "Kategori Adı")]
    public string CategoryName { get; set; }  = null!;
    [Display(Name = "URL")]
    [Required]
    [StringLength(30)]
    public string Url { get; set; } = null!;
}