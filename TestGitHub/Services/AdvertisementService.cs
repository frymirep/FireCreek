using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Services
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
                var ad = AdvertisementRepository.GetAdvertById(addId);
                return ad;
            }
            catch
            {
            }
            return null;
        }

        [WebInvoke(UriTemplate = "{addId}", Method = "PUT")]
        public Advertisement Update(string addId, Advertisement advertisement)
        {
            int add;
            if (!int.TryParse(addId, out add)) return null;
            AdvertisementRepository.Update(advertisement);
            return new Advertisement();
        }

        [WebInvoke(UriTemplate = "{addId}", Method = "DELETE")]
        public void Delete(string addId)
        {
        }

        #endregion
    }
}