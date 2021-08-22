using KolomiietsM_HomeWork5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork5.Constraints
{
    public class OwnPutConstraint : IRouteConstraint
    {
        Model model;
        public OwnPutConstraint(Model model)
        {
            this.model = model;
        }
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            long id;
            if(long.TryParse((string)values[routeKey], out id) && !(model.ids.Contains(id)))
            {
                model.ids.Add(id);
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
