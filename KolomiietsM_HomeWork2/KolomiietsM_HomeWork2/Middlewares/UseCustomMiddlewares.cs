using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2.Middlewares
{
    public static class UseCustomMiddlewares
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder, String path)
        {
            builder.UseMiddleware<FirstMiddleware>(path);
            builder.UseMiddleware<SecondMiddleware>(path);
            builder.UseMiddleware<ThirdMiddleware>(path);
            return builder;
        }
    }
}
