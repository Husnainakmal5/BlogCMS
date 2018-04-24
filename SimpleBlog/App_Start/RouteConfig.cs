
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SimpleBlog.Controllers;

namespace SimpleBlog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Posts", action = "Index" }, namespaces: new[] { "SimpleBlog.Controllers" }
            );
            
            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "Auth", action = "Login", id = UrlParameter.Optional }, namespaces: new[] { "SimpleBlog.Controllers" }
                );
            routes.MapRoute(
                name: "Logout",
                url: "logout",
                defaults: new { controller = "Auth", action = "Logout", id = UrlParameter.Optional }, namespaces: new[] { "SimpleBlog.Controllers" }
                );

            /*         routes.MapRoute(
                         name: "Default",
                         url: "{controller}/{action}/{id}",
                         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                     ); */
        }
    }
}
