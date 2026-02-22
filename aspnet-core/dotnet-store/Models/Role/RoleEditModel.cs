using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class RoleEditModel
{

    public int Id { get; set; }
    [Required(ErrorMessage = "{0} Alanı zorunlu")]
    [StringLength(30)]
    [Display(Name = "Role Adı")]
    public string RoleName { get; set; }  = null!;
}