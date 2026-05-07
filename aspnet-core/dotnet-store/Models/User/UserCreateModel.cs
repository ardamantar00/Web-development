using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace dotnet_store.Models;

public class UserCreateModel
{
    [Required]
    [Display(Name = "Ad Soyad")]
    
    public string    FullName { get; set; } = null!;

    [Required]
    [Display(Name = "Eposta")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    
}