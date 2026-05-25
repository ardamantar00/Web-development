using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class OrderCreateModel
{
    public int Id { get; set; }
    [Display(Name = "Ad Soyad")]
    public string FullName { get; set; } = null!;
    [Display(Name = "Şehir")]
    public string City { get; set; } = null!;
    [Display(Name = "İlçe")]
    public string CityRow { get; set; } = null!;
    [Display(Name = "Posta Kodu")]
    public string PostalCode { get; set; } = null!;
    [Display(Name = "Telefon")]
    public string Telephone { get; set; } = null!;
    [Display(Name = "Sipariş Notu")]
    public string? OrderNote { get; set; }
}