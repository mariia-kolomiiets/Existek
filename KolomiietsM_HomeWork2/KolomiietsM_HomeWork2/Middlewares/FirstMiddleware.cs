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
        private readonly MainLogicService mainLogicService;
        private readonly PublicService publicService;

        public FirstMiddleware(RequestDelegate nextMiddleware, MainLogicService mainLogicService, PublicService publicService)
        {
            this.nextMiddleware = nextMiddleware;
            this.mainLogicService = mainLogicService;
            this.publicService = publicService;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await mainLogicService.doMainLogic(httpContext);
            await publicService.publish(httpContext);
            await nextMiddleware.Invoke(httpContext);
        }
    }
}
