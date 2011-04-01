using System;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web.Routing;
using Model;
using Model.Domain;
using Repositories;

namespace Services
{
    public class EntityRouteRegistrar
    {
        public RouteCollection Routes { get; set; }

        public IRepositoryTypeMap TypeMap { set; private get; }

        private static readonly WebServiceHostFactory Factory = new WebServiceHostFactory();

        public void RegisterRoutes()
        {
            var entities = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(t => t is IRESTable)
                .ToList();
            entities.ForEach(AddEntityToRoute);
        }

        private void AddEntityToRoute(Type entity)
        {
            var routeName = RouteName(entity);
            var route = ServiceRouteByRouteName(routeName); 
            // dont add if we can already find it in the list of routes
            if (route != null) return;
            route = RouteOfType(entity, routeName);
            Routes.Add(route);
        }

        private ServiceRoute ServiceRouteByRouteName(string routeName)
        {
            return Routes
               .Where(r => r is ServiceRoute)
               .Cast<ServiceRoute>()
               .Where(r => r.Url.Contains(routeName))
               .FirstOrDefault();
        }

        private ServiceRoute RouteOfType(Type typeToRoute, string routeName)
        {
            // reflection for generic type from here http://stackoverflow.com/questions/67370/dynamically-create-a-generic-type-for-template
            var serviceType = typeof(Service<>);
            var genericServiceType = serviceType.MakeGenericType(typeToRoute);
            // the following line of code should work.  Research
            var repositoryTypeMap = genericServiceType.GetProperty("RepositoryTypeMap");
            repositoryTypeMap = genericServiceType.GetProperties()[0]; // hack that only works because I know there is only one property!
            repositoryTypeMap.SetValue(null, TypeMap, null);
            var route = new ServiceRoute(routeName, Factory, genericServiceType);
            return route;
        }

        private static string RouteName(Type typeToRoute)
        {
            var attributes = typeToRoute.GetCustomAttributes(true);
            var routeNameAttribute = attributes
                .Where(a => a is RouteNameAttribute)
                .Cast<RouteNameAttribute>()
                .FirstOrDefault();
            return (routeNameAttribute != default(RouteNameAttribute)) ? routeNameAttribute.Name : typeToRoute.Name;
        }
    }
}
