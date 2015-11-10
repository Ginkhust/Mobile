using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Parse;
using System.Web.Optimization;
using AdminControl.App_Start;

namespace AdminControl
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ParseClient.Initialize("G6gvYz4BlEp62zH8VJwHKhzzTZT4gTIUvrYvp4mp", "cfd77e3LMF9bQcZ8OMbXfC0ZjkvqO7IjnXT8gLA6");
        }
    }
}
