using Model.Domain;
using Model.Persistence;
using System.Linq;
using Microsoft.SqlServer.Types;
using System.Collections.Generic;

namespace Repositories
{
    public class GeolocationRepository
    {
        public static GeoLocation Create(GeoLocation geoLocation)
        {
            using (var repo = new PersistenceEntities())
            {
                // only add location if location is not already inserted for the phone/ timestamp.  We can get fairly dirty data 
                var existingLocation = LocationsByNaturalKey(geoLocation)
                    .FirstOrDefault();
                if (existingLocation != null) return GeoLocation.Null;
                var locationId = repo.InsertLocation(geoLocation.PhoneId, geoLocation.Longitude, geoLocation.Latitude, geoLocation.Timestamp);
                geoLocation.Identifier = locationId.ToString();
                repo.SaveChanges();
            }
            return geoLocation;
        }

        private static IEnumerable<Location> LocationsByNaturalKey(GeoLocation geoLocation)
        {
            using (var repo = new PersistenceEntities())
            {
                return repo.Locations
                     .Where(l => l.PhoneId == geoLocation.PhoneId && l.Timestamp == geoLocation.Timestamp)
                     .ToList();
            }
        }

        public static GeoLocation Update(GeoLocation geoLocation)
        {
            return geoLocation;
            // for now, locations are write once
        }

        private static Location GetLocationById(long identifier)
        {
            using (var repo = new PersistenceEntities())
            {
                // only add location if location is not already inserted for the phone/ timestamp.  We can get fairly dirty data 
                var locationOfId = repo.Locations
                    .Where(l => l.Identifier == identifier)
                    .FirstOrDefault();
                return locationOfId;
            }
        }
        public static GeoLocation GetGeoLocationById(long identifier)
        {
            var locationOfId = GetLocationById(identifier);
            var x = SqlGeometry.Parse(locationOfId.LocationText);
            var location = new GeoLocation
            {
                Identifier = locationOfId.Identifier.ToString(),
                Longitude = x.STX.Value,
                Latitude = x.STY.Value,
                Timestamp = locationOfId.Timestamp.Value
            };
            return locationOfId == null ? GeoLocation.Null : location;
        }

        public static void RemoveById(int identifier)
        {

        }
    }
}