using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2.Middlewares
{
    public class FirstMiddleware
    {
        //RequestDelegate next  middlevare in ctor
        //Invoke / InvokeAsync (HttpContext) return TASK
        private readonly RequestDelegate nextMiddleware;
        private readonly PublicService publicService;
        private readonly String path;

        public FirstMiddleware(RequestDelegate nextMiddleware, PublicService publicService, String path)
        {
            this.nextMiddleware = nextMiddleware;
            this.publicService = publicService;
            this.path = path;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path == path)
            {
                await httpContext.Response.WriteAsync("FIRST MIDDLEWARE\n");
                await publicService.publish(httpContext);
                await nextMiddleware.Invoke(httpContext);
            }
        }
    }
}
