using System.ComponentModel.DataAnnotations;
using System.Runtime.Versioning;

namespace dotnet_store.Models;

public class UserEditModel
{
    [Required]
    [Display(Name = "Ad Soyad")]
    
    public string    FullName { get; set; } = null!;

    [Required]
    [Display(Name = "Eposta")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    
   
    [Display(Name = "Parola")]
    [DataType(DataType.Password)]
    public string? Password { get; set; } = null!;
    
   
    [Display(Name = "Parola Tekrar")]
    [DataType(DataType.Password)]
    [Compare("Password",ErrorMessage ="Paraolalar Eşleşmiyor")]
    public string? ConfirmPassword { get; set; } = null!;
    public IList<string>? SelectedRoles { get; set; }

}