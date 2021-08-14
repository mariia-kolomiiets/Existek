using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2
{
    public class CheckService
    {
        public async Task check(HttpContext context)
        {
            await context.Response.WriteAsync("Checking...");
            Console.WriteLine("Checking.");
        }
    }
}
