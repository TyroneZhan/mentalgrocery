using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace mentalgrocery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{pageindex}/{pagesize}",
                defaults: new { controller = "Home", action = "Index",  pageindex = 1, pagesize = 10
                }
            );
        }
    }
}
