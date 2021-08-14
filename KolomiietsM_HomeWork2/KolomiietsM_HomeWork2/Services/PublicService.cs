using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2
{
    public class PublicService
    {
        private readonly ISaveService saveService;
        public PublicService(ISaveService saveService)
        {
            this.saveService = saveService;
        }
        public async Task publish(HttpContext context)
        {
            await saveService.save(context);
            await context.Response.WriteAsync("Publishing...");
            Console.WriteLine("Publishing.");
        }
    }
}
