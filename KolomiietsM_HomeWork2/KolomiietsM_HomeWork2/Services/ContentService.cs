using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2
{
    public class ContentService : IContentService
    {
        public async Task makeContent(HttpContext context)
        {
            await context.Response.WriteAsync("//creating some content.//");
            Console.WriteLine("//creating some content.//");
        }
    }
}
