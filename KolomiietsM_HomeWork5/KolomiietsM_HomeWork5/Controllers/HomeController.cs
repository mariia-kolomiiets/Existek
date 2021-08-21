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
        [HttpGet]
        public async Task Get(long id)
        {
            await Response.WriteAsync("Get success!");
        }

        [HttpGet]
        public async Task Get(string user, int count)
        {
            await Response.WriteAsync("Get with 2 params success!");
        }

        [HttpPost]
        public async Task Post(string email, int card)
        {
            await Response.WriteAsync("Post with 2 params success!");
        }

        [HttpPost]
        public async Task Post(string phone, int card, double sum)
        {
            await Response.WriteAsync("Post with 3 params success!");
        }

        [HttpPut]
        public async Task Put(long id, string user, string email, string phone, int card)
        {
            await Response.WriteAsync("Put success!");
        }

        [HttpDelete]
        public async Task Delete(long id)
        {
            await Response.WriteAsync("Delete success!");
        }
    }
}
