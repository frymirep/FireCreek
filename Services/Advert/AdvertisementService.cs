using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Services.Advert
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AdvertisementService : IAdvertisementService
    {
        #region IAdvertisementService Members

        [WebInvoke(Method = "POST")]
        public Advertisement Create(Advertisement advertisement)
        {
            return null;
        }

        [WebGet(UriTemplate = "{addId}")]
        public Advertisement Read(string addId)
        {
            int add;
            if (!int.TryParse(addId,out add)) return null;
            try
            {
                return AdvertisementRepository.GetAdvertById(add);
            }
            catch
            {
            }
            return null;
        }

        [WebInvoke(UriTemplate = "{addId}", Method = "PUT")]
        public Advertisement Update(string addId, Advertisement advertisement)
        {
            return AdvertisementRepository.Update(advertisement);
        }

        [WebInvoke(UriTemplate = "{addId}", Method = "DELETE")]
        public void Delete(string addId)
        {
            int add;
            if (!int.TryParse(addId,out add)) return;

            AdvertisementRepository.RemoveById(add);
        }
        #endregion
    }
}