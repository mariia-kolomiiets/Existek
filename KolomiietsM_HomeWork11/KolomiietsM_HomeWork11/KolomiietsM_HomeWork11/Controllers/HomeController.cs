using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork11.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "admin, user")]
        public IActionResult Index()
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            return Content($"Hello {User.Identity.Name}! Your access role is {role}.");
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            return Content($"Hello ADMIN!");
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = "ACCESS")]
        public IActionResult Read()
        {
            return Content($"Reading text...");
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = "ACCESS")]
        public IActionResult Write(string text)
        {
            return Content(text);
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize(Policy = "ACCESS")]
        public IActionResult Edit(string edit)
        {
            return Content($"Here is the text. And here is editing {edit}.");
        }
    }
}
