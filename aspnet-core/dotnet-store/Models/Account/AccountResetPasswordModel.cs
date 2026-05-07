using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace dotnet_store.Models;

public class AccountResetPasswordModel
{
    public string Token { get; set; } = null!;
    public string Email { get; set; } = null!;
    [Required]
    [Display(Name = "Yeni Parola")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;   
    
    [Required]
    [Display(Name = "Yeni Parola Tekrar")]
    [DataType(DataType.Password)]
    [Compare("Password",ErrorMessage ="Paraolalar Eşleşmiyor")]
    public string ConfirmPassword { get; set; } = null!;
}