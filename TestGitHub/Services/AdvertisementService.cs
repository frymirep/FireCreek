using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AdvertisementService : IAdvertisementService
    {
        #region IAdvertisementService Members

        [WebInvoke(Method = "POST")]
        public Advertisement Create(Advertisement person)
        {
            return null;
        }

        [WebGet(UriTemplate = "{addId}")]
        public Advertisement Read(int addId)
        {
            return null;
        }

        [WebInvoke(UriTemplate = "{addId}", Method = "PUT")]
        public Advertisement Update(int addId, Advertisement person)
        {
            return null;
        }

        [WebInvoke(UriTemplate = "{addId}", Method = "DELETE")]
        public void Delete(string id)
        {
        }

        #endregion
    }
}