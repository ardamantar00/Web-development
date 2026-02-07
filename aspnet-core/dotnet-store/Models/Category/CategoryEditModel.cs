using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class CategoryEditModel
{
    public int Id { get; set; }
    [Display(Name = "Kategori Adı")]
    public string CategoryName { get; set; }  = null!;
    [Display(Name = "URL")]
    public string Url { get; set; } = null!;
}