using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Domain;

namespace Tests
{
    [TestClass]
    public class AttributeTest
    {
        [TestMethod]
        public void GetAttributeName()
        {
            var type = typeof(Advertisement);
            var attributes = type.GetCustomAttributes(true);
            var routeNameAttribute = attributes
                .Where(a => a is RouteNameAttribute)
                .Cast<RouteNameAttribute>()
                .FirstOrDefault();
            Console.WriteLine(routeNameAttribute.Name);
        }
    }
}
