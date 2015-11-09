using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AdminControl
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "News",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "News", action = "NewsList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "User",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "User", action = "UserList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Customer",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Customer", action = "CustomerList", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Product",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Product", action = "ProductList", id = UrlParameter.Optional }
            );

        }
    }
}
