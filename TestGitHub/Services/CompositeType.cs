using System;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;

namespace Services
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AdvertisementService : IAdvertisementService
    {
        public Advertisement GetAdvert(int addId)
        {
            throw new NotImplementedException();
        }

        public Advertisement InsertPerson(Advertisement person)
        {
            throw new NotImplementedException();
        }

        public Advertisement UpdatePerson(string id, Advertisement person)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(string id)
        {
            throw new NotImplementedException();
        }
    }
}