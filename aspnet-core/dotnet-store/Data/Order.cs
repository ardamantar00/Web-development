namespace dotnet_store.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderTime { get; set; }
    public string FullName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string CustomerId { get; set; } = null!;
    public string City { get; set; } = null!;
    public string CityRow { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Telephone { get; set; } = null!;
    public double TotalPrice { get; set; }
    public string? OrderNote { get; set; }

    public string? CardName { get; set; }
    public string? CardLastFour { get; set; }
    public string? CardExpirationMonth { get; set; }
    public string? CardExpirationYear { get; set; }

    public List<OrderItem> OrderItems { get; set; } = new();
}

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public double Price { get; set; }
    public int Amount { get; set; }
}