using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using Model;
using Model.Domain;
using Services;

namespace ServicesSite
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            var routeCollection = new EntityRouteCollection();
            foreach (var route in routeCollection)
            {
                RouteTable.Routes.Add(route);
            }
        }
    }
}