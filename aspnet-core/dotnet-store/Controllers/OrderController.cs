using System.Globalization;
using dotnet_store.Models;
using dotnet_store.Services;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace dotnet_store.Controllers;

[Authorize]
public class OrderController : Controller
{
    private ICartService _cartService;
    private readonly IConfiguration _configuration;
    private DataContext _context;
    public OrderController(ICartService cartService, DataContext context, IConfiguration configuration)
    {
        _cartService = cartService;
        _context = context;
        _configuration = configuration;
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

        if (cart.CartItems.Count == 0)
        {
            ModelState.AddModelError("", "Sepetinizde ürün yok");
        }

        var rawNumber = model.CartNumber?.Replace(" ", "") ?? "";

        if (rawNumber.Length != 16 || !rawNumber.All(char.IsDigit))
            ModelState.AddModelError("CartNumber", "Kart numarası 16 haneli olmalıdır.");

        if (int.TryParse(model.CartExpirationMonth, out int expMonth) &&
            int.TryParse(model.CartExpirationYear,  out int expYear))
        {
            var expiry = new DateTime(expYear, expMonth, 1).AddMonths(1).AddDays(-1);
            if (expiry < DateTime.Today)
                ModelState.AddModelError("CartExpirationYear", "Kartın son kullanma tarihi geçmiş.");
        }

        if (ModelState.IsValid)
        {
            var order = new Order
            {
                FullName = model.FullName,
                City = model.City,
                CityRow = model.CityRow,
                PostalCode = model.PostalCode,
                Telephone = model.Telephone,
                OrderNote = model.OrderNote,
                Username = username,
                CustomerId = username,
                OrderTime = DateTime.Now,
                TotalPrice = cart.Sum(),
                CardName = model.CartName,
                CardLastFour = rawNumber.Length >= 4 ? rawNumber[^4..] : rawNumber,
                CardExpirationMonth = model.CartExpirationMonth,
                CardExpirationYear = model.CartExpirationYear,
                OrderItems = cart.CartItems.Select(i => new Models.OrderItem
                {
                    ProductId = i.ProductId,
                    Price = i.Product.Price,
                    Amount = i.Amount
                }).ToList()
            };
            var payment = await ProcessPayment(model, cart);
            if (payment.Status == "success")
            {
                _context.Orders.Add(order);
                _context.Carts.Remove(cart);

                await _context.SaveChangesAsync();
                return RedirectToAction("Completed", new { orderId = order.Id });
            }
            else
            {
                ModelState.AddModelError("",payment.ErrorMessage);
            }
        }
        ViewBag.Cart = cart;
        return View(model);
    }
    public ActionResult Completed(string orderId)
    {
        return View("Completed", orderId);
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

    private async Task<Payment> ProcessPayment(OrderCreateModel model, Cart cart)
    {
        Options options = new Options();
        options.ApiKey = _configuration["PaymentAPI:APIKey"];
        options.SecretKey = _configuration["PaymentAPI:SecretKey"];
        options.BaseUrl = "https://sandbox-api.iyzipay.com";

        CreatePaymentRequest request = new CreatePaymentRequest();
        request.Locale = Locale.TR.ToString();
        request.ConversationId = Guid.NewGuid().ToString();
        request.Price     = cart.GetSubtotal().ToString("F2", CultureInfo.InvariantCulture);
        request.PaidPrice = cart.GetSubtotal().ToString("F2", CultureInfo.InvariantCulture);
        request.Currency = Currency.TRY.ToString();
        request.Installment = 1;
        request.BasketId = "B67832";
        request.PaymentChannel = PaymentChannel.WEB.ToString();
        request.PaymentGroup = PaymentGroup.PRODUCT.ToString();

        PaymentCard paymentCard = new PaymentCard();
        paymentCard.CardHolderName = model.CartName;
        paymentCard.CardNumber = model.CartNumber?.Replace(" ", "");
        paymentCard.ExpireMonth = model.CartExpirationMonth;
        paymentCard.ExpireYear = model.CartExpirationYear;
        paymentCard.Cvc = model.CartCVV;
        paymentCard.RegisterCard = 0;
        request.PaymentCard = paymentCard;

        Buyer buyer = new Buyer();
        buyer.Id = "BY789";
        buyer.Name = model.FullName;
        buyer.Surname = "Doe";
        buyer.GsmNumber = model.Telephone;
        buyer.Email = "email@email.com";
        buyer.IdentityNumber = "74300864791";
        buyer.LastLoginDate = "2015-10-05 12:43:35";
        buyer.RegistrationDate = "2013-04-21 15:12:09";
        buyer.RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
        buyer.Ip = "85.34.78.112";
        buyer.City = model.City;
        buyer.Country = "Turkey";
        buyer.ZipCode = model.PostalCode;
        request.Buyer = buyer;

        Address address = new Address();
        address.ContactName = model.FullName;
        address.City = model.City;
        address.Country = "Turkey";
        address.Description = model.CityRow;
        address.ZipCode = model.PostalCode;
        request.ShippingAddress = address;
        request.BillingAddress = address;

        List<BasketItem> basketItems = new List<BasketItem>();
        foreach (var item in cart.CartItems)
        {
            BasketItem basketItem = new BasketItem();
            basketItem.Id = item.CartId.ToString();
            basketItem.Name = item.Product.ProductName;
            basketItem.Category1 = "Telephone";
            basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            basketItem.Price = (item.Product.Price * item.Amount).ToString("F2", CultureInfo.InvariantCulture);
            basketItems.Add(basketItem);
        }



        request.BasketItems = basketItems;

        return await Payment.Create(request, options);
    }
}