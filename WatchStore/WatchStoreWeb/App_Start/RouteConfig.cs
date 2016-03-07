using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WatchStoreWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //   routes.MapRoute(
            //    name: "CategoryNew",
            //    url: "{controller}/{action}/{category}/{isNew}",
            //    defaults: new { controller = "Watch", action = "Index",category =  UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //      name: "Category",
            //      url: "{controller}/{category}",
            //      defaults: new { controller = "Watch", action = "Index" }
            //);

            routes.MapRoute(
                  name: "Default",
                  url: "{controller}/{action}/{id}",
                  defaults: new { controller = "Watch", action = "Index", id = UrlParameter.Optional }
            );



            //  routes.MapRoute(null,"",
            //     new { controller = "Watch", action = "Index", category = (string)null, id = UrlParameter.Optional }
            // );

            //  routes.MapRoute(null, "",
            //    new { controller = "Nav", action = "Menu"}
            //);

            //routes.MapRoute(null,
            //    "{category}",
            //    new { controller = "Watch", action = "Index"}
            //);

            //routes.MapRoute(
            //    name: "Cart",
            //    url: "{controller}/{action}/{returnUrl}",
            //    defaults: new { controller = "Cart", action = "Index", returnUrl = UrlParameter.Optional}
            //);

        }
    }
}
