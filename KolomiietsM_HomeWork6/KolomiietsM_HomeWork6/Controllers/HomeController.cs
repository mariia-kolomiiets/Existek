using KolomiietsM_HomeWork6.Exceptions;
using KolomiietsM_HomeWork6.OwnFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork6.Controllers
{
    public class HomeController : ControllerBase
    {
        [VolumeExceptionFilter]
        [HttpGet]
        [Route("[controller]/[action]/{volume:int}")]
        public async Task Main(int volume)
        {
            if(volume > 75)
            {
                throw new HighVolumeException("Music is too loud!!!");
            }
            else if(volume < 15)
            {
                throw new HighVolumeException("Music is too quiet...");
            }

            await Response.WriteAsync("Music turned on.");
        }
    }
}
