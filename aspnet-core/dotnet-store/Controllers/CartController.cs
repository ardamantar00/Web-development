using dotnet_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;


public class CartController : Controller
{
    private DataContext _context;

    public CartController(DataContext context)
    {
        _context = context;
    }

    public async Task<ActionResult> Index()
    {
        var cart = await GetCart();

        return View(cart);
    }
    [HttpPost]
    public async Task<ActionResult> AddToCart(int productId, int amount = 1)
    {
        var cart = await GetCart();
        var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == productId);

        if (product != null)
        {
            cart.AddItem(product, amount);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index", "Cart");
    }


    private async Task<Cart> GetCart()
    {
        var customerId = User.Identity?.Name ?? Request.Cookies["customerId"];

        var cart = await _context.Carts
                    .Include(i => i.CartItems)
                    .ThenInclude(i => i.Product)
                    .Where(i => i.CustomerId == customerId)
                    .FirstOrDefaultAsync();

        if (cart == null)
        {
            customerId = User.Identity?.Name;
            if (string.IsNullOrEmpty(customerId))
            {
                customerId = Guid.NewGuid().ToString();
                var cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddMonths(1),
                    IsEssential = true
                };
                Response.Cookies.Append("customerId", customerId, cookieOptions);
            }

            cart = new Cart { CustomerId = customerId };
            _context.Add(cart);
            await _context.SaveChangesAsync();
        }
        return cart;
    }
    [HttpPost]
    public async Task<ActionResult> IncreaseItem(int productId)
    {
        var cart = await GetCart();
        var item = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            item.Amount += 1;
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index", "Cart");
    }

    [HttpPost]
    public async Task<ActionResult> DecreaseItem(int productId)
    {
        var cart = await GetCart();
        var item = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
        {
            item.Amount -= 1;
            if (item.Amount <= 0)
                _context.Remove(item);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction("Index", "Cart");
    }

    [HttpPost]
    public async Task<ActionResult> RemoveItem(int productId)
    {
        var cart = await GetCart();
        var item = cart.CartItems.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
            _context.Remove(item); 
        await _context.SaveChangesAsync();
        return RedirectToAction("Index", "Cart");
    }
}