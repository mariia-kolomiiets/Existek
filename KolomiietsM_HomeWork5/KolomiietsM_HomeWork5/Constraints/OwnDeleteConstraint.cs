using KolomiietsM_HomeWork5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork5.Constraints
{
    public class OwnDeleteConstraint : IRouteConstraint
    {
        Model model;
        public OwnDeleteConstraint(Model model)
        {
            this.model = model;
        }
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            long id;
            long.TryParse((string)values[routeKey], out id);          
            return model.ids.Remove(id); ;
        }
    }
}
