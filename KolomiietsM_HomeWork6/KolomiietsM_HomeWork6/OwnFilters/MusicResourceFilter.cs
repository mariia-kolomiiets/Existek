using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace KolomiietsM_HomeWork6.OwnFilters
{
    public class MusicResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string musicTitle = context.HttpContext.Request.RouteValues["MusicTitle"].ToString();
            string author = context.HttpContext.Request.RouteValues["Author"].ToString();
            int duration = Int32.Parse(context.HttpContext.Request.RouteValues["duration"].ToString());

            int cutCookie = Int32.Parse(context.HttpContext.Request.Cookies["cutCookie"]);
            int previewCookie = Int32.Parse(context.HttpContext.Request.Cookies["previewCookie"]);
            int endCookie = Int32.Parse(context.HttpContext.Request.Cookies["endCookie"]);
            int durationCookie = endCookie + previewCookie + cutCookie;

            if (duration != durationCookie)
            {
                context.Result = new ContentResult() {Content = $"Sound \'{author}: {musicTitle}\' is not suit to your duration in your storage." +
                    $"\nRequest rejected!" };
            }
        }
    }
}
