using System;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web.Routing;
using Model;
using Model.Domain;

namespace Services
{
    // I don't like the current semantics of this class.  It is the collection of routes that
    public class EntityRouteCollection 
    {
        public RouteCollection Routes { get; private set; }
        public EntityRouteCollection()
        {
            Routes  = RoutesForEntities();
        }

        private static RouteCollection RoutesForEntities()
        {
            var result = new RouteCollection();
            var type = typeof(IdentifiableEntity);
            var entities = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(type.IsAssignableFrom)
                .ToList();
            entities.ForEach(e => result.Add(RouteOfType(e)));
            return result;
        }

        private static ServiceRoute RouteOfType(Type typeToRoute)
        {
            var routeName = RouteName(typeToRoute);
            // reflection for generic type from here http://stackoverflow.com/questions/67370/dynamically-create-a-generic-type-for-template
            var serviceType = typeof(Service<>);
            var genericServiceType = serviceType.MakeGenericType(typeToRoute);
            var route = new ServiceRoute(routeName, new WebServiceHostFactory(), genericServiceType);
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
