using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//
using DotNetEnv;
using System.IO;

namespace ProyectoSistemaTurismo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            string solutionRoot = AppDomain.CurrentDomain.BaseDirectory;    // Raiz
            string envFilePath = Path.Combine(solutionRoot, ".env");        // Archivo .env
            Env.Load(envFilePath);                                          // Cargar el archivo .env

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
