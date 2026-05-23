using System.Security.Claims;
using dotnet_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private IEmailService _emailService;
    private DataContext _context;
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService, DataContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
        _context = context;
    }
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(AccountCreateModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser { UserName = model.Email, Email = model.Email, FullName = @model.FullName };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Login(AccountLoginModel model, string? returnUrl)
    {

        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);

                if (result.Succeeded)
                {
                    await _userManager.ResetAccessFailedCountAsync(user);
                    await _userManager.SetLockoutEndDateAsync(user, null);

                    await TransferCartToUser(user);


                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    // return RedirectToAction("Index", "Home");
                }
                else if (result.IsLockedOut)
                {
                    var lockoutDate = await _userManager.GetLockoutEndDateAsync(user);
                    var timeLeft = lockoutDate - DateTime.UtcNow;
                    var minutes = Math.Ceiling(timeLeft.Value.TotalMinutes);
                    ModelState.AddModelError("", $"Hesabınız kilitlendi, lütfen {minutes} dk sonra tekrar deneyin");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Parola");
                }
            }
            else
            {
                ModelState.AddModelError("", "Hatalı email");
            }
        }
        return View(model);
    }

    private async Task TransferCartToUser(AppUser user)
    {
        var userCart = await _context.Carts
                                 .Include(i => i.CartItems)
                                 .ThenInclude(i => i.Product)
                                 .Where(i => i.CustomerId == user.UserName)
                                 .FirstOrDefaultAsync();


        var cookieCart = await _context.Carts
                   .Include(i => i.CartItems)
                   .ThenInclude(i => i.Product)
                   .Where(i => i.CustomerId == Request.Cookies["customerId"])
                   .FirstOrDefaultAsync();

        foreach (var item in cookieCart?.CartItems!)
        {
            var cartItem = userCart?.CartItems.Where(i => i.ProductId == item.ProductId).FirstOrDefault();
            if (cartItem != null)
            {
                cartItem.Amount += 1;
            }
            else
            {
                userCart?.CartItems.Add(new CartItem { ProductId = item.ProductId, Amount = item.Amount });
            }

        }
        _context.Carts.Remove(cookieCart);
        await _context.SaveChangesAsync();
    }

    [Authorize]
    public async Task<ActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
    [Authorize]
    public ActionResult Settings()
    {
        return View();
    }

    public ActionResult AccessDenied()
    {
        return View();
    }
    public ActionResult ChangePassword()
    {
        return View();
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> ChangePassword(AccountChangePasswordModel model)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId!);

            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);

                if (result.Succeeded)
                {
                    TempData["Message"] = "Parolanız güncellendi";
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }
        }
        return View(model);
    }
    [Authorize]
    public async Task<ActionResult> EditUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId!);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        return View(new AccountEditUserModel
        {
            FullName = user.FullName,
            Email = user.Email!
        });
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> EditUser(AccountEditUserModel model)

    {

        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId!);

            if (user != null)
            {
                user.Email = model.Email;
                user.FullName = model.FullName;
                user.UserName = model.Email;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    TempData["Message"] = "Bilgileriniz Güncellendi";
                    return RedirectToAction("EditUser");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View(model);

    }

    public ActionResult ForgotPassword()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> ForgotPassword(string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            TempData["Message"] = "E posta adresinzi giriniz";
            return View();
        }
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            TempData["Message"] = "Bu e posta adresi kayıtlı değil";
            return View();
        }
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var url = Url.Action("ResetPassword", "Account", new { userId = user.Id, token });

        var link = $"<a href = 'http://localhost:5225{url}'>Şifre yenile</a>";

        await _emailService.SendEmailAsync(user.Email!, "Parola Sıfırlama", link);
        TempData["Message"] = "E posta adresine şifre sıfırlama bağlantısı gönderildi";
        return RedirectToAction("Login");
    }
    public async Task<ActionResult> ResetPassword(string userId, string token)
    {
        if (userId == null || token == null)
        {
            return RedirectToAction("Login");
        }
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return RedirectToAction("Login");
        }
        var model = new AccountResetPasswordModel
        {
            Token = token,
            Email = user.Email!
        };
        return View(model);


    }
    [HttpPost]
    public async Task<ActionResult> ResetPassword(AccountResetPasswordModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);

            if (result.Succeeded)
            {
                TempData["Message"] = "Şifreniz Güncellendi";
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }
}