using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2.Middlewares
{
    public class ThirdMiddleware
    {
        private readonly RequestDelegate nextMiddleware;
        private readonly CheckService checkService;
        private readonly String path;

        public ThirdMiddleware(RequestDelegate nextMiddleware, CheckService checkService, String path)
        {
            this.nextMiddleware = nextMiddleware;
            this.checkService = checkService;
            this.path = path;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path == path)
            {
                await httpContext.Response.WriteAsync("\nTHIRS MIDDLEWARE\n");
                await checkService.check(httpContext);
                await nextMiddleware.Invoke(httpContext);
            }
        }
    }
}
