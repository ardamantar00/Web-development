using dotnet_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<AppRole> _roleManager;
    public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<ActionResult> Index(string role)
    {
        // Roller listesini doldur (Seçili olanı işaretlemek için 'role' parametresini gönderiyoruz)
        var allRoles = await _roleManager.Roles.ToListAsync();
        ViewBag.Roles = new SelectList(allRoles, "Name", "Name", role);

        if (!string.IsNullOrEmpty(role))
        {
            // Seçilen role sahip kullanıcıları al
            var usersInRole = await _userManager.GetUsersInRoleAsync(role);

            // Eğer liste boş geliyorsa, rol ismi veritabanıyla birebir eşleşmiyor olabilir
            return View(usersInRole.ToList());
        }

        // Rol seçilmediyse tüm kullanıcıları getir
        var allUsers = await _userManager.Users.ToListAsync();
        return View(allUsers);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserCreateModel model)
    {
        var user = new AppUser { UserName = model.FullName, Email = model.Email, FullName = model.FullName };
        var result = await _userManager.CreateAsync(user);

        if (result.Succeeded)
        {

            return RedirectToAction("Index");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return View(model);
    }
    public async Task<ActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return RedirectToAction("Index");
        }
        ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
        return View(
            new UserEditModel
            {
                FullName = user.FullName,
                Email = user.Email!,
                SelectedRoles = await _userManager.GetRolesAsync(user)
            }
        );
    }

    [HttpPost]
    public async Task<ActionResult> Edit(string id, UserEditModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = model.Email;
                user.FullName = model.FullName;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded && !string.IsNullOrEmpty(model.Password))
                {
                    //parola güncellle
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.Password);
                }
                if (result.Succeeded)
                {
                    await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                    if (model.SelectedRoles != null)
                    {
                        await _userManager.AddToRolesAsync(user, model.SelectedRoles);
                    }
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View(model);

    }
        public async Task<ActionResult> Delete(string id)
    {
        if(id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = await _userManager.FindByIdAsync(id);

        if(entity != null)
        {
           return View(entity);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> DeleteConfirm(string id)
    {
         if(id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = await _userManager.FindByIdAsync(id);

        if(entity != null)
        {
           var result = await _userManager.DeleteAsync(entity);

           if(result.Succeeded)
            {
                TempData["Mesaj"] = $"{entity.UserName} kullanıcısı silindi";
            }
            
        }
        return RedirectToAction("Index");
    }
}