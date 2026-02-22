using dotnet_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;


public class RoleController : Controller
{
    private readonly RoleManager<AppRole> _rolemanager;
    private readonly UserManager<AppUser> _usermanager;
    public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> usermanager)
    {
        _rolemanager = roleManager;
        _usermanager = usermanager;
    }
    public ActionResult Index()
    {
        
        return View(_rolemanager.Roles);
    }
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(RoleCreateModel model)
    {
        if(ModelState.IsValid)
        {
            var role = new AppRole {Name = model.RoleName};
            var result = await _rolemanager.CreateAsync(role);

            if(result.Succeeded)
            {
                return RedirectToAction("Index");

            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }
        }
        return View(model);
    }
    public async Task<ActionResult> Edit(string id)
    {
        var entity = await  _rolemanager.FindByIdAsync(id);

        if(entity != null)
        {
            return View(new RoleEditModel{Id = entity.Id, RoleName = entity.Name!});
        }
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<ActionResult> Edit(string id,RoleEditModel model)
    {
        if (ModelState.IsValid)
        {
            var entity = await _rolemanager.FindByIdAsync(id);
            if(entity != null)
            {
                entity.Name = model.RoleName;
                var result = await _rolemanager.UpdateAsync(entity);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
        }
        return View(model);
    }
    public async Task<ActionResult> Delete(string? id )
    {
        if(id == null)
        {
            return RedirectToAction("Index","Role");
        }
        var entity = await _rolemanager.FindByIdAsync(id);

        if(entity != null)
        {
            ViewBag.Users = await _usermanager.GetUsersInRoleAsync(entity.Name!);
            return View(entity);

        }
        return RedirectToAction("Index");
    }
    public async Task<ActionResult> DeleteConfirm(string? id)
    {
        if(id == null)
        {
            return RedirectToAction("Index");
        }
         var entity = await _rolemanager.FindByIdAsync(id);

        if(entity != null)
        {
            await _rolemanager.DeleteAsync(entity);
            TempData["Message"] = $"{entity.Name} rolü silindi";

        }
        return RedirectToAction("Index");
    }
}