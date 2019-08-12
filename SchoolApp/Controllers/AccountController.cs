using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.BLL.DTO;
using SchoolApp.BLL.Interfaces;
using SchoolApp.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace SchoolApp.Web.Controllers
{
    [Route("")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        IUserService userService;
        public AccountController(IUserService service)
        {
            userService = service;
        }

        // GET: api/Account
        [HttpGet]
        [HttpGet("{Id}")]
        public IActionResult Login()
        {
            
            ViewBag.URL = Request.Query["ReturnUrl"];
            return View("Login");
        }
        [HttpGet("[Action]")]
        public IActionResult Success()
        {
            return View("Success");
        }
        // POST: api/Account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginModel loginModel, [FromForm]string ReturnUrl)
        {
            
            //string ReturnUrl = Request.Form["ReturnUrl"];
            if (ModelState.IsValid)
            {
                UserViewModel user = Map(userService.Login(new UserDTO { Name = loginModel.Name, Password = loginModel.Password }));
                if (user != null)
                {
                    await Authenticate(loginModel.Name);
                    if (!String.IsNullOrEmpty(ReturnUrl)) return Redirect(ReturnUrl);
                    return RedirectToAction("Success");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(loginModel);
        }

        private UserViewModel Map(UserDTO user)
        {
            if (user == null) return null;
            return new UserViewModel { Id = user.Id, Name = user.Name, Password = user.Password };
        }

        private async Task Authenticate(string name)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, name)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        [HttpGet("[Action]")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
