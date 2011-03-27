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
            // is there some other way to support runtime / dynamic route addition via dll swapout?Application_BeginRequest
            var allRoutes =new EntityRouteCollection().Routes;
            foreach (var route in allRoutes.Where(route => !RouteTable.Routes.Contains(route)))
            {
                RouteTable.Routes.Add(route);
            }
        }
    }
}