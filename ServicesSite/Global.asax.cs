using System;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Services;

namespace ServicesSite
{
    public class Global : HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {  // make sure we have the latest routes added
            // is it overkill to do this for every request?
            // performance impact?
            
            var entityRoutePopulator = new EntityRouteRegistration { Routes = RouteTable.Routes };
            entityRoutePopulator.RegisterRoutes();
        }
    }
}