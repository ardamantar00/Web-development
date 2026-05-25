using dotnet_store.Models;
using dotnet_store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    [Authorize(Roles = "Admin")]
    public ActionResult Index()
    {
        var orders = _context.Orders
            .OrderByDescending(o => o.OrderTime)
            .ToList();
        return View(orders);
    }

    [Authorize(Roles = "Admin")]
    public ActionResult Details(int id)
    {
        var order = _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
            .FirstOrDefault(o => o.Id == id);

        if (order == null)
            return NotFound();

        return View(order);
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

    public ActionResult MyOrders()
    {
        var username = User.Identity?.Name!;
        var orders = _context.Orders
            .Where(o => o.Username == username)
            .Include(o => o.OrderItems)
            .OrderByDescending(o => o.OrderTime)
            .ToList();
        return View(orders);
    }

    public ActionResult MyOrderDetail(int id)
    {
        var username = User.Identity?.Name!;
        var order = _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product)
            .FirstOrDefault(o => o.Id == id && o.Username == username);

        if (order == null)
            return NotFound();

        return View(order);
    }
}