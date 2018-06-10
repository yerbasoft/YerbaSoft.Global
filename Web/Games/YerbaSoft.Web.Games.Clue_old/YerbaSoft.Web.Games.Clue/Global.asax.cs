using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace YerbaSoft.Web.Games.Clue
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new Filters.ErrorLoggerAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapHttpRoute(name: "DefaultApi", routeTemplate: "api/{controller}/{id}", defaults: new { id = RouteParameter.Optional });

            /*
            routes.MapRoute(name: "assign", url: "assign/{element}/{id}", defaults: new { controller = "Home", action = "ABMAssign", id = UrlParameter.Optional });
            routes.MapRoute(name: "Reportes", url: "reporte/{element}/{defaults}/{filter}", defaults: new { controller = "Home", action = "Reporte", defaults = UrlParameter.Optional, filter = UrlParameter.Optional });
            routes.MapRoute(name: "ABMListados", url: "ver/{element}/{filter}", defaults: new { controller = "Home", action = "ABMListado", filter = UrlParameter.Optional });
            routes.MapRoute(name: "ABMCrear", url: "crear/{element}/{defaults}", defaults: new { controller = "Home", action = "ABMEditar", esNuevo = true, defaults = UrlParameter.Optional });
            routes.MapRoute(name: "ABMEditar", url: "editar/{element}/{id}/{defaults}", defaults: new { controller = "Home", action = "ABMEditar", esNuevo = false, defaults = UrlParameter.Optional });
            routes.MapRoute(name: "FullCustomPage", url: "base/{action}", defaults: new { controller = "Custom", id = UrlParameter.Optional });
             * */
            routes.MapRoute(name: "default", url: "{controller}/{action}", defaults: new { controller = "Home", action = "Index" });
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            /*
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
             * */
        }
    }
}
