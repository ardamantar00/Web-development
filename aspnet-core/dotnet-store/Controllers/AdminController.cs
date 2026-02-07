using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

public class AdminController : Controller
{
    public ActionResult Index()
    {
        
        return View();
    }
}