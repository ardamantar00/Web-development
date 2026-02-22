using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace dotnet_store.Models;

public class AccountCreateModel
{
    [Required]
    [Display(Name = "Ad Soyad")]
    // [RegularExpression("^[a-zA-Z0-9]*$",ErrorMessage = "Sadece sayı ve harf giriniz")]
    public string    FullName { get; set; } = null!;

    [Required]
    [Display(Name = "Eposta")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    [Display(Name = "Parola")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
    
    [Required]
    [Display(Name = "Parola Tekrar")]
    [DataType(DataType.Password)]
    [Compare("Password",ErrorMessage ="Paraolalar Eşleşmiyor")]
    public string ConfirmPassword { get; set; } = null!;
}