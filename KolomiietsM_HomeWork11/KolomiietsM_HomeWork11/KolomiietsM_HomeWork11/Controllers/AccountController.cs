using KolomiietsM_HomeWork11.Context;
using KolomiietsM_HomeWork11.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork11.Controllers
{
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private UsersContext db;
        public AccountController(UsersContext context)
        {
            db = context;
        }
        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task Login()
        {
            await HttpContext.Response.WriteAsync("Login().");
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect login or password!");
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("[action]")]
        public async Task Register()
        {
            await HttpContext.Response.WriteAsync("Register().");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = new User { Email = model.Email, Password = model.Password, Access = model.Access };
                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == model.Role);
                    if (userRole != null)
                        user.Role = userRole;
                    db.Users.Add(user);
                    await db.SaveChangesAsync();

                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Incorrect login or password!");
            }
            return BadRequest(ModelState);
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name),
                new Claim("reading", user.Access),
                new Claim("readEditText", "readEditText")
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
