using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ChocoPlanet.Core;
using ChocoPlanet.Models;
using ChocoPlanet.Models.Services;
using Ninject;

namespace ChocoPlanet
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            //TODO--------------------------Default--------------------------------------------------------------

            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "Default", // Имя маршрута
            //    "{controller}/{action}/{id}", // URL-адрес с параметрами
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Параметры по умолчанию
            //);
            //TODO--------------------------Default--------------------------------------------------------------

            //TODO--------------------------Paging1--------------------------------------------------------------

            ////routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    null, // Имя маршрута
            //    "", // URL-адрес с параметрами
            //    new { controller = "Product", action = "ProductCatalog", page=2 } // Параметры по умолчанию
            //);
            //routes.MapRoute(
            //    null, // Имя маршрута
            //    "Page{page}", // URL-адрес с параметрами
            //    new { controller = "Product", action = "ProductCatalog" },
            //    new {page=@"\d+"}// Параметры по умолчанию
            //);
            //TODO--------------------------Paging1--------------------------------------------------------------

            //TODO--------------------------Paging2--------------------------------------------------------------
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(null,
                "", 
                new { controller = "Product", action = "ProductCatalog", category = (string)null, page = 1 } // Параметры по умолчанию
            );
            routes.MapRoute(
                null, // Имя маршрута
                "Page{page}", // URL-адрес с параметрами
                new { controller = "Product", action = "ProductCatalog", category = (string)null },
                new { page = @"\d+" } // Параметры по умолчанию
            );
            routes.MapRoute(
                null, // Имя маршрута
                "{category}", // URL-адрес с параметрами
                new { controller = "Product", action = "ProductCatalog", page = 1 } // Параметры по умолчанию
            );
            routes.MapRoute(
                null, // Имя маршрута
                "{category}/Page{page}", // URL-адрес с параметрами
                new { controller = "Product", action = "ProductCatalog"},
                new { page = @"\d+" } // Параметры по умолчанию
            );
            routes.MapRoute(null, "{controller}/{action}");
            //TODO--------------------------Paging2--------------------------------------------------------------

        }

        protected void Application_Start()
        {
            IKernel kernel = new StandardKernel();
            
            kernel.Bind<IOrderSubmitter>().To<OrderSubmitter>();
            kernel.Bind<IChocoPlanetDbEntities>().To<ChocoPlanetDbEntities>();
            DependencyResolver.SetResolver(new DataDependencyResolver(kernel));

           

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart),new CartModelBinder());
            //ControllerBuilder.Current.SetControllerFactory(new ChocoPlanetControllerFactory());
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            
        }
    }
}