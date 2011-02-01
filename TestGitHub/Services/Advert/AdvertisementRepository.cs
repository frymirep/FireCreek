namespace Services.Advert
{
    public class AdvertisementRepository
    {
        public static Advertisement Update(Advertisement advertisement)
        {
            return advertisement;
        }

        public static Advertisement GetAdvertById(int add)
        {
            return new Advertisement { Identifier = add, AdvertContent = new byte[] { 23, 46, 67, 45, 23, 56, 87, 56, 99, 167 } };
        }

        public static void RemoveById(int add)
        {

        }
    }
}