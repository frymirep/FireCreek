using System;
using System.Web;
using System.Web.Routing;
using Services;

namespace ServicesSite
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {  
            var entityRoutePopulator = new EntityRouteRegistrar { Routes = RouteTable.Routes };
            entityRoutePopulator.RegisterRoutes();
        }
    }
}