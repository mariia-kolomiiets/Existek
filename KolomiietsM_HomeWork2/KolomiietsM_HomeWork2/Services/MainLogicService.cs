using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2
{
    public class MainLogicService
    {
        public async Task doMainLogic(HttpContext context)
        {
            Console.WriteLine("Does main logic...");
            await context.Response.WriteAsync("Does main logic...");
        }
    }
}
