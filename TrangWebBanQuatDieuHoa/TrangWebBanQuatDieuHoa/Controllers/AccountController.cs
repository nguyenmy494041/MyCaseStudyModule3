using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TrangWebBanQuatDieuHoa.Models;
using TrangWebBanQuatDieuHoa.Models.Userss;
using TrangWebBanQuatDieuHoa.Models.ViewModel;
using TrangWebBanQuatDieuHoa.Repositories;

namespace TrangWebBanQuatDieuHoa.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (model.returnUrl != null)
                {
                    return Redirect(model.returnUrl);
                }
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Brand");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attemp");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> Register(AccountRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Email = model.Email,
                    UserName = model.Email,                  
                    Address = model.Address
                };
                var result = await userManager.CreateAsync(user: user, password: model.Passwork);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user: user, isPersistent: false);
                    return RedirectToAction("Show", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }
        
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Show", "Home");
        }
    }
}
