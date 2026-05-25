using dotnet_store.Models;
using dotnet_store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace dotnet_store.Controllers;

[Authorize]
public class OrderController : Controller
{
    private ICartService _cartService;
    private DataContext _context;
   public OrderController(ICartService cartService,DataContext context)
    {
        _cartService = cartService;
        _context = context;
    }
    public async Task<ActionResult> CheckOut()
    {
        ViewBag.Cart = await _cartService.GetCart(User.Identity?.Name!);
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> CheckOut(OrderCreateModel model)
    {
        var username = User.Identity?.Name!;
        var cart = await _cartService.GetCart(username);

        if(cart.CartItems.Count == 0 )
        {
            ModelState.AddModelError("","Sepetinizde ürün yok");
        }

        if(ModelState.IsValid)
        {
            var order = new Order
            {
                FullName   = model.FullName,
                City       = model.City,
                CityRow    = model.CityRow,
                PostalCode = model.PostalCode,
                Telephone  = model.Telephone,
                OrderNote  = model.OrderNote,
                Username   = username,
                CustomerId = username,
                OrderTime  = DateTime.Now,
                TotalPrice = cart.Sum(),
                OrderItems = cart.CartItems.Select(i=> new OrderItem
                {
                    ProductId = i.ProductId,
                    Price = i.Product.Price,
                    Amount = i.Amount
                }).ToList()
            };
            _context.Orders.Add(order);
            _context.Carts.Remove(cart);

            await _context.SaveChangesAsync();
            return RedirectToAction("Completed", new { orderId = order.Id });
        }
        ViewBag.Cart = cart;
        return View(model);
    }
    public ActionResult Completed(string orderId)
    {
        return View("Completed",orderId);
    }
}