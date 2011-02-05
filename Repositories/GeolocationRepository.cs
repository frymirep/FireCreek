using Model.Domain;
using Model.Persistence;

namespace Repositories
{
    public class GeolocationRepository
    {
        public static IdentifiableEntity Create(string phoneIdentifier, GeoLocation geoLocation)
        {
            using (var repo = new PersistenceEntities())
            {
                geoLocation.Identifier = repo.InsertLocation(phoneIdentifier, geoLocation.Longitude, geoLocation.Latitude);
                repo.SaveChanges();
            }
            return geoLocation;
        }

        public static IdentifiableEntity Update(GeoLocation geoLocation)
        {
            return geoLocation;
        }

        public static IdentifiableEntity GetLocationById(long identifier)
        {
            return new GeoLocation
                       {
                           Identifier = identifier, Longitude = 1, Latitude = 1
                       };
        }

        public static void RemoveById(int identifier)
        {

        }
    }
}