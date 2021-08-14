using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2
{
    public class SaveService : ISaveService
    {
        public async Task save(HttpContext context)
        {
            await context.Response.WriteAsync("Saving...");
            Console.WriteLine("Saving...");
        }
    }
}
