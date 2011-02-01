using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using Services.Advert;

namespace Services
{
    public class Global : HttpApplication
    {
        public static RouteCollection Routes
        {
            get { return RouteTable.Routes; }
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("Advert", new WebServiceHostFactory(), typeof(AdvertisementService)));
        }
    }
}