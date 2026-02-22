using dotnet_store.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

public class UserController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    public UserController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    
    public ActionResult Index()
    {
        return View(_userManager.Users);
    }
}