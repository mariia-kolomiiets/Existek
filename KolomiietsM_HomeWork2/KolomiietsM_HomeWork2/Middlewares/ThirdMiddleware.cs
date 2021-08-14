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

        public ThirdMiddleware(RequestDelegate nextMiddleware, CheckService checkService)
        {
            this.nextMiddleware = nextMiddleware;
            this.checkService = checkService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await checkService.check(httpContext);
            await nextMiddleware.Invoke(httpContext);
        }
    }
}
