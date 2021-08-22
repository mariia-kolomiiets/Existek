using KolomiietsM_HomeWork5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork5.Controllers
{
    public class HomeController : ControllerBase
    {
        Model model;
        public HomeController(Model model)
        {
            this.model = model;
        }
        public async Task Index()
        {
            await Response.WriteAsync("Main.");
        }

        [HttpGet]
        [Route("[controller]/[action]/{id:long}")]
        public async Task Get(long id) //https://localhost:44373/Home/Get/1111
        {
            await Response.WriteAsync($"Get success!\nParams:{id}");
        }

        [HttpGet]
        [Route("[controller]/[action]/{user:alpha}-{count:int}")]
        public async Task Get(string user, int count) //https://localhost:44373/Home/Get/Tomas-12
        {
            await Response.WriteAsync($"Get with 2 params success!\nParams:{user}-{count}");
        }

        public async Task Post(string email, int card) //https://localhost:44373/Home/Post/mypost@gmail.com=-=213
        {
            await Response.WriteAsync($"Post with 2 params success!\nParams:{email}-{card}");
        }

        public async Task PostPhone(string phone, int card, double sum) //https://localhost:44373/Home/PostPhone/555-888-4407=-=1=-=2
        {
            await Response.WriteAsync($"Post with 3 params success!\nParams:{phone}-{card}-{sum}");
        }

        public async Task Put(long id, string user, string email, string phone, int card) //https://localhost:44373/Home/Put/232/aaa/mypost@gmail.com/555-888-4407/111
        {
            await Response.WriteAsync($"Put success!\nParams:{id}-{user}-{email}-{phone}-{card}");
        }
        [HttpGet]
        [Route("[controller]/[action]/{id:ownDelete}")]
        public async Task Delete(long id) //https://localhost:44373/Home/Delete/232
        {
            await Response.WriteAsync($"Delete success!\nParams:{id}");
        }
    }
}
