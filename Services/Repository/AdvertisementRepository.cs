using Services.Model;

namespace Services.Repository
{
    public class AdvertisementRepository
    {
        public static IdentifiableEntity Create(Advertisement advertisement)
        {
            return advertisement;
        }

        public static IdentifiableEntity Update(Advertisement advertisement)
        {
            return advertisement;
        }

        public static IdentifiableEntity GetAdvertById(int add)
        {
            return new Advertisement { Identifier = add, AdvertContent = new byte[] { 23, 46, 67, 45, 23, 56, 87, 56, 99, 167 } };
        }

        public static void RemoveById(int add)
        {

        }
    }

    public class GeolocationRepository
    {
        public static IdentifiableEntity Create(GeoLocation advertisement)
        {
            return advertisement;
        }

        public static IdentifiableEntity Update(GeoLocation advertisement)
        {
            return advertisement;
        }

        public static IdentifiableEntity GetLocationById(int identifier)
        {
            return new Advertisement { Identifier = identifier, AdvertContent = new byte[] { 23, 46, 67, 45, 23, 56, 87, 56, 99, 167 } };
        }

        public static void RemoveById(int add)
        {

        }
    }
}