using KolomiietsM_HomeWork6.Exceptions;
using KolomiietsM_HomeWork6.OwnFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork6.Controllers
{
    public class HomeController : ControllerBase
    {
        [VolumeExceptionFilter]
        [MusicResourceFilter]
        [HttpGet]
        [Route("[controller]/[action]/{author:alpha}/{musicTitle:alpha}/{duration:int}/{volume:int}")]
        public async Task Main(string author, string musicTitle, int duration, int volume)
        {
            if(volume > 75)
            {
                throw new HighVolumeException("Music is too loud!!!");
            }
            else if(volume < 15)
            {
                throw new HighVolumeException("Music is too quiet...");
            }

            await Response.WriteAsync($"Music turned on. Playing {author}: {musicTitle} - {duration}.");
        }

        public async Task SetCookies()
        {
            var jsonConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfiguration configs = jsonConfig.Build();

            HttpContext.Response.Cookies.Append("cutCookie", configs["cutCookie"]);
            HttpContext.Response.Cookies.Append("previewCookie", configs["previewCookie"]);
            HttpContext.Response.Cookies.Append("endCookie", configs["endCookie"]);
            await Response.WriteAsync("Cookies installed.");
        }
    }
}
