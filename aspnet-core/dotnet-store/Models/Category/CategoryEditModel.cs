using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class CategoryEditModel
{
    
    public int Id { get; set; }
    [Required]
    [StringLength(20)]
    [Display(Name = "Kategori Adı")]
    public string CategoryName { get; set; }  = null!;
    [Required]
    [StringLength(20)]
    [Display(Name = "URL")]
    public string Url { get; set; } = null!;
}