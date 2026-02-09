using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class SliderModel
{
    public int Id { get; set; }
    [Display(Name = "Slider Adı")]
    [Required]
    [StringLength(40,ErrorMessage = "{0} {2} - {1} arasında değer almalıdır",MinimumLength = 3)]
    public string? Title { get; set; }
    public string? Description { get; set; }
    [Display(Name = "Slider Resmi")]
    [Required(ErrorMessage = "{0} alanı zorunlu")]
    public string Image { get; set; } = null!;
    public int Index { get; set; }
    public bool IsActive { get; set; }
}




