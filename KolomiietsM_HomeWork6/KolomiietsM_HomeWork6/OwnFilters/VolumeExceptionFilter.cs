using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace KolomiietsM_HomeWork6.OwnFilters
{
    public class VolumeExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string actionName = context.ActionDescriptor.DisplayName;
            string exceptionStack = context.Exception.StackTrace;
            string exceptionMessage = context.Exception.Message;
            context.Result = new ContentResult
            {
                Content = "Music turned off! The volume is not normal.\n" +
                $"DETAILS:[{exceptionMessage}]"
            };
            context.ExceptionHandled = true;
        }
    }
}
