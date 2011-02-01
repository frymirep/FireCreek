// inspiration: http://geekswithblogs.net/michelotti/archive/2010/08/21/restful-wcf-services-with-no-svc-file-and-no-config.aspx

using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface IAdvertisementService
    {
        [OperationContract]
        Advertisement GetAdvert(int addId);

        [OperationContract]
        Advertisement InsertPerson(Advertisement person);

        [OperationContract]
        Advertisement UpdatePerson(string id, Advertisement person);

        [OperationContract]
        void DeletePerson(string id);
    }
}