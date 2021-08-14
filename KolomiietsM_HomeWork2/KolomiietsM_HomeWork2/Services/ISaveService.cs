using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork2
{
    public interface ISaveService
    {
        public Task save(HttpContext context);
    }
}
