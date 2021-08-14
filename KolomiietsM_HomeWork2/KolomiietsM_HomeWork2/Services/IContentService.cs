using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2
{
    public interface IContentService
    {
        public Task makeContent(HttpContext httpContext);
    }
}