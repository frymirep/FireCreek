using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace Services
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("Advert", new WebServiceHostFactory(), typeof(AdvertisementService)));
        }
    }
}