namespace dotnet_store.Models;

public class SliderCreateModel 
{
     public int Id { get; set; }
    public string? Title { get; set; }
     public string? Description { get; set; }
    public  IFormFile Image { get; set; } = null!;
    public int Index { get; set; }
    public bool IsActive { get; set; }
}