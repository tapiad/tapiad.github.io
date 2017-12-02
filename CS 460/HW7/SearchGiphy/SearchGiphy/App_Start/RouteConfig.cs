using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SearchGiphy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "HomeRoutes",
            //    //url: "admin/{controller}/{action}",
            //    url: "home/{action}",
            //    defaults: new { controller = "Home", action = "Search" });

            routes.MapRoute(
                name: "Search",
                url: "Giphy/{action}",
                defaults: new { controller = "Giphy", action = "Search", page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
