using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class OrderCreateModel
{
    public int Id { get; set; }

    [Display(Name = "Ad Soyad")]
    [Required(ErrorMessage = "Ad Soyad zorunludur.")]
    public string FullName { get; set; } = null!;

    [Display(Name = "Şehir")]
    [Required(ErrorMessage = "Şehir zorunludur.")]
    public string City { get; set; } = null!;

    [Display(Name = "İlçe")]
    [Required(ErrorMessage = "İlçe zorunludur.")]
    public string CityRow { get; set; } = null!;

    [Display(Name = "Posta Kodu")]
    [Required(ErrorMessage = "Posta Kodu zorunludur.")]
    public string PostalCode { get; set; } = null!;

    [Display(Name = "Telefon")]
    [Required(ErrorMessage = "Telefon zorunludur.")]
    public string Telephone { get; set; } = null!;

    [Display(Name = "Sipariş Notu")]
    public string? OrderNote { get; set; }

    // Kart bilgileri
    [Display(Name = "Kart Üzerindeki Ad")]
    [Required(ErrorMessage = "Kart sahibi adı zorunludur.")]
    [MinLength(3, ErrorMessage = "Kart sahibi adı en az 3 karakter olmalıdır.")]
    public string CartName { get; set; } = null!;

    [Display(Name = "Kart Numarası")]
    [Required(ErrorMessage = "Kart numarası zorunludur.")]
    public string CartNumber { get; set; } = null!;

    [Display(Name = "Son Kullanma Ayı")]
    [Required(ErrorMessage = "Son kullanma ayı zorunludur.")]
    public string CartExpirationMonth { get; set; } = null!;

    [Display(Name = "Son Kullanma Yılı")]
    [Required(ErrorMessage = "Son kullanma yılı zorunludur.")]
    public string CartExpirationYear { get; set; } = null!;

    [Display(Name = "CVV")]
    [Required(ErrorMessage = "CVV zorunludur.")]
    [RegularExpression(@"^\d{3,4}$", ErrorMessage = "CVV 3 veya 4 haneli rakam olmalıdır.")]
    public string CartCVV { get; set; } = null!;
}
