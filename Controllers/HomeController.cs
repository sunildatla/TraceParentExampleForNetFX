using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace TraceParentExampleForNetFX.Controllers
{
    public class HomeController : Controller
    {
        ActivitySource source = new ActivitySource("TraceParentExampleForNetFX");
        public ActionResult Index()
        {
            var activity= source.StartActivity("HomeController.Index");
           
            HttpClient client = new HttpClient();

            HttpResponseMessage responseMessage = client.GetAsync("https://api.publicapis.org/entries").GetAwaiter().GetResult();

            responseMessage.RequestMessage.Headers.TryGetValues("traceparent", out IEnumerable<string> traceparent);
            if(traceparent != null)
            {
                activity?.SetTag("TraceParent", traceparent.FirstOrDefault());

            }
            activity?.SetTag("customTag", "customValue");
            activity?.Stop();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}