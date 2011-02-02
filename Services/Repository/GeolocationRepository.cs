using Services.Model;

namespace Services.Repository
{
    public class GeolocationRepository
    {
        public static IdentifiableEntity Create(GeoLocation geoLocation)
        {
            return geoLocation;
        }

        public static IdentifiableEntity Update(GeoLocation geoLocation)
        {
            return geoLocation;
        }

        public static IdentifiableEntity GetLocationById(int identifier)
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