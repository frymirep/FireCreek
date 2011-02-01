// inspiration: http://geekswithblogs.net/michelotti/archive/2010/08/21/restful-wcf-services-with-no-svc-file-and-no-config.aspx

using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface IAdvertisementService
    {
        [OperationContract]
        Advertisement Create(Advertisement person);

        [OperationContract]
        Advertisement Read(int addId);

        [OperationContract]
        Advertisement Update(int addId, Advertisement person);

        [OperationContract]
        void Delete(string id);
    }
}