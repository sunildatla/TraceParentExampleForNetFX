using OpenTelemetry;
using OpenTelemetry.Trace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TraceParentExampleForNetFX
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Sdk.CreateTracerProviderBuilder().AddAspNetInstrumentation().AddHttpClientInstrumentation().AddSource("*").AddConsoleExporter().Build();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
