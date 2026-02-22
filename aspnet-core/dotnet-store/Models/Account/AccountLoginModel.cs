using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace dotnet_store.Models;

public class AccountLoginModel
{
    [Required]
    [Display(Name = "Eposta")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [Display(Name = "Parola")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;    
    [Display(Name ="Beni Hatırla")]
    public bool RememberMe { get; set; } = true;
}