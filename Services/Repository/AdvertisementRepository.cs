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

        public static IdentifiableEntity GetAdvertById(int identifier)
        {
            return new Advertisement
                       {
                           Identifier = identifier, 
                           AdvertContent = new byte[] { 23, 46, 67, 45, 23, 56, 87, 56, 99, 167 }
                       };
        }

        public static void RemoveById(int identifier)
        {

        }
    }
}