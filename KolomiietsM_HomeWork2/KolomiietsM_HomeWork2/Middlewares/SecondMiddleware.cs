using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2.Middlewares
{
    public class SecondMiddleware
    {
        private readonly RequestDelegate nextMiddleware;
        private readonly IContentService contentService;
        private readonly PublicService publicService;
        private readonly String path;

        public SecondMiddleware(RequestDelegate nextMiddleware, IContentService contentService, PublicService publicService, String path)
        {
            this.nextMiddleware = nextMiddleware;
            this.contentService = contentService;
            this.publicService = publicService;
            this.path = path;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path == path)
            {
                await contentService.makeContent(httpContext);
                await publicService.publish(httpContext);
                await nextMiddleware.Invoke(httpContext);
            }
        }
    }
}
